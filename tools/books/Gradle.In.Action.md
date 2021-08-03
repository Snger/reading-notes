# Gradle In Action(Gradle实战)中文版

<!-- MarkdownTOC -->

- 约定优于配置
- apply plugin: 'android' or apply plugin: 'com.android.application'
- build android studio app via command line
- 使用命令行操作
- 命令行选项
- 使用java插件
- 构建项目
- 自定义你的项目
- 用Gradle开发Web项目
- 自定义WAR插件
- 在嵌入的Web容器中运行
- Gradle包装器
- 配置Gradle包装器
- 自定义包装器
- 构建块
- 项目
- 任务
- 属性
	- 外部属性

<!-- /MarkdownTOC -->

## 约定优于配置
> 如同Ant一般，Gradle给了用户足够的自由去定义自己的任务，不过同时Gradle也提供了类似Maven的约定优于配置方式，这是通过Gradle的Java Plugin实现的，从文档上看，Gradle是推荐这种方式的。Java Plugin定义了与Maven完全一致的项目布局：
> src/main/java
> src/main/resources
> src/test/java
> src/test/resources
> 区别在于，使用Groovy自定义项目布局更加的方便：
````gradle
sourceSets {
    main {
        java {
            srcDir 'src/java'
        }
        resources {
            srcDir 'src/resources'
        }
    }
}
````

