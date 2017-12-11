# 第一行代码
> 作者: 郭霖 
> 出版社: 人民邮电出版社
> 副标题: Android
> ISBN: 9787115362865
> [github](https://github.com/guolindev/booksource)

<!-- MarkdownTOC -->

- 第 2 章 先从看得到的入手，探究活动
	- 2.2.3 在 AndroidManifest 文件中注册
	- 2.5 活动的启动模式
	- 3.3.4　百分比布局
- How to use Percentage for android layout?
	- 3.4　系统控件不够用？创建自定义控件
	- 3.5.1　ListView的简单用法
- 3.6　更强大的滚动控件——RecyclerView
	- 3.6.1　RecyclerView的基本用法
	- 3.6.2　实现横向滚动和瀑布流布局
- 3.7　编写界面的最佳实践
	- 3.7.1　制作Nine-Patch图片
	- Android Draw9patch is missing?
	- Error:Execution failed for task ':app:mergeDebugResources'.
- 4.2　碎片的使用方式
	- 4.2.2　动态添加碎片
	- 4.2.3　在碎片中模拟返回栈
	- 4.2.4　碎片和活动之间进行通信
	- 4.3　碎片的生命周期
	- 碎片的状态和回调
- 4.4　动态加载布局的技巧
	- 4.4.1　使用限定符
	- 4.4.2　使用最小宽度限定符
	- Difference between sw600dp and w600dp?
- 4.5　碎片的最佳实践——一个简易版的新闻应用
- 5.1　广播机制简介
	- 5.2.1　动态注册监听网络变化
	- 5.2.2　静态注册实现开机启动
	- 5.3.1　发送标准广播
	- 5.3.2　发送有序广播
- 5.4　使用本地广播
- 第 6 章　数据存储全方案——详解持久化技术
	- 6.1　持久化技术简介
	- 6.2　文件存储
	- 6.2.1　将数据存储到文件中
	- 6.2.2　从文件中读取数据
- 6.3　SharedPreferences存储
	- 6.3.2　从SharedPreferences中读取数据
- 6.4　SQLite数据库存储
	- 6.4.1　创建数据库
	- 6.4.2　升级数据库
	- 6.4.3　添加数据
	- 6.4.4　更新数据
	- 6.4.5　删除数据
	- 6.4.7　使用SQL操作数据库
- 6.5　使用LitePal操作数据库
	- 6.5.3　创建和升级数据库
	- 6.5.4　使用LitePal添加数据
	- 6.5.5　使用LitePal更新数据
	- 6.5.6　使用LitePal删除数据
	- 6.5.7　使用LitePal查询数据
- 第 7 章　跨程序共享数据——探究内容提供器
- 7.1　内容提供器简介
	- 7.2.1　Android权限机制详解
	- 7.2.2　在程序运行时申请权限
- 7.3　访问其他程序中的数据

<!-- /MarkdownTOC -->

## 第 2 章 先从看得到的入手，探究活动

### 2.2.3 在 AndroidManifest 文件中注册

#### 那么这里填入的.FirstActivity 是什么意思呢？
> 其实这不过就是 com.example.activitytest.FirstActivity 的缩写而已。由于最外层的<manifest>标签中已经通过 package 属性指定了程序的包名是 com.example.activitytest，因此在注册活动时这一部分就可以省略了，直接使用 `.FirstActivity` 就足够了。

#### 使用了 android:label指定活动中标题栏的内容
> 标题栏是显示在活动最顶部的，待会儿运行的时候你就会看到。需要注意的是，给主活动指定的 label 不仅会成为标题栏中的内容，还会成为启动器 （Launcher） 中应用程序显示的名称。

#### res/menu and res/xml are not there
> If it is in android studio 2.1.1, to create a res/menu folder follow these steps.
> right click on res -> new -> Android resource directory -> change the resource type to 'menu' in the dropdown menu -> click ok
> to create menu file in menu folder right click on menu folder -> new -> menu resource file ->give the file name -> click ok.
> For xml file it's the same procedure but in the dropdown menu chose 'xml' instead of 'menu'

#### 2.4.3 活动的生存期
> onCreate(), onStart(), onResume(), onPause(), onStop(), onDestroy(), onRestart()

### 2.5 活动的启动模式
> - standard
> standard 是活动默认的启动模式，在不进行显式指定的情况下，所有活动都会自动使用 这种启动模式。因此，到目前为止我们写过的所有活动都是使用的 standard 模式。经过上一节的学习，你已经知道了 Android 是使用返回栈来管理活动的，在 standard 模式（即默认情 况）下，每当启动一个新的活动，它就会在返回栈中入栈，并处于栈顶的位置。对于使用 standard 模式的活动，系统不会在乎这个活动是否已经在返回栈中存在，每次启动都会创建 该活动的一个新的实例。
> - singleTop
> 当活动的启动模式 指定为 singleTop，在启动活动时如果发现返回栈的栈顶已经是该活动，则认为可以直接使用 它，不会再创建新的活动实例。不过当 FirstActivity 并未处于栈顶位置时，这时再启动 FirstActivity，还是会创建新的实例的。
> - singleTask
> 当活动的启动模式指定为 singleTask，每次启动该活动时系统首先会在返回栈中检查是否存在该活动的实例，如果发现已经存在则直接使用该实例，并把在这个活动之上的所有活动统统出栈，如果没有发现就会创建一个新的活动实例。
> - singleInstance
> singleInstance模式应该算是四种启动模式中最特殊也最复杂的一个了，你也需要多花点功夫来理解这个模式。不同于以上三种启动模式，指定为 singleInstance模式的活动会启用一个新的返回栈来管理这个活动（其实如果 singleTask模式指定了不同的 taskAffinity，也会启动一个新的返回栈）。那么这样做有什么意义呢？想象以下场景，假设我们的程序中有一个活动是允许其他程序调用的，如果我们想实现其他程序和我们的程序可以共享这个活动的实例，应该如何实现呢？使用前面三种启动模式肯定是做不到的，因为每个应用程序都会有自己的返回栈，同一个活动在不同的返回栈中入栈时必然是创建了新的实例。而使用singleInstance模式就可以解决这个问题，在这种模式下会有一个单独的返回栈来管理这个活动，不管是哪个应用程序来访问这个活动，都共用的同一个返回栈，也就解决了共享活动实例的问题。

### 3.3.4　百分比布局
> 由于LinearLayout本身已经支持按比例指定控件的大小了，因此百分比布局只为FrameLayout和RelativeLayout进行了功能扩展，提供了PercentFrameLayout和PercentRelativeLayout这两个全新的布局，不同于前3种布局，百分比布局属于新增布局，那么怎么才能做到让新增布局在所有Android版本上都能使用呢？为此，Android团队将百分比布局定义在了support库当中，我们只需要在项目的build.gradle中添加百分比布局库的依赖，就能保证百分比布局在Android所有系统版本上的兼容性了。
> 打开app/build.gradle文件，在dependencies 闭包中添加如下内容：
````gradle
dependencies {
    compile fileTree(dir: 'libs', include: ['*.jar'])
    compile 'com.android.support:appcompat-v7:24.2.1'
    compile 'com.android.support:percent:24.2.1'
    testCompile 'junit:junit:4.12'
}
````
> 需要注意的是，每当修改了任何gradle文件时，Android Studio都会弹出一个如图3.25所示的提示。这个提示告诉我们，gradle文件自上次同步之后又发生了变化，需要再次同步才能使项目正常工作。这里只需要点击Sync Now就可以了，然后gradle会开始进行同步，把我们新添加的百分比布局库引入到项目当中。

## How to use Percentage for android layout?
> With both PercentFrameLayout and PercentRelativeLayout being deprected in 26.0.0, you need to use ConstraintLayout to size your TextView with percentage values.
> ConstraintLayout is really powerful tool to build Responsive UI for Android platform, you can find more details here Build a Responsive UI with ConstraintLayout.
> Here is the example how to size your TextView(w=60%, h=50%) using ConstraintLayout:
````xml
<?xml version="1.0" encoding="utf-8"?>
<android.support.constraint.ConstraintLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    xmlns:tools="http://schemas.android.com/tools"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    tools:context="com.thkly.uiwidgetest.PercentFrameLayoutActivity">

    <android.support.constraint.Guideline
        android:id="@+id/gl_percent_frame_ver"
        android:orientation="vertical"
        app:layout_constraintGuide_percent="0.6"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content" />
    <android.support.constraint.Guideline
        android:id="@+id/gl_percent_frame_hor"
        android:orientation="horizontal"
        app:layout_constraintGuide_percent="0.5"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content" />
    
    <Button
        android:text="first"
        android:layout_width="0dp"
        android:layout_height="0dp"
        app:layout_constraintTop_toTopOf="parent"
        app:layout_constraintStart_toStartOf="parent"
        app:layout_constraintBottom_toTopOf="@id/gl_percent_frame_hor"
        app:layout_constraintEnd_toStartOf="@id/gl_percent_frame_ver"
        />
    <Button
        android:text="second"
        android:layout_width="0dp"
        android:layout_height="0dp"
        app:layout_constraintTop_toTopOf="@id/gl_percent_frame_hor"
        app:layout_constraintStart_toStartOf="@id/gl_percent_frame_ver"
        app:layout_constraintBottom_toBottomOf="parent"
        app:layout_constraintRight_toRightOf="parent"
        />
</android.support.constraint.ConstraintLayout>
````
> Don't forget to add constraint-layout dependency to your module build.gradle file
````gradle
dependencies {
    compile 'com.android.support.constraint:constraint-layout:1.0.2'
}
````

### 3.4　系统控件不够用？创建自定义控件
> 我们所用的所有控件都是直接或间接继承自View的，所用的所有布局都是直接或间接继承自ViewGroup的。View是Android中最基本的一种UI组件，它可以在屏幕上绘制一块矩形区域，并能响应这块区域的各种事件，因此，我们使用的各种控件其实就是在View的基础之上又添加了各自特有的功能。而ViewGroup则是一种特殊的View，它可以包含很多子View和子ViewGroup，是一个用于放置控件和布局的容器。

### 3.5.1　ListView的简单用法
> 既然ListView是用于展示大量数据的，那我们就应该先将数据提供好。这些数据可以是从网上下载的，也可以是从数据库中读取的，应该视具体的应用程序场景而定。这里我们就简单使用了一个data数组来测试，里面包含了很多水果的名称。
> 不过，数组中的数据是无法直接传递给ListView的，我们还需要借助适配器来完成。Android中提供了很多适配器的实现类，其中我认为最好用的就是ArrayAdapter。它可以通过泛型来指定要适配的数据类型，然后在构造函数中把要适配的数据传入。ArrayAdapter有多个构造函数的重载，你应该根据实际情况选择最合适的一种。这里由于我们提供的数据都是字符串，因此将ArrayAdapter的泛型指定为String ，然后在ArrayAdapter的构造函数中依次传入当前上下文、ListView子项布局的id，以及要适配的数据。注意，我们使用了android.R.layout.simple_list_item_1 作为ListView子项布局的id，这是一个Android内置的布局文件，里面只有一个TextView，可用于简单地显示一段文本。这样适配器对象就构建好了。
> 最后，还需要调用ListView的setAdapter() 方法，将构建好的适配器对象传递进去，这样ListView和数据之间的关联就建立完成了。

#### 3.5.3　提升ListView的运行效率
> 之所以说ListView这个控件很难用，就是因为它有很多细节可以优化，其中运行效率就是很重要的一点。目前我们ListView的运行效率是很低的，因为在FruitAdapter 的getView() 方法中，每次都将布局重新加载了一遍，当ListView快速滚动的时候，这就会成为性能的瓶颈。
> 仔细观察会发现，getView() 方法中还有一个convertView 参数，这个参数用于将之前加载好的布局进行缓存，以便之后可以进行重用。
> 可以看到，现在我们在getView()方法中进行了判断，如果convertView为null，则使用LayoutInflater去加载布局，如果不为null则直接对convertView进行重用。这样就大大提高了ListView的运行效率，在快速滚动的时候也可以表现出更好的性能。
> 不过，目前我们的这份代码还是可以继续优化的，虽然现在已经不会再重复去加载布局，但是每次在getView() 方法中还是会调用View 的findViewById() 方法来获取一次控件的实例。我们可以借助一个ViewHolder 来对这部分性能进行优化，修改FruitAdapter 中的代码
> 我们新增了一个内部类ViewHolder ，用于对控件的实例进行缓存。当convertView 为null 的时候，创建一个ViewHolder 对象，并将控件的实例都存放在ViewHolder 里，然后调用View 的setTag() 方法，将ViewHolder 对象存储在View 中。当convertView 不为null 的时候，则调用View 的getTag() 方法，把ViewHolder 重新取出。这样所有控件的实例都缓存在了ViewHolder 里，就没有必要每次都通过findViewById() 方法来获取控件实例了。
> 通过这两步优化之后，我们ListView的运行效率就已经非常不错了。

## 3.6　更强大的滚动控件——RecyclerView
> 和百分比布局类似，RecyclerView也属于新增的控件，为了让RecyclerView在所有Android版本上都能使用，Android团队采取了同样的方式，将RecyclerView定义在了support库当中。因此，想要使用RecyclerView这个控件，首先需要在项目的build.gradle中添加相应的依赖库才行。
> 打开app/build.gradle文件，在dependencies 闭包中添加如下内容：
````gradle
dependencies {
    compile fileTree(dir: 'libs', include: ['*.jar'])
    compile 'com.android.support:appcompat-v7:24.2.1'
    compile 'com.android.support:recyclerview-v7:24.2.1'
    testCompile 'junit:junit:4.12'
}
````

### 3.6.1　RecyclerView的基本用法
> 这里我们首先定义了一个内部类ViewHolder ，ViewHolder 要继承自RecyclerView.ViewHolder 。然后ViewHolder 的构造函数中要传入一个View 参数，这个参数通常就是RecyclerView子项的最外层布局，那么我们就可以通过findViewById() 方法来获取到布局中的ImageView和TextView的实例了。
> 接着往下看，FruitAdapter 中也有一个构造函数，这个方法用于把要展示的数据源传进来，并赋值给一个全局变量mFruitList ，我们后续的操作都将在这个数据源的基础上进行。
> 继续往下看，由于FruitAdapter 是继承自RecyclerView.Adapter 的，那么就必须重写onCreateViewHolder() 、onBindViewHolder() 和getItemCount() 这3个方法。onCreateViewHolder() 方法是用于创建ViewHolder 实例的，我们在这个方法中将fruit_item 布局加载进来，然后创建一个ViewHolder 实例，并把加载出来的布局传入到构造函数当中，最后将ViewHolder 的实例返回。onBindViewHolder() 方法是用于对RecyclerView子项的数据进行赋值的，会在每个子项被滚动到屏幕内的时候执行，这里我们通过position 参数得到当前项的Fruit 实例，然后再将数据设置到ViewHolder 的ImageView和TextView当中即可。getItemCount() 方法就非常简单了，它用于告诉RecyclerView一共有多少子项，直接返回数据源的长度就可以了。

### 3.6.2　实现横向滚动和瀑布流布局
> 为什么ListView很难或者根本无法实现的效果在RecyclerView上这么轻松就能实现了呢？这主要得益于RecyclerView出色的设计。ListView的布局排列是由自身去管理的，而RecyclerView则将这个工作交给了LayoutManager，LayoutManager中制定了一套可扩展的布局排列接口，子类只要按照接口的规范来实现，就能定制出各种不同排列方式的布局了。
> 除了LinearLayoutManager之外，RecyclerView还给我们提供了GridLayoutManager和StaggeredGridLayoutManager这两种内置的布局排列方式。GridLayoutManager可以用于实现网格布局，StaggeredGridLayoutManager可以用于实现瀑布流布局。

## 3.7　编写界面的最佳实践

### 3.7.1　制作Nine-Patch图片
> 在实战正式开始之前，我们还需要先学习一下如何制作Nine-Patch图片。你可能之前还没有听说过这个名词，它是一种被特殊处理过的png图片，能够指定哪些区域可以被拉伸、哪些区域不可以。
> 在Android sdk目录下有一个tools文件夹，在这个文件夹中找到draw9patch.bat文件，我们就是使用它来制作Nine-Patch图片的。不过，要打开这个文件，必须先将JDK的bin目录配置到环境变量当中才行，比如你使用的是Android Studio内置的jdk，那么要配置的路径就是<Android Studio安装目录>/jre/bin。
> 我们可以在图片的四个边框绘制一个个的小黑点，在上边框和左边框绘制的部分表示当图片需要拉伸时就拉伸黑点标记的区域，在下边框和右边框绘制的部分表示内容会被放置的区域。使用鼠标在图片的边缘拖动就可以进行绘制了，按住Shift键拖动可以进行擦除。
> 最后点击导航栏File→Save 9-patch把绘制好的图片进行保存，此时的文件名就是message_left.9.png。使用这张图片替换掉之前的message_left.png图片，重新运行程序。

### Android Draw9patch is missing?
> Infact, the popular draw9patch application is now available as a feature in the android studio application itself. If you try to open any files with a .9.png extension in your project, it will be opened in a 9 patch drawer perspective. Here is a screenshot.

### Error:Execution failed for task ':app:mergeDebugResources'.
> E:\AndroidStudioProjects\someProject\app\src\main\res\drawable-xhdpi\talk-bubble.9.png: Error: '-' is not a valid file-based resource name character: File-based resource names must contain only lowercase a-z, 0-9, or underscore
> talk-bubble.9.png -> talk_bubble.9.png

## 4.2　碎片的使用方式
> 接着新建一个LeftFragment 类，并让它继承自Fragment。注意，这里可能会有两个不同包下的Fragment供你选择，一个是系统内置的android.app.Fragment，一个是support-v4库中的android.support.v4.app.Fragment。这里我强烈建议你使用support-v4库中的Fragment，因为它可以让碎片在所有Android系统版本中保持功能一致性。比如说在Fragment中嵌套使用Fragment，这个功能是在Android 4.2系统中才开始支持的，如果你使用的是系统内置的Fragment，那么很遗憾，4.2系统之前的设备运行你的程序就会崩溃。而使用support-v4库中的Fragment就不会出现这个问题，只要你保证使用的是最新的support-v4库就可以了。另外，我们并不需要在build.gradle文件中添加support-v4库的依赖，因为build.gradle文件中已经添加了appcompat-v7库的依赖，而这个库会将support-v4库也一起引入进来。

### 4.2.2　动态添加碎片
> 碎片真正的强大之处在于，它可以在程序运行时动态地添加到活动当中。根据具体情况来动态地添加碎片，你就可以将程序界面定制得更加多样化。
> 可以看到，现在将右侧碎片替换成了一个FrameLayout中，还记得这个布局吗？在上一章中我们学过，这是Android中最简单的一种布局，所有的控件默认都会摆放在布局的左上角。由于这里仅需要在布局里放入一个碎片，不需要任何定位，因此非常适合使用FrameLayout。
> 首先我们给左侧碎片中的按钮注册了一个点击事件，然后调用replaceFragment() 方法动态添加了RightFragment这个碎片。当点击左侧碎片中的按钮时，又会调用replaceFragment() 方法将右侧碎片替换成AnotherRightFragment。结合replaceFragment() 方法中的代码可以看出，动态添加碎片主要分为5步。
> (1) 创建待添加的碎片实例。
> (2) 获取FragmentManager， 在活动中可以直接通过调用 getSupportFragmentManager() 方法得到。
> (3) 开启一个事务，通过调用beginTransaction() 方法开启。
> (4) 向容器内添加或替换碎片，一般使用replace() 方法实现，需要传入容器的id和待添加的碎片实例。
> (5) 提交事务，调用commit() 方法来完成。

### 4.2.3　在碎片中模拟返回栈
> 在事务提交之前调用了FragmentTransaction的addToBackStack() 方法，它可以接收一个名字用于描述返回栈的状态，一般传入null 即可。现在重新运行程序，并点击按钮将AnotherRightFragment添加到活动中，然后按下Back键，你会发现程序并没有退出，而是回到了RightFragment界面，继续按下Back键，RightFragment界面也会消失，再次按下Back键，程序才会退出。

### 4.2.4　碎片和活动之间进行通信
> 调用FragmentManager的findFragmentById() 方法，可以在活动中得到相应碎片的实例，然后就能轻松地调用碎片里的方法了。
> 掌握了如何在活动中调用碎片里的方法，那在碎片中又该怎样调用活动里的方法呢？其实这就更简单了，在每个碎片中都可以通过调用getActivity() 方法来得到和当前碎片相关联的活动实例
> 有了活动实例之后，在碎片中调用活动里的方法就变得轻而易举了。另外当碎片中需要使用Context 对象时，也可以使用getActivity() 方法，因为获取到的活动本身就是一个Context 对象。

### 4.3　碎片的生命周期
> 还记得每个活动在其生命周期内可能会有哪几种状态吗？没错，一共有运行状态、暂停状态、停止状态和销毁状态这4种。类似地，每个碎片在其生命周期内也可能会经历这几种状态，只不过在一些细小的地方会有部分区别。
> - 运行状态
> 当一个碎片是可见的，并且它所关联的活动正处于运行状态时，该碎片也处于运行状态。
> - 暂停状态
> 当一个活动进入暂停状态时（由于另一个未占满屏幕的活动被添加到了栈顶），与它相关联的可见碎片就会进入到暂停状态。
> - 停止状态
> 当一个活动进入停止状态时，与它相关联的碎片就会进入到停止状态，或者通过调用FragmentTransaction的remove() 、replace() 方法将碎片从活动中移除，但如果在事务提交之前调用addToBackStack() 方法，这时的碎片也会进入到停止状态。总的来说，进入停止状态的碎片对用户来说是完全不可见的，有可能会被系统回收。
> - 销毁状态
> 碎片总是依附于活动而存在的，因此当活动被销毁时，与它相关联的碎片就会进入到销毁状态。或者通过调用FragmentTransaction的remove() 、replace() 方法将碎片从活动中移除，但在事务提交之前并没有调用addToBackStack() 方法，这时的碎片也会进入到销毁状态。

### 碎片的状态和回调
> onAttach() 。当碎片和活动建立关联的时候调用。
> onCreateView() 。为碎片创建视图（加载布局）时调用。
> onActivityCreated() 。确保与碎片相关联的活动一定已经创建完毕的时候调用。
> onDestroyView() 。当与碎片关联的视图被移除的时候调用。
> onDetach() 。当碎片和活动解除关联的时候调用。

## 4.4　动态加载布局的技巧
### 4.4.1　使用限定符
> 那么怎样才能在运行时判断程序应该是使用双页模式还是单页模式呢？这就需要借助限定符（Qualifiers）来实现了。
> 在res目录下新建layout-large文件夹，在这个文件夹下新建一个布局，也叫作activity_main.xml
> 可以看到，layout/activity_main 布局只包含了一个碎片，即单页模式，而 layout-large/ activity_main 布局包含了两个碎片，即双页模式。其中large 就是一个限定符，那些屏幕被认为是large 的设备就会自动加载 layout-large 文件夹下的布局，而小屏幕的设备则还是会加载layout文件夹下的布局。
````
|--------|------|------|
| 屏幕特征 | 限定符 | 描述 |
- 大小
small    提供给小屏幕设备的资源
normal   提供给中等屏幕设备的资源
large    提供给大屏幕设备的资源
xlarge   提供给超大屏幕设备的资源
- 分辨率
ldpi     提供给低分辨率设备的资源（120dpi以下）
mdpi     提供给中等分辨率设备的资源（120dpi~160dpi）
hdpi     提供给高分辨率设备的资源（160dpi~240dpi）
xhdpi    提供给超高分辨率设备的资源（240dpi~320dpi）
xxhdpi   提供给超超高分辨率设备的资源（320dpi~480dpi）
- 方向
land     提供给横屏设备的资源
port     提供给竖屏设备的资源
````

### 4.4.2　使用最小宽度限定符
>有的时候我们希望可以更加灵活地为不同设备加载布局，不管它们是不是被系统认定为 large ，这时就可以使用最小宽度限定符 （Smallest-width Qualifier） 了。
> 最小宽度限定符允许我们对屏幕的宽度指定一个最小值（以dp为单位），然后以这个最小值为临界点，屏幕宽度大于这个值的设备就加载一个布局，屏幕宽度小于这个值的设备就加载另一个布局。
> 在res目录下新建 layout-sw600dp 文件夹，然后在这个文件夹下新建 activity_main.xml 布局，
> 这就意味着，当程序运行在屏幕宽度大于600dp的设备上时，会加载 layout-sw600dp/activity_main 布局，当程序运行在屏幕宽度小于600dp的设备上时，则仍然加载默认的 layout/activity_main 布局。

### Difference between sw600dp and w600dp?
> Android device screens are rectangles. Rectangles have two sides, one shorter than the other. Let's call the short one A and the long one B.
> - swNNNdp indicates "use these resources if A is greater than or equal to NNN dp in length" --- Short Width
> - wNNNdp indicates "use these resources if the width of the device, as presently held, is greater than or equal to NNN dp" --- Width
> When the user rotates the device between portrait and landscape, the width will change (to be A or B), but A (the shortest width) is always the same.

## 4.5　碎片的最佳实践——一个简易版的新闻应用
> 这样我们就把新闻内容的碎片和布局都创建好了，但是它们都是在双页模式中使用的，如果想在单页模式中使用的话，我们还需要再创建一个活动。右击 com.example.fragmentbestpractice 包 → New → Activity → Empty Activity，新建一个 NewsContentActivity，并将布局名指定成 news_content ，然后修改 news_content.xml 中的代码
> 仔细观察TextView，你会发现其中有几个属性是我们之前没有学过的。 android:padding 表示给控件的周围加上补白，这样不至于让文本内容会紧靠在边缘上。 android:maxLines 设置为 true 表示让这个 TextView 只能单行显示。 android:ellipsize 用于设定当文本内容超出控件宽度时，文本的缩略方式，这里指定成 end 表示在尾部进行缩略。

## 5.1　广播机制简介
> 广播接收器（Broadcast Receiver）主要可以分为两种类型：标准广播和有序广播。
> - 标准广播 （Normal broadcasts）是一种完全异步执行的广播，在广播发出之后，所有的广播接收器几乎都会在同一时刻接收到这条广播消息，因此它们之间没有任何先后顺序可言。这种广播的效率会比较高，但同时也意味着它是无法被截断的。
> - 有序广播 （Ordered broadcasts）则是一种同步执行的广播，在广播发出之后，同一时刻只会有一个广播接收器能够收到这条广播消息，当这个广播接收器中的逻辑执行完毕后，广播才会继续传递。所以此时的广播接收器是有先后顺序的，优先级高的广播接收器就可以先收到广播消息，并且前面的广播接收器还可以截断正在传递的广播，这样后面的广播接收器就无法收到广播消息了。

### 5.2.1　动态注册监听网络变化
> 广播接收器可以自由地对自己感兴趣的广播进行注册，这样当有相应的广播发出时，广播接收器就能够收到该广播，并在内部处理相应的逻辑。注册广播的方式一般有两种，在代码中注册和在AndroidManifest.xml中注册，其中前者也被称为动态注册，后者也被称为静态注册。
> 那么该如何创建一个广播接收器呢？其实只需要新建一个类，让它继承自BroadcastReceiver ，并重写父类的onReceive() 方法就行了。这样当有广播到来时，onReceive() 方法就会得到执行，具体的逻辑就可以在这个方法中处理。
````java
intentFilter = new IntentFilter();
intentFilter.addAction("android.net.conn.CONNECTIVITY_CHANGE");
networkChangeReceiver = new NetworkChangeReceiver();
registerReceiver(networkChangeReceiver, intentFilter);
````
> 可以看到，我们在MainActivity中定义了一个内部类NetworkChangeReceiver ，这个类是继承自BroadcastReceiver 的，并重写了父类的onReceive() 方法。这样每当网络状态发生变化时，onReceive() 方法就会得到执行，这里只是简单地使用Toast提示了一段文本信息。
> 然后观察onCreate() 方法，首先我们创建了一个IntentFilter 的实例，并给它添加了一个值为android.net.conn.CONNECTIVITY_CHANGE 的action，为什么要添加这个值呢？因为当网络状态发生变化时，系统发出的正是一条值为android.net.conn.CONNECTIVITY_CHANGE 的广播，也就是说我们的广播接收器想要监听什么广播，就在这里添加相应的action。接下来创建了一个NetworkChangeReceiver 的实例，然后调用registerReceiver() 方法进行注册，将NetworkChangeReceiver 的实例和IntentFilter 的实例都传了进去，这样NetworkChangeReceiver 就会收到所有值为android.net.conn.CONNECTIVITY_CHANGE 的广播，也就实现了监听网络变化的功能。
> 最后要记得，动态注册的广播接收器一定都要取消注册才行，这里我们是在onDestroy() 方法中通过调用unregisterReceiver() 方法来实现的。
> 在onReceive() 方法中，首先通过getSystemService() 方法得到了ConnectivityManager 的实例，这是一个系统服务类，专门用于管理网络连接的。然后调用它的getActiveNetworkInfo() 方法可以得到NetworkInfo 的实例，接着调用NetworkInfo 的isAvailable() 方法，就可以判断出当前是否有网络了，最后我们还是通过Toast的方式对用户进行提示。
> 另外，这里有非常重要的一点需要说明，Android系统为了保护用户设备的安全和隐私，做了严格的规定：如果程序需要进行一些对用户来说比较敏感的操作，就必须在配置文件中声明权限才可以，否则程序将会直接崩溃。比如这里访问系统的网络状态就是需要声明权限的。打开AndroidManifest.xml文件，在里面加入如下权限就可以访问系统网络状态了

### 5.2.2　静态注册实现开机启动
> 动态注册的广播接收器可以自由地控制注册与注销，在灵活性方面有很大的优势，但是它也存在着一个缺点，即必须要在程序启动之后才能接收到广播，因为注册的逻辑是写在onCreate() 方法中的。那么有没有什么办法可以让程序在未启动的情况下就能接收到广播呢？这就需要使用静态注册的方式了。
> 这里我们准备让程序接收一条开机广播，当收到这条广播时就可以在 onReceive() 方法里执行相应的逻辑，从而实现开机启动的功能。可以使用 Android Studio 提供的快捷方式来创建一个广播接收器，右击 com.example.broadcasttest 包 → New → Other → Broadcast Receiver
> 这里我们将广播接收器命名为BootCompleteReceiver， Exported 属性表示是否允许这个广播接收器接收本程序以外的广播，Enabled 属性表示是否启用这个广播接收器。勾选这两个属性，点击Finish完成创建。
> 静态的广播接收器一定要在AndroidManifest.xml文件中注册才可以使用，不过由于我们是使用Android Studio的快捷方式创建的广播接收器，因此注册这一步已经被自动完成了。
> <application> 标签内出现了一个新的标签<receiver> ，所有静态的广播接收器都是在这里进行注册的。它的用法其实和<activity> 标签非常相似，也是通过android:name 来指定具体注册哪一个广播接收器，而enabled 和exported 属性则是根据我们刚才勾选的状态自动生成的。
````xml
<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
<uses-permission android:name="android.permission.RECEIVE_BOOT_COMPLETED" />
<receiver
    android:name=".BootCompleteReceiver"
    android:enabled="true"
    android:exported="true">
    <intent-filter>
        <action android:name="android.intent.action.BOOT_COMPLETED" />
    </intent-filter>
</receiver>
````
> 我们在广播接收器的onReceive() 方法中都只是简单地使用Toast提示了一段文本信息，当你真正在项目中使用到它的时候，就可以在里面编写自己的逻辑。需要注意的是，不要在onReceive() 方法中添加过多的逻辑或者进行任何的耗时操作，因为在广播接收器中是不允许开启线程的，当onReceive() 方法运行了较长时间而没有结束时，程序就会报错。因此广播接收器更多的是扮演一种打开程序其他组件的角色，比如创建一条状态栏通知，或者启动一个服务等

### 5.3.1　发送标准广播
> 我们在按钮的点击事件里面加入了发送自定义广播的逻辑。首先构建出了一个Intent 对象，并把要发送的广播的值传入，然后调用了Context的sendBroadcast() 方法将广播发送出去，这样所有监听com.example.broadcasttest.MY_BROADCAST 这条广播的广播接收器就会收到消息。此时发出去的广播就是一条标准广播。
````java
Intent intent = new 
Intent("com.example.broadcasttest.MY_BROADCAST");
sendBroadcast(intent);
````
> 这样我们就成功完成了发送自定义广播的功能。另外，由于广播是使用Intent进行传递的，因此你还可以在Intent中携带一些数据传递给广播接收器。

### 5.3.2　发送有序广播
> 广播是一种可以跨进程的通信方式，这一点从前面接收系统广播的时候就可以看出来了。因此在我们应用程序内发出的广播，其他的应用程序应该也是可以收到的。
> 发送有序广播只需要改动一行代码，即将 sendBroadcast() 方法改成 sendOrderedBroadcast() 方法。 sendOrderedBroadcast() 方法接收两个参数，第一个参数仍然是 Intent ，第二个参数是一个与权限相关的字符串，这里传入null 就行了。
````xml
<intent-filter android:priority="100">
    <action android:name="com.example.broadcasttest.MY_BROADCAST" />
</intent-filter>
````
> 我们通过android:priority 属性给广播接收器设置了优先级，优先级比较高的广播接收器就可以先收到广播。这里将MyBroadcastReceiver的优先级设成了100，以保证它一定会在AnotherBroadcastReceiver之前收到广播。
> 如果在onReceive() 方法中调用了abortBroadcast() 方法，就表示将这条广播截断，后面的广播接收器将无法再接收到这条广播。现在重新运行程序，并点击一下Send Broadcast按钮，你会发现，只有MyBroadcastReceiver中的Toast信息能够弹出，说明这条广播经过MyBroadcastReceiver之后确实是终止传递了。

## 5.4　使用本地广播
> 前面我们发送和接收的广播全部属于系统全局广播，即发出的广播可以被其他任何应用程序接收到，并且我们也可以接收来自于其他任何应用程序的广播。这样就很容易引起安全性的问题，比如说我们发送的一些携带关键性数据的广播有可能被其他的应用程序截获，或者其他的程序不停地向我们的广播接收器里发送各种垃圾广播。
> 为了能够简单地解决广播的安全性问题， Android 引入了一套本地广播机制，使用这个机制发出的广播只能够在应用程序的内部进行传递，并且广播接收器也只能接收来自本应用程序发出的广播，这样所有的安全性问题就都不存在了。
> 本地广播的用法并不复杂，主要就是使用了一个 LocalBroadcastManager 来对广播进行管理，并提供了发送广播和注册广播接收器的方法。
> 有没有感觉这些代码很熟悉？没错，其实这基本上就和我们前面所学的动态注册广播接收器以及发送广播的代码是一样的。只不过现在首先是通过 LocalBroadcastManager 的 getInstance() 方法得到了它的一个实例，然后在注册广播接收器的时候调用的是 LocalBroadcastManager 的 registerReceiver() 方法，在发送广播的时候调用的是 LocalBroadcastManager 的 sendBroadcast() 方法，仅此而已。这里我们在按钮的点击事件里面发出了一条 com.example.broadcasttest.LOCAL_BROADCAST 广播，然后在 LocalReceiver 里去接收这条广播。

## 第 6 章　数据存储全方案——详解持久化技术
### 6.1　持久化技术简介
> 数据持久化就是指将那些内存中的瞬时数据保存到存储设备中，保证即使在手机或电脑关机的情况下，这些数据仍然不会丢失。保存在内存中的数据是处于瞬时状态的，而保存在存储设备中的数据是处于持久状态的，持久化技术则提供了一种机制可以让数据在瞬时状态和持久状态之间进行转换。
> 持久化技术被广泛应用于各种程序设计的领域当中，而本书中要探讨的自然是Android中的数据持久化技术。Android系统中主要提供了3种方式用于简单地实现数据持久化功能，即文件存储、SharedPreferences存储以及数据库存储。当然，除了这3种方式之外，你还可以将数据保存在手机的SD卡中，不过使用文件、SharedPreferences或数据库来保存数据会相对更简单一些，而且比起将数据保存在SD卡中会更加地安全。

### 6.2　文件存储
> 文件存储是Android中最基本的一种数据存储方式，它不对存储的内容进行任何的格式化处理，所有数据都是原封不动地保存到文件当中的，因而它比较适合用于存储一些简单的文本数据或二进制数据。如果你想使用文件存储的方式来保存一些较为复杂的文本数据，就需要定义一套自己的格式规范，这样可以方便之后将数据从文件中重新解析出来。

### 6.2.1　将数据存储到文件中
> `Context` 类中提供了一个 `openFileOutput()`  方法，可以用于将数据存储到指定的文件中。这个方法接收两个参数，第一个参数是文件名，在文件创建的时候使用的就是这个名称，注意这里指定的文件名不可以包含路径，因为所有的文件都是默认存储到/data/data/<package name>/files/目录下的。第二个参数是文件的操作模式，主要有两种模式可选， `MODE_PRIVATE` 和 `MODE_APPEND` 。其中 `MODE_PRIVATE` 是默认的操作模式，表示当指定同样文件名的时候，所写入的内容将会覆盖原文件中的内容，而 `MODE_APPEND` 则表示如果该文件已存在，就往文件里面追加内容，不存在就创建新文件。其实文件的操作模式本来还有另外两种： `MODE_WORLD_READABLE` 和 `MODE_WORLD_WRITEABLE` ，这两种模式表示允许其他的应用程序对我们程序中的文件进行读写操作，不过由于这两种模式过于危险，很容易引起应用的安全性漏洞，已在 Android  4.2版本中被废弃。
> `openFileOutput()` 方法返回的是一个 `FileOutputStream`  对象，得到了这个对象之后就可以使用Java流的方式将数据写入到文件中了。
> 如果你已经比较熟悉Java流了，理解上面的代码一定轻而易举吧。这里通过 `openFileOutput()`  方法能够得到一个 `FileOutputStream`  对象，然后再借助它构建出一个 `OutputStreamWriter`  对象，接着再使用 `OutputStreamWriter`  构建出一个 `BufferedWriter`  对象，这样你就可以通过 `BufferedWriter`  来将文本内容写入到文件中了。
> 那么如何才能证实数据确实已经保存成功了呢？我们可以借助 Android Device Monitor工具来查看一下。点击 Android Studio导航栏中的 Tools→ Android，点击 Android Device Monitor就可以打开 Android Device Monitor工具了，然后进入 File Explorer标签页，在这里找到/data/data/com.example.filepersistencetest/files/目录，可以看到生成了一个data文件，如图6.3所示。（注： Android 7.0系统的模拟器可能无法正常查看 File Explorer中的内容，这或许是新版模拟器的一个bug，可能会在未来的版本中修复。如果你遇到了这种情况，创建一个 Android 6.0系统的模拟器即可解决。）
````java
public void save(String inputText) {
    FileOutputStream out = null;
    BufferedWriter writer = null;
    try {
        out = openFileOutput("data", Context.MODE_PRIVATE);
        writer = new BufferedWriter(new OutputStreamWriter(out));
        writer.write(inputText);
    } catch (IOException e) {
        e.printStackTrace();
    } finally {
        try {
            if (writer != null) {
                writer.close();
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
````

### 6.2.2　从文件中读取数据
> 类似于将数据存储到文件中， `Context`  类中还提供了一个 `openFileInput()`  方法，用于从文件中读取数据。这个方法要比 `openFileOutput()`  简单一些，它只接收一个参数，即要读取的文件名，然后系统会自动到/data/data/<package name>/files/目录下去加载这个文件，并返回一个 `FileInputStream`  对象，得到了这个对象之后再通过Java流的方式就可以将数据读取出来了。
> 在这段代码中，首先通过 `openFileInput()`  方法获取到了一个 `FileInputStream`  对象，然后借助它又构建出了一个 `InputStreamReader`  对象，接着再使用 `InputStreamReader`  构建出一个 `BufferedReader`  对象，这样我们就可以通过 `BufferedReader`  进行一行行地读取，把文件中所有的文本内容全部读取出来，并存放在一个 `StringBuilder`  对象中，最后将读取到的内容返回就可以了。
````java
public String load() {
    FileInputStream in = null;
    BufferedReader reader = null;
    StringBuilder content = new StringBuilder();
    try {
        in = openFileInput("data");
        reader = new BufferedReader(new InputStreamReader(in));
        String line = "";
        while ((line = reader.readLine()) != null) {
            content.append(line);
        }
    } catch (IOException e) {
        e.printStackTrace();
    } finally {
        if (reader != null) {
            try {
                reader.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
    return content.toString();
}
````

## 6.3　SharedPreferences存储
> 不同于文件的存储方式， `SharedPreferences` 是使用键值对的方式来存储数据的。也就是说，当保存一条数据的时候，需要给这条数据提供一个对应的键，这样在读取数据的时候就可以通过这个键把相应的值取出来。而且 `SharedPreferences` 还支持多种不同的数据类型存储，如果存储的数据类型是整型，那么读取出来的数据也是整型的；如果存储的数据是一个字符串，那么读取出来的数据仍然是字符串。
> 要想使用 `SharedPreferences` 来存储数据，首先需要获取到 `SharedPreferences`  对象。Android中主要提供了3种方法用于得到 `SharedPreferences`  对象。
> - Context 类中的 `getSharedPreferences()`  方法
> 此方法接收两个参数，第一个参数用于指定 `SharedPreferences` 文件的名称，如果指定的文件不存在则会创建一个， `SharedPreferences` 文件都是存放在/data/data/<package name>/shared_prefs/目录下的。第二个参数用于指定操作模式，目前只有 `MODE_PRIVATE` 这一种模式可选，它是默认的操作模式，和直接传入0效果是相同的，表示只有当前的应用程序才可以对这个 `SharedPreferences` 文件进行读写。其他几种操作模式均已被废弃， `MODE_WORLD_READABLE` 和 `MODE_WORLD_WRITEABLE` 这两种模式是在Android 4.2版本中被废弃的， `MODE_MULTI_PROCESS` 模式是在Android 6.0版本中被废弃的。
> - Activity 类中的 `getPreferences()`  方法
> 这个方法和 `Context` 中的 `getSharedPreferences()`  方法很相似，不过它只接收一个操作模式参数，因为使用这个方法时会自动将当前活动的类名作为 `SharedPreferences` 的文件名。
> -  `PreferenceManager`  类中的 `getDefaultSharedPreferences()`  方法
> 这是一个静态方法，它接收一个 `Context`  参数，并自动使用当前应用程序的包名作为前缀来命名 `SharedPreferences` 文件。
> 得到了 `SharedPreferences`  对象之后，就可以开始向 `SharedPreferences` 文件中存储数据了，主要可以分为3步实现。
> - (1) 调用 `SharedPreferences`  对象的 `edit()`  方法来获取一个 `SharedPreferences.Editor`  对象。
> - (2) 向 `SharedPreferences.Editor`  对象中添加数据，比如添加一个布尔型数据就使用 `putBoolean()`  方法，添加一个字符串则使用 `putString()`  方法，以此类推。
> - (3) 调用 `apply()`  方法将添加的数据提交，从而完成数据存储操作。
````java
public void onClick(View v) {
    SharedPreferences.Editor editor = getSharedPreferences("data",
        MODE_PRIVATE).edit();
    editor.putString("name", "Tom");
    editor.putInt("age", 28);
    editor.putBoolean("married", false);
    editor.apply();
}
````
> 可以看到，这里首先给按钮注册了一个点击事件，然后在点击事件中通过 `getSharedPreferences()`  方法指定 `SharedPreferences` 的文件名为data，并得到了 `SharedPreferences.Editor`  对象。接着向这个对象中添加了3条不同类型的数据，最后调用 `apply()`  方法进行提交，从而完成了数据存储的操作。

### 6.3.2　从SharedPreferences中读取数据
> 你应该已经感觉到了，使用 `SharedPreferences` 来存储数据是非常简单的，不过下面还有更好的消息，其实从 `SharedPreferences` 文件中读取数据会更加地简单。 `SharedPreferences`  对象中提供了一系列的 `get`  方法，用于对存储的数据进行读取，每种 `get`  方法都对应了 `SharedPreferences.Editor`  中的一种 `put`  方法，比如读取一个布尔型数据就使用 `getBoolean()`  方法，读取一个字符串就使用 `getString()`  方法。这些 `get`  方法都接收两个参数，第一个参数是键，传入存储数据时使用的键就可以得到相应的值了；第二个参数是默认值，即表示当传入的键找不到对应的值时会以什么样的默认值进行返回。
````java
public void onClick(View v) {
    SharedPreferences pref = getSharedPreferences("data", MODE_PRIVATE);
    String name = pref.getString("name", "");
    int age = pref.getInt("age", 0);
    boolean married = pref.getBoolean("married", false);
    Log.d("MainActivity", "name is " + name);
    Log.d("MainActivity", "age is " + age);
    Log.d("MainActivity", "married is " + married);
}
````

## 6.4　SQLite数据库存储
> SQLite是一款轻量级的关系型数据库，它的运算速度非常快，占用资源很少，通常只需要几百KB的内存就足够了，因而特别适合在移动设备上使用。SQLite不仅支持标准的SQL语法，还遵循了数据库的ACID事务，所以只要你以前使用过其他的关系型数据库，就可以很快地上手SQLite。而SQLite又比一般的数据库要简单得多，它甚至不用设置用户名和密码就可以使用。Android正是把这个功能极为强大的数据库嵌入到了系统当中，使得本地持久化的功能有了一次质的飞跃。
> 前面我们所学的文件存储和SharedPreferences存储毕竟只适用于保存一些简单的数据和键值对，当需要存储大量复杂的关系型数据的时候，你就会发现以上两种存储方式很难应付得了。比如我们手机的短信程序中可能会有很多个会话，每个会话中又包含了很多条信息内容，并且大部分会话还可能各自对应了电话簿中的某个联系人。很难想象如何用文件或者SharedPreferences来存储这些数据量大、结构性复杂的数据吧？但是使用数据库就可以做得到。那么我们就赶快来看一看，Android中的SQLite数据库到底是如何使用的。

### 6.4.1　创建数据库
> Android为了让我们能够更加方便地管理数据库，专门提供了一个 `SQLiteOpenHelper` 帮助类，借助这个类就可以非常简单地对数据库进行创建和升级。既然有好东西可以直接使用，那我们自然要尝试一下了，下面我就对 `SQLiteOpenHelper` 的基本用法进行介绍。
> 首先你要知道 `SQLiteOpenHelper` 是一个抽象类，这意味着如果我们想要使用它的话，就需要创建一个自己的帮助类去继承它。 `SQLiteOpenHelper` 中有两个抽象方法，分别是 `onCreate()`  和 `onUpgrade()`  ，我们必须在自己的帮助类里面重写这两个方法，然后分别在这两个方法中去实现创建、升级数据库的逻辑。
>  `SQLiteOpenHelper` 中还有两个非常重要的实例方法： `getReadableDatabase()`  和 `getWritableDatabase()`  。这两个方法都可以创建或打开一个现有的数据库（如果数据库已存在则直接打开，否则创建一个新的数据库），并返回一个可对数据库进行读写操作的对象。不同的是，当数据库不可写入的时候（如磁盘空间已满）， `getReadableDatabase()`  方法返回的对象将以只读的方式去打开数据库，而 `getWritableDatabase()`  方法则将出现异常。
>  `SQLiteOpenHelper` 中有两个构造方法可供重写，一般使用参数少一点的那个构造方法即可。这个构造方法中接收4个参数，第一个参数是 `Context` ，这个没什么好说的，必须要有它才能对数据库进行操作。第二个参数是数据库名，创建数据库时使用的就是这里指定的名称。第三个参数允许我们在查询数据的时候返回一个自定义的 `Cursor` ，一般都是传入 `null`  。第四个参数表示当前数据库的版本号，可用于对数据库进行升级操作。构建出 `SQLiteOpenHelper` 的实例之后，再调用它的 `getReadableDatabase()`  或 `getWritableDatabase()`  方法就能够创建数据库了，数据库文件会存放在/data/data/<package name>/databases/目录下。此时，重写的 `onCreate()`  方法也会得到执行，所以通常会在这里去处理一些创建表的逻辑。
> SQLite不像其他的数据库拥有众多繁杂的数据类型，它的数据类型很简单，integer 表示整型，real 表示浮点型，text 表示文本类型，blob 表示二进制类型。另外，上述建表语句中我们还使用了primary key 将id 列设为主键，并用autoincrement 关键字表示id 列是自增长的。
````java
public class MyDatabaseHelper extends SQLiteOpenHelper {

    public static final String CREATE_BOOK = "create table Book ("
            + "id integer primary key autoincrement, "
            + "author text, "
            + "price real, "
            + "pages integer, "
            + "name text)";

    private Context mContext;

    public MyDatabaseHelper(Context context, String name,
                            SQLiteDatabase.CursorFactory factory, int version) {
        super(context, name, factory, version);
        mContext = context;
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        db.execSQL(CREATE_BOOK);
        Toast.makeText(mContext, "Create succeeded", Toast.LENGTH_SHORT).show();
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
    }

}
// using
public class MainActivity extends AppCompatActivity {
    private MyDatabaseHelper dbHelper;
...
    public void onClick(View v) {
        dbHelper.getWritableDatabase();
    }
}
````
> 这里我们在 `onCreate()`  方法中构建了一个 `MyDatabaseHelper`  对象，并且通过构造函数的参数将数据库名指定为 `BookStore.db` ，版本号指定为1，然后在Create database按钮的点击事件里调用了 `getWritableDatabase()`  方法。这样当第一次点击Create database按钮时，就会检测到当前程序中并没有 `BookStore.db` 这个数据库，于是会创建该数据库并调用 `MyDatabaseHelper` 中的 `onCreate()`  方法，这样Book表也就得到了创建，然后会弹出一个Toast提示创建成功。再次点击Create database按钮时，会发现此时已经存在 `BookStore.db` 数据库了，因此不会再创建一次。
> 怎样才能证实它们的确创建成功了？如果还是使用File Explorer，那么最多你只能看到databases目录下出现了一个BookStore.db文件，Book表是无法通过File Explorer看到的。因此这次我们准备换一种查看方式，使用adb shell来对数据库和表的创建情况进行检查。
> adb是Android SDK中自带的一个调试工具，使用这个工具可以直接对连接在电脑上的手机或模拟器进行调试操作。它存放在sdk的platform-tools目录下，如果想要在命令行中使用这个工具，就需要先把它的路径配置到环境变量里。
> 如果你使用的是Windows系统，可以右击计算机→属性→高级系统设置→环境变量，然后在系统变量里找到Path并点击编辑，将platform-tools目录配置进去，如果你使用的是Linux或Mac系统，可以在home路径下编辑.bash_文件，将platform-tools目录配置进去即可，配置好了环境变量之后，就可以使用adb工具了。
> 打开命令行界面，输入adb shell ，就会进入到设备的控制台，接下来使用cd 命令进入到/data/data/com.example.databasetest/databases/目录下，并使用ls 命令查看到该目录里的文件
> 这个目录下出现了两个数据库文件，一个正是我们创建的BookStore.db，而另一个BookStore.db-journal则是为了让数据库能够支持事务而产生的临时日志文件，通常情况下这个文件的大小都是0字节。
> 接下来我们就要借助sqlite 命令来打开数据库了，只需要键入sqlite3，后面加上数据库名即可
> 这时就已经打开了BookStore.db数据库，现在就可以对这个数据库中的表进行管理了。首先来看一下目前数据库中有哪些表，键入.table 命令
> 可以看到，此时数据库中有两张表，android_metadata 表是每个数据库中都会自动生成的，不用管它，而另外一张Book表就是我们在MyDatabaseHelper中创建的了。这里还可以通过.schema 命令来查看它们的建表语句
> 由此证明，BookStore.db数据库和Book表确实已经创建成功了。之后键入.exit 或.quit 命令可以退出数据库的编辑，再键入exit 命令就可以退出设备控制台了。

### 6.4.2　升级数据库
> 如果你足够细心，一定会发现MyDatabaseHelper中还有一个空方法呢！没错，onUpgrade() 方法是用于对数据库进行升级的，它在整个数据库的管理工作当中起着非常重要的作用，可千万不能忽视它哟。
> 目前DatabaseTest项目中已经有一张Book表用于存放书的各种详细数据，如果我们想再添加一张Category表用于记录图书的分类，该怎么做呢？
> 比如Category表中有id （主键）、分类名和分类代码这几个列，那么建表语句就可以写成：
````sqllite
create table Category (
    id integer primary key autoincrement,
    category_name text,
    category_code integer)
````
````java
public class MyDatabaseHelper extends SQLiteOpenHelper {

	@Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL("drop table if exists Book");
        db.execSQL("drop table if exists Category");
        onCreate(db);
    }
}
````
> 接下来的问题就是如何让onUpgrade() 方法能够执行了，还记得SQLiteOpenHelper的构造方法里接收的第四个参数吗？它表示当前数据库的版本号，之前我们传入的是1，现在只要传入一个比1大的数，就可以让onUpgrade() 方法得到执行了。
````java
dbHelper = new MyDatabaseHelper(this, "BookStore.db", null, 2);
dbHelper.getWritableDatabase();
````

### 6.4.3　添加数据
> 现在你已经掌握了创建和升级数据库的方法，接下来就该学习一下如何对表中的数据进行操作了。其实我们可以对数据进行的操作无非有4种，即CRUD。其中C代表添加（Create），R代表查询（Retrieve），U代表更新（Update），D代表删除（Delete）。每一种操作又各自对应了一种SQL命令，如果你比较熟悉SQL语言的话，一定会知道添加数据时使用insert ，查询数据时使用select ，更新数据时使用update ，删除数据时使用delete 。但是开发者的水平总会是参差不齐的，未必每一个人都能非常熟悉地使用SQL语言，因此Android也提供了一系列的辅助性方法，使得在Android中即使不去编写SQL语句，也能轻松完成所有的CRUD操作。
> 前面我们已经知道，调用SQLiteOpenHelper的getReadableDatabase() 或getWritableDatabase() 方法是可以用于创建和升级数据库的，不仅如此，这两个方法还都会返回一个SQLiteDatabase 对象，借助这个对象就可以对数据进行CRUD操作了。
> 那么下面我们首先学习一下如何向数据库的表中添加数据吧。SQLiteDatabase 中提供了一个insert() 方法，这个方法就是专门用于添加数据的。它接收3个参数，第一个参数是表名，我们希望向哪张表里添加数据，这里就传入该表的名字。第二个参数用于在未指定添加数据的情况下给某些可为空的列自动赋值NULL ，一般我们用不到这个功能，直接传入null 即可。第三个参数是一个ContentValues 对象，它提供了一系列的put() 方法重载，用于向ContentValues 中添加数据，只需要将表中的每个列名以及相应的待添加数据传入即可。
````java
public void onClick(View v) {
    SQLiteDatabase db = dbHelper.getWritableDatabase();
    ContentValues values = new ContentValues();
    // 开始组装第一条数据
    values.put("name", "The Da Vinci Code");
    values.put("author", "Dan Brown");
    values.put("pages", 454);
    values.put("price", 16.96);
    db.insert("Book", null, values); // 插入第一条数据
    values.clear();
    // 开始组装第二条数据
    values.put("name", "The Lost Symbol");
    values.put("author", "Dan Brown");
    values.put("pages", 510);
    values.put("price", 19.95);
    db.insert("Book", null, values); // 插入第二条数据
}
````
> 在添加数据按钮的点击事件里面，我们先获取到了SQLiteDatabase 对象，然后使用ContentValues 来对要添加的数据进行组装。如果你比较细心的话应该会发现，这里只对Book表里其中四列的数据进行了组装，id那一列并没给它赋值。这是因为在前面创建表的时候，我们就将id 列设置为自增长了，它的值会在入库的时候自动生成，所以不需要手动给它赋值了。接下来调用了insert() 方法将数据添加到表当中，注意这里我们实际上添加了两条数据，上述代码中使用ContentValues 分别组装了两次不同的内容，并调用了两次insert() 方法。

### 6.4.4　更新数据
````java
public void onClick(View v) {
    SQLiteDatabase db = dbHelper.getWritableDatabase();
    ContentValues values = new ContentValues();
    values.put("price", 10.99);
    db.update("Book", values, "name = ?", new String[] { "The Da Vinci
        Code" });
}
````
> 这里在更新数据按钮的点击事件里面构建了一个ContentValues 对象，并且只给它指定了一组数据，说明我们只是想把价格这一列的数据更新成10.99。然后调用了SQLiteDatabase 的update() 方法去执行具体的更新操作，可以看到，这里使用了第三、第四个参数来指定具体更新哪几行。第三个参数对应的是SQL语句的where 部分，表示更新所有name 等于? 的行，而? 是一个占位符，可以通过第四个参数提供的一个字符串数组为第三个参数中的每个占位符指定相应的内容。因此上述代码想表达的意图是将名字是The Da Vinci Code的这本书的价格改成10.99。

### 6.4.5　删除数据
> 删除数据对你来说应该就更简单了，因为它所需要用到的知识点你全部已经学过了。SQLiteDatabase 中提供了一个delete() 方法，专门用于删除数据，这个方法接收3个参数，第一个参数仍然是表名，这个已经没什么好说的了，第二、第三个参数又是用于约束删除某一行或某几行的数据，不指定的话默认就是删除所有行。
````java
public void onClick(View v) {
    SQLiteDatabase db = dbHelper.getWritableDatabase();
    db.delete("Book", "pages > ?", new String[] { "500" });
}
````
````markdown
|---------------------|------------------------|---------------------|
| --query()方法参数-- |    --对应SQL部分--     |       --描述--      |
|---------------------|------------------------|---------------------|
| table               | from table_name        | 指定查询的表名      |
|---------------------|------------------------|---------------------|
| columns             | select column1,column2 | 指定查询的列名      |
|---------------------|------------------------|---------------------|
| selection           | where column = value   | 指定where的约束条件 |
|---------------------|------------------------|---------------------|
| selectionArgs       | -                      | 为where中的占位符   |
|                     |                        | 提供具体的值        |
|---------------------|------------------------|---------------------|
| groupBy             | group by column        | 指定group by的列    |
|---------------------|------------------------|---------------------|
| having              | having column = value  | 对group by 后       |
|                     |                        | 的结果进一步约束    |
|---------------------|------------------------|---------------------|
| orderBy             | order by column1,      | 指定查询结果的      |
|                     | column2                | 排序方式            |
|---------------------|------------------------|---------------------|
````
````java
public void onClick(View v) {
    SQLiteDatabase db = dbHelper.getWritableDatabase();
    // 查询Book表中所有的数据
    Cursor cursor = db.query("Book", null, null, null, null, null, null);
    if (cursor.moveToFirst()) {
        do {
            // 遍历Cursor对象，取出数据并打印
            String name = cursor.getString(cursor.getColumnIndex
                ("name"));
            String author = cursor.getString(cursor.getColumnIndex
                ("author"));
            int pages = cursor.getInt(cursor.getColumnIndex("pages"));
            double price = cursor.getDouble(cursor.getColumnIndex
                ("price"));
            Log.d("MainActivity", "book name is " + name);
            Log.d("MainActivity", "book author is " + author);
            Log.d("MainActivity", "book pages is " + pages);
            Log.d("MainActivity", "book price is " + price);
        } while (cursor.moveToNext());
    }
    cursor.close();
}
````
> 可以看到，我们首先在查询按钮的点击事件里面调用了SQLiteDatabase的query() 方法去查询数据。这里的query() 方法非常简单，只是使用了第一个参数指明去查询Book表，后面的参数全部为null 。这就表示希望查询这张表中的所有数据，虽然这张表中目前只剩下一条数据了。查询完之后就得到了一个Cursor 对象，接着我们调用它的moveToFirst() 方法将数据的指针移动到第一行的位置，然后进入了一个循环当中，去遍历查询到的每一行数据。在这个循环中可以通过Cursor 的getColumnIndex() 方法获取到某一列在表中对应的位置索引，然后将这个索引传入到相应的取值方法中，就可以得到从数据库中读取到的数据了。接着我们使用Log的方式将取出的数据打印出来，借此来检查一下读取工作有没有成功完成。最后别忘了调用close() 方法来关闭Cursor 。

### 6.4.7　使用SQL操作数据库
````java
// 添加数据的方法如下：
db.execSQL("insert into Book (name, author, pages, price) values(?, ?, ?, ?)", new String[] { "The Da Vinci Code", "Dan Brown", "454", "16.96" });
db.execSQL("insert into Book (name, author, pages, price) values(?, ?, ?, ?)", new String[] { "The Lost Symbol", "Dan Brown", "510", "19.95" });
// 更新数据的方法如下：
db.execSQL("update Book set price = ? where name = ?", new String[] { "10.99", "The Da Vinci Code" });
// 删除数据的方法如下：
db.execSQL("delete from Book where pages > ?", new String[] { "500" });
// 查询数据的方法如下：
db.rawQuery("select * from Book", null);
````

## 6.5　使用LitePal操作数据库
> [LitePal](https://github.com/LitePalFramework/LitePal) 是一款开源的Android数据库框架，它采用了对象关系映射（ORM）的模式，并将我们平时开发最常用到的一些数据库功能进行了封装，使得不用编写一行SQL语句就可以完成各种建表和増删改查的操作。
> 那么怎样才能在项目中使用开源库呢？过去的方式比较复杂，通常需要下载开源库的Jar包或者源码，然后再集成到我们的项目当中。而现在就简单得多了，大多数的开源项目都会将版本提交到jcenter上，我们只需要在app/build.gradle文件中声明该开源库的引用就可以了。
> 因此，要使用LitePal的第一步，就是编辑app/build.gradle文件，在dependencies闭包中添加如下内容：
````xml
dependencies {
    compile fileTree(dir: 'libs', include: ['*.jar'])
    compile 'com.android.support:appcompat-v7:23.2.0'
    testCompile 'junit:junit:4.12'
    compile 'org.litepal.android:core:1.4.1'
}
````
> 这样我们就把LitePal成功引入到当前项目中了，接下来需要配置litepal.xml文件。右击app/src/main目录→New→Directory，创建一个assets目录，然后在assets目录下再新建一个litepal.xml文件，接着编辑litepal.xml文件中的内容，如下所示：
````xml
<?xml version="1.0" encoding="utf-8"?>
<litepal>
    <dbname value="BookStore" ></dbname>
    <version value="1" ></version>

    <list>
    </list>
</litepal>
````
> 其中，<dbname> 标签用于指定数据库名，<version> 标签用于指定数据库版本号，<list> 标签用于指定所有的映射模型，我们稍后就会用到。
> 最后还需要再配置一下LitePalApplication，修改AndroidManifest.xml中的代码，如下所示：
````xml
<manifest xmlns:android="http://schemas.android.com/apk/res/android"
    package="com.example.litepaltest">
    <application
        android:name="org.litepal.LitePalApplication"
        android:allowBackup="true"
        android:icon="@mipmap/ic_launcher"
        android:label="@string/app_name"
        android:supportsRtl="true"
        android:theme="@style/AppTheme">
        ...
    </application>
</manifest>
````
> 这里我们将项目的application 配置为org.litepal.LitePalApplication ，这样才能让LitePal的所有功能都可以正常工作。

### 6.5.3　创建和升级数据库
> 这是一个典型的Java bean，在Book 类中我们定义了id 、author 、price 、pages 、name 这几个字段，并生成了相应的getter 和setter 方法。
> *生成getter 和setter 方法的快捷方式是，先将类中的字段定义好，然后按下Alt + Insert键（Mac系统是command + N），在弹出菜单中选择Getter and Setter，接着使用Shift键将所有字段都选中，最后点击OK。*
> 接下来我们还需要将Book 类添加到映射模型列表当中，修改litepal.xml中的代码，如下所示：
````xml
<litepal>
    <dbname value="BookStore" ></dbname>

    <version value="1" ></version>

    <list>
        <mapping class="com.example.litepaltest.Book"></mapping>
    </list>
</litepal>
````
> 这里使用<mapping> 标签来声明我们要配置的映射模型类，注意一定要使用完整的类名。不管有多少模型类需要映射，都使用同样的方式配置在<list> 标签下即可。
> 6.4.2节中我们体验了使用SQLiteOpenHelper来升级数据库的方式，虽说功能是实现了，但你有没有发现一个问题，就是升级数据库的时候我们需要先把之前的表drop掉，然后再重新创建才行。这其实是一个非常严重的问题，因为这样会造成数据丢失，每当升级一次数据库，之前表中的数据就全没了。
> 当然如果你是非常有经验的程序员，也可以通过复杂的逻辑控制来避免这种情况，但是维护成本很高。而有了LitePal，这些就都不再是问题了，使用LitePal来升级数据库非常非常简单，你完全不用思考任何的逻辑，只需要改你想改的任何内容，然后将版本号加1就行了。

### 6.5.4　使用LitePal添加数据
> 首先回顾一下之前添加数据的方法，我们需要创建出一个ContentValues 对象，然后将所有要添加的数据put到这个ContentValues 对象当中，最后再调用SQLiteDatabase的insert() 方法将数据添加到数据库表当中。
> 而使用LitePal来添加数据，这些操作可以简单到让你惊叹！我们只需要创建出模型类的实例，再将所有要存储的数据设置好，最后调用一下save() 方法就可以了。
> 下面开始来动手实现，观察现有的模型类，你会发现它们都是没有继承结构的。没错，因为LitePal进行表管理操作时不需要模型类有任何的继承结构，但是进行CRUD操作时就不行了，必须要继承自DataSupport 类才行，因此这里我们需要先把继承结构给加上。修改Book 类中的代码，如下所示：
````java
public class Book extends DataSupport {
    ...
}
// add new book
public class MainActivity extends AppCompatActivity {
	...
	public void onClick(View v) {
        Book book = new Book();
        book.setName("The Da Vinci Code");
        book.setAuthor("Dan Brown");
        book.setPages(454);
        book.setPrice(16.96);
        book.setPress("Unknow");
        book.save();
    }
}
````

### 6.5.5　使用LitePal更新数据
> 首先，最简单的一种更新方式就是对已存储的对象重新设值，然后重新调用save() 方法即可。那么这里我们就要了解一个概念，什么是已存储的对象？
> 对于LitePal来说，对象是否已存储就是根据调用model.isSaved() 方法的结果来判断的，返回true 就表示已存储，返回false 就表示未存储。那么接下来的问题就是，什么情况下会返回true ，什么情况下会返回false 呢？
> 实际上只有在两种情况下model.isSaved() 方法才会返回true ，一种情况是已经调用过model.save() 方法去添加数据了，此时model 会被认为是已存储的对象。另一种情况是model 对象是通过LitePal提供的查询API查出来的，由于是从数据库中查到的对象，因此也会被认为是已存储的对象。
````java
// 对已存储的对象进行操作
public void onClick(View v) {
    Book book = new Book();
    book.setName("The Lost Symbol");
    book.setAuthor("Dan Brown");
    book.setPages(510);
    book.setPrice(19.95);
    book.setPress("Unknow");
    book.save();
    book.setPrice(10.99);
    book.save();
}
// 
public void onClick(View v) {
    Book book = new Book();
    book.setPrice(14.95);
    book.setPress("Anchor");
    book.updateAll("name = ? and author = ?", "The Lost Symbol", "Dan
        Brown");
}
````
> 可以看到，这里我们首先new出了一个Book的实例，然后直接调用setPrice() 和setPress() 方法来设置要更新的数据，最后再调用updateAll() 方法去执行更新操作。注意updateAll() 方法中可以指定一个条件约束，和SQLiteDatabase中update() 方法的where 参数部分有点类似，但更加简洁，如果不指定条件语句的话，就表示更新所有数据。这里我们指定将所有书名是The Lost Symbol并且作者是Dan Brown的书价格更新为14.95，出版社更新为Anchor。
> 可以看到，这里我们首先new出了一个Book的实例，然后直接调用setPrice() 和setPress() 方法来设置要更新的数据，最后再调用updateAll() 方法去执行更新操作。注意updateAll() 方法中可以指定一个条件约束，和SQLiteDatabase中update() 方法的where 参数部分有点类似，但更加简洁，如果不指定条件语句的话，就表示更新所有数据。这里我们指定将所有书名是The Lost Symbol并且作者是Dan Brown的书价格更新为14.95，出版社更新为Anchor。
> 在Java中任何一种数据类型的字段都会有默认值，例如int 类型的默认值是0，boolean 类型的默认值是false ，String 类型的默认值是null 。那么当new出一个Book 对象时，其实所有字段都已经被初识化成默认值了，比如说pages 字段的值就是0。因此，如果我们想把数据库表中的pages 列更新成0，直接调用book.setPages(0) 是不可以的，因为即使不调用这行代码，pages 字段本身也是0，LitePal此时是不会对这个列进行更新的。对于所有想要将为数据更新成默认值的操作，LitePal统一提供了一个setToDefault() 方法，然后传入相应的列名就可以实现了。
````java
Book book = new Book();
book.setToDefault("pages");
book.updateAll();
````
> 这段代码的意思是，将所有书的页数都更新为0，因为updateAll() 方法中没有指定约束条件，因此更新操作对所有数据都生效了。

### 6.5.6　使用LitePal删除数据
````java
public void onClick(View v) {
    DataSupport.deleteAll(Book.class, "price < ?", "15");
}
````

### 6.5.7　使用LitePal查询数据
````java
// 
Cursor cursor = db.query("Book", null, null, null, null, null, null);
// LitePal
List<Book> books = DataSupport.findAll(Book.class);
Book firstBook = DataSupport.findFirst(Book.class);
Book lastBook = DataSupport.findLast(Book.class);
// select() 方法用于指定查询哪几列的数据，对应了SQL当中的select 关键字
List<Book> books = DataSupport.select("name", "author").find(Book.class);
// where() 方法用于指定查询的约束条件，对应了SQL当中的where 关键字
List<Book> books = DataSupport.where("pages > ?", "400").find(Book.class);
// order() 方法用于指定结果的排序方式，对应了SQL当中的order by 关键字
List<Book> books = DataSupport.order("price desc").find(Book.class);
// limit() 方法用于指定查询结果的数量
List<Book> books = DataSupport.limit(3).find(Book.class);
// offset() 方法用于指定查询结果的偏移量
List<Book> books = DataSupport.limit(3).offset(1).find(Book.class);
// 连缀组合
List<Book> books = DataSupport.select("name", "author", "pages")
                              .where("pages > ?", "400")
                              .order("pages")
                              .limit(10)
                              .offset(10)
                              .find(Book.class);
// 用原生的SQL来进行查询
Cursor c = DataSupport.findBySQL("select * from Book where pages > ? and price < ?", "400",  "20");
````

## 第 7 章　跨程序共享数据——探究内容提供器
## 7.1　内容提供器简介
> 内容提供器（Content Provider）主要用于在不同的应用程序之间实现数据共享的功能，它提供了一套完整的机制，允许一个程序访问另一个程序中的数据，同时还能保证被访数据的安全性。目前，使用内容提供器是Android实现跨程序共享数据的标准方式。
> 不同于文件存储和SharedPreferences存储中的两种全局可读写操作模式，内容提供器可以选择只对哪一部分数据进行共享，从而保证我们程序中的隐私数据不会有泄漏的风险。

### 7.2.1　Android权限机制详解
> 这只是微信所申请的一半左右的权限，因为权限太多一屏截不下来。其中有一些权限我并不认可，比如微信为什么要读取我手机的短信和彩信？但是我不认可又能怎样，难道我拒绝安装微信？没错，这种例子比比皆是，当一些软件已经让我们产生依赖的时候就会容易 “店大欺客”，反正这个权限我就是要了，你自己看着办吧！
> Android开发团队当然也意识到了这个问题，于是在6.0系统中加入了运行时权限功能。也就是说，用户不需要在安装软件的时候一次性授权所有申请的权限，而是可以在软件的使用过程中再对某一项权限申请进行授权。比如说一款相机应用在运行时申请了地理位置定位权限，就算我拒绝了这个权限，但是我应该仍然可以使用这个应用的其他功能，而不是像之前那样直接无法安装它。
> 当然，并不是所有权限都需要在运行时申请，对于用户来说，不停地授权也很烦琐。Android现在将所有的权限归成了两类，一类是普通权限，一类是危险权限。准确地讲，其实还有第三类特殊权限，不过这种权限使用得很少，因此不在本书的讨论范围之内。普通权限指的是那些不会直接威胁到用户的安全和隐私的权限，对于这部分权限申请，系统会自动帮我们进行授权，而不需要用户再去手动操作了，比如在BroadcastTest项目中申请的两个权限就是普通权限。危险权限则表示那些可能会触及用户隐私或者对设备安全性造成影响的权限，如获取设备联系人信息、定位设备的地理位置等，对于这部分权限申请，必须要由用户手动点击授权才可以，否则程序就无法使用相应的功能。
> 但是Android中有一共有上百种权限，我们怎么从中区分哪些是普通权限，哪些是危险权限呢？其实并没有那么难，因为危险权限总共就那么几个，除了危险权限之外，剩余的就都是普通权限了。下表列出了Android中所有的危险权限，一共是9组24个权限。
````markdown
|------------|------------------------|
|  权限组名  |         权限名         |
|------------|------------------------|
| CALENDAR   | READ_CALENDAR          |
|            | WRITE_CALENDAR         |
|------------|------------------------|
| CAMERA     | CAMERA                 |
|------------|------------------------|
| CONTACTS   | READ_CONTACTS          |
|            | WRITE_CONTACTS         |
|            | GET_ACCOUNTS           |
|------------|------------------------|
| LOCATION   | ACCESS_FINE_LOCATION   |
|            | ACCESS_COARSE_LOCATION |
|------------|------------------------|
| MICROPHONE | RECORD_AUDIO           |
|------------|------------------------|
| PHONE      | READ_PHONE_STATE       |
|            | CALL_PHONE             |
|            | READ_CALL_LOG          |
|            | WRITE_CALL_LOG         |
|            | ADD_VOICEMAIL          |
|            | USE_SIP                |
|            | PROCESS_OUTGOING_CALLS |
|------------|------------------------|
| SENSORS    | BODY_SENSORS           |
|------------|------------------------|
| SMS        | SEND_SMS               |
|            | RECEIVE_SMS            |
|            | READ_SMS               |
|            | RECEIVE_WAP_PUSH       |
|            | RECEIVE_MMS            |
|------------|------------------------|
| STORAGE    | READ_EXTERNAL_STORAGE  |
|            | WRITE_EXTERNAL_STORAGE |
|------------|------------------------|
````

### 7.2.2　在程序运行时申请权限
> CALL_PHONE 这个权限是编写拨打电话功能的时候需要声明的，因为拨打电话会涉及用户手机的资费问题，因而被列为了危险权限。在Android 6.0系统出现之前，拨打电话功能的实现其实非常简单
> `<uses-permission android:name="android.permission.CALL_PHONE" />`
> 这样我们就将拨打电话的功能成功实现了，并且在低于Android 6.0系统的手机上都是可以正常运行的，但是如果我们在6.0或者更高版本系统的手机上运行，点击Make Call按钮就没有任何效果，这时观察logcat中的打印日志，错误信息中提醒我们“Permission Denial”，可以看出，是由于权限被禁止所导致的，因为6.0及以上系统在使用危险权限时都必须进行运行时权限处理。
````java
public void onClick(View v) {
    if (ContextCompat.checkSelfPermission(MainActivity.this, Manifest.
        permission.CALL_PHONE) != PackageManager.PERMISSION_GRANTED) {
        ActivityCompat.requestPermissions(MainActivity.this, new
            String[]{ Manifest.permission.CALL_PHONE }, 1);
    } else {
        call();
    }
}
@Override
public void onRequestPermissionsResult(int requestCode, String[] permissions,
    int[] grantResults) {
    switch (requestCode) {
        case 1:
            if (grantResults.length > 0 && grantResults[0] == PackageManager.
                PERMISSION_GRANTED) {
                call();
            } else {
                Toast.makeText(this, "You denied the permission", Toast.LENGTH_
                    SHORT).show();
            }
            break;
        default:
    }
}
````
> 运行时权限的核心就是在程序运行过程中由用户授权我们去执行某些危险操作，程序是不可以擅自做主去执行这些危险操作的。因此，第一步就是要先判断用户是不是已经给过我们授权了，借助的是ContextCompat.checkSelfPermission() 方法。checkSelfPermission() 方法接收两个参数，第一个参数是Context ，这个没什么好说的，第二个参数是具体的权限名，比如打电话的权限名就是Manifest.permission.CALL_PHONE ，然后我们使用方法的返回值和PackageManager.PERMISSION_GRANTED 做比较，相等就说明用户已经授权，不等就表示用户没有授权。
> 如果已经授权的话就简单了，直接去执行拨打电话的逻辑操作就可以了，这里我们把拨打电话的逻辑封装到了call() 方法当中。如果没有授权的话，则需要调用ActivityCompat.requestPermissions() 方法来向用户申请授权，requestPermissions() 方法接收3个参数，第一个参数要求是Activity的实例，第二个参数是一个String 数组，我们把要申请的权限名放在数组中即可，第三个参数是请求码，只要是唯一值就可以了，这里传入了1。
> 调用完了requestPermissions() 方法之后，系统会弹出一个权限申请的对话框，然后用户可以选择同意或拒绝我们的权限申请，不论是哪种结果，最终都会回调到onRequestPermissionsResult() 方法中，而授权的结果则会封装在grantResults 参数当中。这里我们只需要判断一下最后的授权结果，如果用户同意的话就调用call() 方法来拨打电话，如果用户拒绝的话我们只能放弃操作，并且弹出一条失败提示。
> 可以看到，这次我们就成功进入到拨打电话界面了，并且由于用户已经完成了授权操作，之后再点击Make Call按钮就不会再弹出权限申请对话框了，而是可以直接拨打电话。那可能你会担心，万一以后我又后悔了怎么办？没有关系，用户随时都可以将授予程序的危险权限进行关闭，进入Settings → Apps → RuntimePermissionTest → Permissions, 在这里我们就可以对任何授予过的危险权限进行关闭了。

## 7.3　访问其他程序中的数据
> 内容提供器的用法一般有两种，一种是使用现有的内容提供器来读取和操作相应程序中的数据，另一种是创建自己的内容提供器给我们程序的数据提供外部访问接口。
> 如果一个应用程序通过内容提供器对其数据提供了外部访问接口，那么任何其他的应用程序就都可以对这部分数据进行访问。Android系统中自带的电话簿、短信、媒体库等程序都提供了类似的访问接口，这就使得第三方应用程序可以充分地利用这部分数据来实现更好的功能。