## apply plugin: 'android' or apply plugin: 'com.android.application'
> apply plugin: 'android' specifies that It's an Android project but it does not specify Its an Application or Library project. To make life easier you can tell gradle the type of project and indicate which plugin should be used. I recommend to use apply plugin: 'com.android.application if project is an app and apply plugin: 'com.android.library' if project is a lib. It helps gradle to compile project efficiently. [detailed explanation](http://gradle.org/docs/current/userguide/plugins.html)

## build android studio app via command line
> Cheatsheet for running Gradle from the command line for Android Studio projects on Linux:
````bash
cd <project-root>
./gradlew
./gradlew tasks
./gradlew --help
````

## 使用命令行操作
> - 检查构建脚本
	$ gradle -q tasks
> Gradle提供了一个辅助的任务tasks来检查你的构建脚本，然后显示所有的任务，包含一个描述性的消息。
> -  任务执行
	$ gradle groupTherapy
	$ gradle gT
> 要执行一个任务，只需要输入gradle + 任务名，Gradle确保这个任务和它所依赖的任务都会执行，要执行多个任务只需要在后面添加多个任务名。Gradle提高效率的一个办法就是能够在命令行输入任务名的驼峰简写，当你的任务名称非常长的时候这很有用，当然你要确保你的简写只匹配到一个任务
> - 运行的时候排除一个任务
	$ gradle groupTherapy -x yayGradle0
> 比如运行的时候你要排除yayGradle0,你可以使用-x命令来完成
> - 列出可配置的标准和插件属性以及他们的默认值
	$ gradle properties 
> 运行命令行 gradle properties 可以列出可配置的标准和插件属性以及他们的默认值（并编译？）。
> - 检查依赖报告
	$ gradle dependencies
> 当你运行dependencies任务时，这个依赖树会打印出来，依赖树显示了你build脚本声明的顶级依赖和它们的传递依赖， 仔细观察你会发现有些传递依赖标注了 * 号，表示这个依赖被忽略了，这是因为其他顶级依赖中也依赖了这个传递的依赖，Gradle会自动分析下载最合适的依赖。

## 命令行选项
> 
-i:Gradle默认不会输出很多信息，你可以使用-i选项改变日志级别为INFO
-s:如果运行时错误发生打印堆栈信息
-q:只打印错误信息
-?-h,--help:打印所有的命令行选项
-b,--build-file:Gradle默认执行build.gradle脚本，如果想执行其他脚本可以使用这个命令，比如gradle -b test.gradle
--offline:在离线模式运行build,Gradle只检查本地缓存中的依赖
-D, --system-prop:Gradle作为JVM进程运行，你可以提供一个系统属性比如：-Dmyprop=myValue
-P,--project-prop:项目属性可以作为你构建脚本的一个变量，你可以传递一个属性值给build脚本，比如：-Pmyprop=myValue
> tasks:显示项目中所有可运行的任务
> properties:打印你项目中所有的属性值

## 使用java插件
> 每个Gradle项目都会创建一个build.gradle文件，如果你想使用java插件只需要添加下面这行代码：
`apply plugin: 'java'`
> 这一行代码足以构建你的项目，但是Gradle怎么知道你的源代码放在哪个位置呢？ java插件的一个约定就是源代码的位置，默认情况下插件搜索 `src/main/java` 路径下的文件，你的包名 `com.manning.gia.todo` 会转换成源代码根目录下的子目录

## 构建项目
> 现在你可以构建你的项目了，java插件添加了一个build任务到你项目中，build任务编译你的代码、运行测试然后打包成jar文件，所有都是按序执行的。运行gradle build之后你的输出应该是类似这样的：
````bash
$ gradle build
:compileJava
:processResources UP-TO-DATE
:classes
:jar
:assemble
:compileTestJava UP-TO-DATE
:processTestResources UP-TO-DATE
:testClasses UP-TO-DATE
:test
:check
:build
````
> 输出的每一行都表示一个可执行的任务，你可能注意到有一些任务标记为 UP-TO-DATE ,这意味着这些任务被跳过了，gradle 能够自动检查哪些部分没有发生改变，就把这部分标记下来，省的重复执行。在大型的企业项目中可以节省不少时间。

## 自定义你的项目
> - 修改你的项目和插件属性
> 接下来你将学习如何指定项目的版本号、Java源代码的兼容级别，前面你用的java命令来运行应用程序，你需要通过命令行选项-cp build/classes/main指定class文件的位置给Java运行时。但是要从JAR文件中启动应用，你需要在manifest文件MANIFEST.MF中包含首部Main-Class。看下面的脚本你就明白怎么操作了：
````gradle
//Identifies project’sversion through a number scheme
> version = 0.1
//Sets Java version compilation compatibility to 1.6
> sourceCompatibility = 1.6
//Adds Main-Class header to JAR file’s manifest
> jar {
> manifest {
    attributes 'Main-Class': 'com.manning.gia.todo.ToDoApp'
}
````
> 打包成JAR之后，你会发现JAR文件的名称变成了todo-app-0.1.jar，这个jar包含了main-class首部，你就可以通过命令java -jar build/libs/todo-app-0.1.jar运行了。
> 接下来学习如何改变项目的默认布局：
````gradle
//Replaces conventional source code directory with list of different directories
sourceSets {
    main {
        java {
            srcDirs = ['src']
        }
    }
//Replaces conventional test source code directory with list of different directories    

    test {
        java {
            srcDirs = ['test']
            }
        }
}
//Changes project output property to directory out
buildDir = 'out'
````
> - 配置和使用外部依赖
在Java世界里，依赖是分布的以JAR文件的形式存在，许多库都从仓库里获得，比如一个文件系统或中央服务器。Gradle需要你指定至少一个仓库作为依赖下载的地方，比如 mavenCentral：
````gradle
//Shortcut notation for configuring Maven Central 2 repository accessible under http://repo1.maven.org/maven2
repositories {
    mavenCentral()
}
````
> - 定义依赖
接下来就是定义依赖，依赖通过group标识，name和version来确定，比如下面这个：
````gradle
dependencies {
    compile group: 'org.apache.commons', name: 'commons-lang3', version: '3.1'
}
````
Gradle是通过配置来给依赖分组，Java插件引入的一个配置是compile，你可以很容易区分这个配置定义的依赖是用来编译源代码的。
> - 解析依赖
Gradle能够自动检测并下载项目定义的依赖

## 用Gradle开发Web项目
> **使用War和Jetty插件**
> Gradle支持构建和运行Web应用，接下来我将介绍两个web应用开发的插件War和Jetty，War插件继承了Java插件用来给web应用开发添加一些约定、支持打包War文件。Jetty是一个很受欢迎的轻量级的开源Web容器，Gradle的Jetty插件继承War插件，提供部署应用程序到嵌入的容器的任务。
> 既然War插件继承了Java插件，所以你在应用了War插件后无需再添加Java插件，即使你添加了也没有负面影响，应用插件是一个非幂等的操作，因此对于一个指定的插件只运行一次。添加下面这句到你的build.gradle脚本中：
	apply plugin: 'war'
> 除了Java插件提供的约定外，你的项目现在多了Web应用的源代码目录，将打包成war文件而不是jar文件，Web应用默认的源代码目录是src/main/webapp,
> 你用来实现Web应用的帮助类不是java标准的一部分，比如javax.servlet.HttpServlet,在运行build之前，你应该确保你声明了这些外部依赖，War插件引入了两个新的依赖配置，用于Servlet依赖的配置是providedCompile，这个用于那些编译器需要但是由运行时环境提供的依赖，你现在的运行时环境是Jetty，因此用provided标记的依赖不会打包到WAR文件里面，运行时依赖比如JSTL这些在编译器不需要，但是运行时需要，他们将成为WAR文件的一部分。
	dependencies {
	   providedCompile 'javax.servlet:servlet-api:2.5'
	   runtime 'javax.servlet:jstl:1.1.2'
	}
> build Web项目和Java项目一样，运行gradle build后打包的WAR文件在目录build/libs下，输出如下：
	$ gradle build
	:compileJava
	:processResources UP-TO-DATE
	:classes
	:war
	:assemble
	:compileTestJava UP-TO-DATE
	:processTestResources UP-TO-DATE
	:testClasses UP-TO-DATE
	:test
	:check
	:build
> War插件确保打包的WAR文件符合JAVA EE规范，war任务拷贝web应用源目录src/main/webapp到WAR文件的根目录，编译的class文件保存在WEB-INF/classes,运行时依赖的库放在WEB-INF/libs

## 自定义WAR插件
> 假设你把所有的静态文件放在static目录， 所有的web组件放在 webfiles， 目录结构如下：
	//Changes web application source directory

	webAppDirName = 'webfiles'

	//Adds directories css and jsp to root of WAR file archive
	war {
	from 'static'
	}

## 在嵌入的Web容器中运行
> 嵌入式的Servlet容器完全不知道你的应用程序信息，直到你提供准确的classpath和源代码目录，你可以手动编程设置，当然也可以选择 Jetty 插件自动帮你完成了所有的工作，只需要添加下面一条命令：
	apply plugin: 'jetty'
> 运行Web应用需要用到的任务是jettyRun,启动Jetty容器并且无需创建WAR文件，这个命令的输出应该类似这样的：
	$ gradle jettyRun
	:compileJava
	:processResources UP-TO-DATE
	:classes
	> Building > :jettyRun > Running at http://localhost:8080/todo-webapp-jetty
> 最后一行Jetty插件给你提供了一个URL用来监听HTTP请求，打开浏览器输入这个链接就能看到你编写的Web应用了。
> Jetty插件默认监听的端口是8080，上下文路径是todo-webapp-jetty,你也可以自己配置成想要的：
	jettyRun {
	   httpPort = 9090
	   contextPath = 'todo'
	}
> 这样你就把监听端口改成了9090,上下文目录改成了todo。

## Gradle包装器
> Gradle提供了一个非常方便和实用的方法：Gradle包装器，包装器是Gradle的一个核心特性，它允许你的机器不需要安装运行时就能运行Gradle脚本，而且她还能确保build脚本运行在指定版本的Gradle。它会从中央仓库中自动下载Gradle运行时，解压到你的文件系统，然后用来build。终极目标就是创建可靠的、可复用的、与操作系统、系统配置或Gradle版本无关的构建。

## 配置Gradle包装器
> 在设置你的包装器之前，你需要做两件事情：创建一个包装任务，执行这个任务生成包装文件。为了能让你的项目下载压缩的Gradle运行时，定义一个Wrapper类型的任务 在里面指定你想使用的Gradle版本：
	task wrapper(type: Wrapper) {
	    gradleVersion = '1.7'
	}
> 然后执行这个任务：
	$ gradle wrapper
	:wrapper
> 执行完之后，你就能看到下面这个 gradle/wrapper 文件和你的构建脚本：
> - gradle-wrapper.jar
> Gradle wrapper microlibrary contains logic to download and unpack distribution
> - gradle-wrapper.properties
> Wrapper metadata like storage location for downloaded distribution and originating URL
> 记住你只需要运行 `gradle wrapper` 一次，以后你就能用 `wrapper` 来执行你的任务，下载下来的 `wrapper` 文件会被添加到版本控制系统中。如果你的系统中已经安装了 `Gradle` 运行时，你就不需要再添加一个 `gradle wrapper` 任务，你可以直接运行 `gradle wrapper` 任务，这个任务会使用你的 `Gradle` 当前版本来生成包装文件。

## 自定义包装器
> 一些公司的安全措施非常严格，特别是当你给政府工作的时候，你能够访问外网的能力是被限制的，在这种情况下你怎么让你的项目使用Gradle包装器？所以你需要修改默认配置：
	task wrapper(type: Wrapper) {
	    //Requested Gradle version
	    gradleVersion = '1.2'
	    //Target URL to retrieve Gradle wrapper distribution
	    distributionUrl = 'http://myenterprise.com/gradle/dists'
	    //Path where wrapper will be unzipped relative to Gradle home directory
	    distributionPath = 'gradle-dists'         
	}

## 构建块
> 每个Gradle构建都包括三个基本的构建块：项目(projects)、任务(tasks)和属性(properties)，每个构建至少包括一个项目，项目包括一个或者多个任务，项目和任务都有很多个属性来控制构建过程。
> Gradle运用了领域驱动的设计理念（DDD）来给自己的领域构建软件建模，因此Gradle的项目和任务都在Gradle的API中有一个直接的class来表示，接下来我们来深入了解每一个组件和它对应的API。

## 项目
> 在Gradle术语里项目表示你想构建的一个组件(比如一个JAR文件)，或者你想完成的一个目标(比如打包app)，如果你以前使用过Maven，你应该听过类似的概念。与Maven pom.xml相对应的是build.gradle文件，每个Gradle脚本至少定义了一个项目。当开始构建过程后，Gradle基于你的配置实例化 [org.gradle.api.Project](https://github.com/gradle/gradle/blob/master/subprojects/core-api/src/main/java/org/gradle/api/Project.java) 这个类以及让这个项目通过project变量来隐式的获得。
> 一个项目可以创建新任务、添加依赖和配置、应用插件和其他脚本，许多属性比如name和description都是可以通过getter和setter方法来访问。
> Project实例允许你访问你项目所有的Gradle特性，比如任务的创建和依赖了管理，记住一点当访问你项目的属性和方法时你并不需要显式的使用project变量--Gradle假定你的意思是Project实例，看看下面这个例子： 
	//没有使用project变量来设置项目的描述
	setDescription("myProject")
	//使用Grovvy语法来访问名字和描述
	println "Description of project $name: " + project.description
> 在之前的章节，我们只处理到单个peoject的构建，Gradle支持多项目的构建，软件设计一个很重要的概念是模块化，当一个软件系统变得越复杂，你越想把它分解成一个个功能性的模块，模块之间可以相互依赖，每个模块有自己的build.gradle脚本。

##任务
> 我们在第二章的时候就创建了一些简单的任务，你应该了解两个概念：任务动作(actions)和任务依赖，一个动作就是任务执行的时候一个原子的工作，这可以简单到打印hello world,也可以复杂到编译源代码。很多时候一个任务需要在另一个任务之后执行，尤其是当一个任务的输入依赖于另一个任务的输出时，比如项目打包成JAR文件之前先要编译成class文件，让我们来看看Gradle API中任务的表示： [org.gradle.api.Task](https://github.com/gradle/gradle/blob/master/subprojects/core-api/src/main/java/org/gradle/api/Task.java) 接口。

##属性
> 每个 Project和 Task实例都提供了 setter和 getter方法来访问属性，属性可以是任务的描述或者项目的版本号，在后续的章节，你会在具体例子中读取和修改这些属性值，有时候你要定义你自己的属性，比如，你想定义一个变量来引用你在构建脚本中多次使用的一个文件，Gradle允许你通过外部属性来定义自己的变量。

###外部属性
> 外部属性一般存储在键值对中，要添加一个属性，你需要使用ext命名空间，看一个例子：
	//Only initial declaration of extra property requires you to use ext namespace
	project.ext.myProp = 'myValue'
	ext {
	   someOtherProp = 123
	}
	//Using ext namespace to access extra property is optional
	assert myProp == 'myValue'
	println project.someOtherProp
	ext.someOtherProp = 567	
> 相似的，外部属性可以定义在一个属性文件中：
> 通过在 <USER_HOME>/.gradle 路径或者项目根目录下的 gradle.properties 文件来定义属性可以直接注入到你的项目中，他们可以通过 project实例来访问，注意<USER_HOME>/.gradle 目录下只能有一个 Gradle属性文件即使你有多个项目，在属性文件中定义的属性可以被所有的项目访问，假设你在你的gradle.properties文件中定义了下面的属性：
	exampleProp = myValue
	someOtherProp = 455
> 你可以在项目中访问这两个变量：
	assert project.exampleProp == 'myValue'
	task printGradleProperty << {
	   println "Second property: $someOtherProp"
	}
> **定义属性的其他方法**
> 你也可以通过下面的方法来定义属性：
* 通过 -P 命令行选项来定义项目属性
* 通过 -D 命令行选项来定义系统属性
* 环境属性遵循这个模式： `ORG_GRADLE_PROJECT_propertyName=someValue`

