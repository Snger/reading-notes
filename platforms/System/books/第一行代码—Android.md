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
- 第 10 章 后台默默的劳动者——探究服务
    - 10.3.2　启动和停止服务
    - 10.3.3　活动和服务进行通信
    - 10.4　服务的生命周期
    - 10.5.1　使用前台服务
    - 10.5.2　使用IntentService
- 第 11 章　Android特色开发——基于位置的服务
    - 11.1　基于位置的服务简介
- 第 12 章　最佳的UI体验——Material Design实战
    - 12.3.1 DrawerLayout
    - 12.3.2　NavigationView
    - 12.4　悬浮按钮和可交互提示
    - 12.4.1　FloatingActionButton
    - 12.4.2　Snackbar
    - 12.4.3　CoordinatorLayout
    - 12.5　卡片式布局
    - 12.5.1　CardView
    - 12.5.2　AppBarLayout
    - 12.6　下拉刷新
    - 12.7　可折叠式标题栏
    - 12.7.1　CollapsingToolbarLayout
    - 12.7.2　充分利用系统状态栏空间
- 第 13 章　继续进阶——你还应该掌握的高级技巧
    - 13.1　全局获取Context的技巧
    - 13.2　使用Intent传递对象
    - 13.2.1　Serializable方式
    - 13.2.2　Parcelable方式
    - 13.4　调试Android程序
    - 13.5　创建定时任务
    - 13.5.2　Doze模式
- 13.6　多窗口模式编程
    - 13.6.1　进入多窗口模式
    - 13.6.2　多窗口模式下的生命周期
    - 13.6.3　禁用多窗口模式
- 13.7　Lambda表达式
- 第 15 章　最后一步——将应用发布到360应用商店
    - 15.1　生成正式签名的APK文件
    - 15.1.1　使用Android Studio生成
    - 15.1.2　使用Gradle生成
    - 15.1.3　生成多渠道APK文件
    - 15.3　发布应用程序

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


## 第 10 章 后台默默的劳动者——探究服务
### 10.3.2　启动和停止服务
> 可以看到，这里在 `onCreate()` 方法中分别获取到了 `Start Service` 按钮和 `Stop Service` 按钮的实例，并给它们注册了点击事件。然后在 `Start Service` 按钮的点击事件里，我们构建出了一个 `Intent` 对象，并调用 `startService()` 方法来启动 `MyService` 这个服务。在 `Stop Serivce` 按钮的点击事件里，我们同样构建出了一个 `Intent` 对象，并调用 `stopService()` 方法来停止 `MyService` 这个服务。 `startService()` 和 `stopService()` 方法都是定义在 `Context` 类中的，所以我们在活动里可以直接调用这两个方法。注意，这里完全是由活动来决定服务何时停止的，如果没有点击 `Stop Service` 按钮，服务就会一直处于运行状态。那服务有没有什么办法让自已停止下来呢？当然可以，只需要在 `MyService` 的任何一个位置调用 `stopSelf()` 方法就能让这个服务停止下来了。
> 那么接下来又有一个问题需要思考了，我们如何才能证实服务已经成功启动或者停止了呢？最简单的方法就是在 `MyService` 的几个方法中加入打印日志， `MyService` 中的 `onCreate()` 和 `onStartCommand()` 方法都执行了，说明这个服务确实已经启动成功了，并且你还可以在 `Settings` → `Developer options` → `Running services` 中找到它
> 其实 `onCreate()` 方法是在服务第一次创建的时候调用的，而 `onStartCommand()` 方法则在每次启动服务的时候都会调用，由于刚才我们是第一次点击 `Start Service` 按钮，服务此时还未创建过，所以两个方法都会执行，之后如果你再连续多点击几次 `Start Service` 按钮，你就会发现只有 `onStartCommand()` 方法可以得到执行了。

### 10.3.3　活动和服务进行通信
> 上一小节中我们学习了启动和停止服务的方法，不知道你有没有发现，虽然服务是在活动里启动的，但在启动了服务之后，活动与服务基本就没有什么关系了。确实如此，我们在活动里调用了 `startService()` 方法来启动 `MyService` 这个服务，然后 `MyService` 的 `onCreate()` 和 `onStartCommand()` 方法就会得到执行。之后服务会一直处于运行状态，但具体运行的是什么逻辑，活动就控制不了了。这就类似于活动通知了服务一下：“你可以启动了！”然后服务就去忙自己的事情了，但活动并不知道服务到底去做了什么事情，以及完成得如何。
> 那么有没有什么办法能让活动和服务的关系更紧密一些呢？例如在活动中指挥服务去干什么，服务就去干什么。当然可以，这就需要借助我们刚刚忽略的 `onBind()` 方法了。
> 比如说，目前我们希望在 `MyService` 里提供一个下载功能，然后在活动中可以决定何时开始下载，以及随时查看下载进度。实现这个功能的思路是创建一个专门的 `Binder` 对象来对下载功能进行管理，修改 `MyService` 中的代码，
> 可以看到，这里我们新建了一个 `DownloadBinder` 类，并让它继承自 `Binder` ，然后在它的内部提供了开始下载以及查看下载进度的方法。当然这只是两个模拟方法，并没有实现真正的功能，我们在这两个方法中分别打印了一行日志。
> 接着，在 `MyService` 中创建了 `DownloadBinder` 的实例，然后在 `onBind()` 方法里返回了这个实例，这样 `MyService` 中的工作就全部完成了。
> 这两个按钮分别是用于绑定服务和取消绑定服务的，那到底谁需要去和服务绑定呢？当然就是活动了。当一个活动和服务绑定了之后，就可以调用该服务里的 `Binder` 提供的方法了。
> 这里我们首先创建了一个 `ServiceConnection` 的匿名类，在里面重写了 `onServiceConnected()` 方法和 `onServiceDisconnected()` 方法，这两个方法分别会在活动与服务成功绑定以及活动与服务的连接断开的时候调用。在 `onServiceConnected()` 方法中，我们又通过向下转型得到了 `DownloadBinder` 的实例，有了这个实例，活动和服务之间的关系就变得非常紧密了。现在我们可以在活动中根据具体的场景来调用 `DownloadBinder` 中的任何 `public` 方法，即实现了指挥服务干什么服务就去干什么的功能。这里仍然只是做了个简单的测试，在 `onServiceConnected()` 方法中调用了 `DownloadBinder` 的 `startDownload()` 和 `getProgress()` 方法。
> 这里我们首先创建了一个 `ServiceConnection` 的匿名类，在里面重写了 `onServiceConnected()` 方法和 `onServiceDisconnected()` 方法，这两个方法分别会在活动与服务成功绑定以及活动与服务的连接断开的时候调用。在 `onServiceConnected()` 方法中，我们又通过向下转型得到了 `DownloadBinder` 的实例，有了这个实例，活动和服务之间的关系就变得非常紧密了。现在我们可以在活动中根据具体的场景来调用 `DownloadBinder` 中的任何 `public` 方法，即实现了指挥服务干什么服务就去干什么的功能。这里仍然只是做了个简单的测试，在 `onServiceConnected()` 方法中调用了 `DownloadBinder` 的 `startDownload()` 和 `getProgress()` 方法。
> 当然，现在活动和服务其实还没进行绑定呢，这个功能是在 `Bind Service` 按钮的点击事件里完成的。可以看到，这里我们仍然是构建出了一个 `Intent` 对象，然后调用 `bindService()` 方法将 `MainActivity` 和 `MyService` 进行绑定。 `bindService()` 方法接收3个参数，第一个参数就是刚刚构建出的 `Intent` 对象，第二个参数是前面创建出的 `ServiceConnection` 的实例，第三个参数则是一个标志位，这里传入 `BIND_AUTO_CREATE` 表示在活动和服务进行绑定后自动创建服务。这会使得 `MyService` 中的 `onCreate()` 方法得到执行，但 `onStartCommand()` 方法不会执行。
> 然后如果我们想解除活动和服务之间的绑定该怎么办呢？调用一下 `unbindService()` 方法就可以了，这也是 `Unbind Service` 按钮的点击事件里实现的功能。
> 另外需要注意，任何一个服务在整个应用程序范围内都是通用的，即 `MyService` 不仅可以和 `MainActivity` 绑定，还可以和任何一个其他的活动进行绑定，而且在绑定完成后它们都可以获取到相同的 `DownloadBinder` 实例。

### 10.4　服务的生命周期
> 之前我们学习过了活动以及碎片的生命周期。类似地，服务也有自己的生命周期，前面我们使用到的 `onCreate()` 、 `onStartCommand()` 、 `onBind()` 和 `onDestroy()` 等方法都是在服务的生命周期内可能回调的方法。
> 一旦在项目的任何位置调用了 `Context` 的 `startService()` 方法，相应的服务就会启动起来，并回调 `onStartCommand()` 方法。如果这个服务之前还没有创建过， `onCreate()` 方法会先于 `onStartCommand()` 方法执行。服务启动了之后会一直保持运行状态，直到 `stopService()` 或 `stopSelf()` 方法被调用。注意，虽然每调用一次 `startService()` 方法， `onStartCommand()` 就会执行一次，但实际上每个服务都只会存在一个实例。所以不管你调用了多少次 `startService()` 方法，只需调用一次 `stopService()` 或 `stopSelf()` 方法，服务就会停止下来了。
> 另外，还可以调用 `Context` 的 `bindService()` 来获取一个服务的持久连接，这时就会回调服务中的 `onBind()` 方法。类似地，如果这个服务之前还没有创建过， `onCreate()` 方法会先于 `onBind()` 方法执行。之后，调用方可以获取到 `onBind()` 方法里返回的 `IBinder` 对象的实例，这样就能自由地和服务进行通信了。只要调用方和服务之间的连接没有断开，服务就会一直保持运行状态。
> 当调用了 `startService()` 方法后，又去调用 `stopService()` 方法，这时服务中的 `onDestroy()` 方法就会执行，表示服务已经销毁了。类似地，当调用了 `bindService()` 方法后，又去调用 `unbindService()` 方法， `onDestroy()` 方法也会执行，这两种情况都很好理解。但是需要注意，我们是完全有可能对一个服务既调用了 `startService()` 方法，又调用了 `bindService()` 方法的，这种情况下该如何才能让服务销毁掉呢？根据 `Android` 系统的机制，一个服务只要被启动或者被绑定了之后，就会一直处于运行状态，必须要让以上两种条件同时不满足，服务才能被销毁。所以，这种情况下要同时调用 `stopService()` 和 `unbindService()` 方法， `onDestroy()` 方法才会执行。
> 这样你就已经把服务的生命周期完整地走了一遍。

### 10.5.1　使用前台服务
> 服务几乎都是在后台运行的，一直以来它都是默默地做着辛苦的工作。但是服务的系统优先级还是比较低的，当系统出现内存不足的情况时，就有可能会回收掉正在后台运行的服务。如果你希望服务可以一直保持运行状态，而不会由于系统内存不足的原因导致被回收，就可以考虑使用前台服务。前台服务和普通服务最大的区别就在于，它会一直有一个正在运行的图标在系统的状态栏显示，下拉状态栏后可以看到更加详细的信息，非常类似于通知的效果。当然有时候你也可能不仅仅是为了防止服务被回收掉才使用前台服务的，有些项目由于特殊的需求会要求必须使用前台服务，比如说彩云天气这款天气预报应用，它的服务在后台更新天气数据的同时，还会在系统状态栏一直显示当前的天气信息
> 可以看到，这里只是修改了 `onCreate()` 方法中的代码，相信这部分代码你会非常眼熟。没错！这就是我们在第8章中学习的创建通知的方法。只不过这次在构建出 `Notification` 对象后并没有使用 `NotificationManager` 来将通知显示出来，而是调用了 `startForeground()` 方法。这个方法接收两个参数，第一个参数是通知的 `id` ，类似于 `notify()` 方法的第一个参数，第二个参数则是构建出的 `Notification` 对象。调用 `startForeground()` 方法后就会让 `MyService` 变成一个前台服务，并在系统状态栏显示出来。

### 10.5.2　使用IntentService
> 话说回来，在本章一开始的时候我们就已经知道，服务中的代码都是默认运行在主线程当中的，如果直接在服务里去处理一些耗时的逻辑，就很容易出现ANR（Application Not Responding）的情况。
> 所以这个时候就需要用到Android多线程编程的技术了，我们应该在服务的每个具体的方法里开启一个子线程，然后在这里去处理那些耗时的逻辑。
> 但是，这种服务一旦启动之后，就会一直处于运行状态，必须调用stopService() 或者stopSelf() 方法才能让服务停止下来。所以，如果想要实现让一个服务在执行完毕后自动停止的功能，就可以这样写：
````C#
public class MyService extends Service {
    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        new Thread(new Runnable() {
            @Override
            public void run() {
                // 处理具体的逻辑
                stopSelf();
            }
        }).start();
        return super.onStartCommand(intent, flags, startId);
        }
}
````
> 虽说这种写法并不复杂，但是总会有一些程序员忘记开启线程，或者忘记调用stopSelf() 方法。为了可以简单地创建一个异步的、会自动停止的服务，Android专门提供了一个IntentService 类，这个类就很好地解决了前面所提到的两种尴尬，下面我们就来看一下它的用法。
````C#
public class MyIntentService extends IntentService {
    public MyIntentService() {
        super("MyIntentService"); // 调用父类的有参构造函数
    }
    @Override
    protected void onHandleIntent(Intent intent) {
        // 打印当前线程的id
        Log.d("MyIntentService", "Thread id is " + Thread.currentThread(). getId());
    }
    @Override
    public void onDestroy() {
        super.onDestroy();
        Log.d("MyIntentService", "onDestroy executed");
    }
}
````

## 第 11 章　Android特色开发——基于位置的服务
> 说到只有在移动设备上才能实现的技术，很容易就让人联想到基于位置的服务（Location Based Service）。由于移动设备相比于电脑可以随身携带，我们通过地理定位的技术就可以随时得知自己所在的位置，从而围绕这一点开发出很多有意思的应用。

### 11.1　基于位置的服务简介
> 首先你要清楚，基于位置的服务所围绕的核心就是要先确定出用户所在的位置。通常有两种技术方式可以实现：一种是通过GPS定位，一种是通过网络定位。GPS定位的工作原理是基于手机内置的GPS硬件直接和卫星交互来获取当前的经纬度信息，这种定位方式精确度非常高，但缺点是只能在室外使用，室内基本无法接收到卫星的信号。网络定位的工作原理是根据手机当前网络附近的三个基站进行测速，以此计算出手机和每个基站之间的距离，再通过三角定位确定出一个大概的位置，这种定位方式精确度一般，但优点是在室内室外都可以使用。
> Android对这两种定位方式都提供了相应的API支持，但是由于一些特殊原因，Google的网络服务在中国不可访问，从而导致网络定位方式的API失效。而GPS定位虽然不需要网络，但是必须要在室外才可以使用，因此你在室内开发的时候很有可能会遇到不管使用哪种定位方式都无法成功定位的情况。
> 高精确度模式表示允许使用GPS、无线网络、蓝牙或移动网络来进行定位，节电模式表示仅允许使用无线网络、蓝牙或移动网络来进行定位，而仅限设备模式表示仅允许使用GPS来进行定位。也就是说，如果我们想要使用GPS定位功能，这里必须要选择高精确度模式，或者仅限设备模式。

## 第 12 章　最佳的UI体验——Material Design实战
> 但问题在于， Android 标准的界面设计风格并不是特别被大众所接受，很多公司都觉得自己完全可以设计出更加好看的界面，从而导致 Android 平台的界面风格长期难以得到统一。为了解决这个问题，谷歌也是祭出了杀手锏，在2014年 Google I /O大会上重磅推出了一套全新的界面设计语言—— Material Design 。
> 为了做出表率，谷歌从 Android 5.0系统开始，就将所有内置的应用都使用 Material Design 风格来进行设计。
> 不过，在重磅推出之后， Material Design 的普及程度却不能说是特别理想。因为这只是一个推荐的设计规范，主要是面向 UI 设计人员的，而不是面向开发者的。很多开发者可能根本就搞不清楚什么样的界面和效果才叫 Material Design ，就算搞清楚了，实现起来也会很费劲，因为不少 Material Design 的效果是很难实现的，而 Android 中却几乎没有提供相应的 API 支持，一切都要靠开发者自己从零写起。
> 谷歌当然也意识到了这个问题，于是在2015年的 Google I /O大会上推出了一个 Design Support 库，这个库将 Material Design 中最具代表性的一些控件和效果进行了封装，使得开发者在即使不了解 Material Design 的情况下也能非常轻松地将自己的应用 Material 化。本章中我们就将对 Design Support 这个库进行深入的学习，并且配合一些其他的控件来完成一个优秀的 Material Design 应用。
> 虽然这段代码不长，但是里面着实有不少技术点是需要我们去仔细琢磨一下的。首先看一下第2行，这里使用 `xmlns` : `app` 指定了一个新的命名空间。思考一下，正是由于每个布局文件都会使用 `xmlns` : `android` 来指定一个命名空间，因此我们才能一直使用 `android` : `id` 、 `android` : `layout_width` 等写法，那么这里指定了 `xmlns` : `app` ，也就是说现在可以使用 `app` : `attribute` 这样的写法了。但是为什么这里要指定一个 `xmlns` : `app` 的命名空间呢？这是由于 `Material Design` 是在 `Android` 5.0系统中才出现的，而很多的 `Material` 属性在5.0之前的系统中并不存在，那么为了能够兼容之前的老系统，我们就不能使用 `android` : `attribute` 这样的写法了，而是应该使用 `app` : `attribute` 。
> 可以看到，我们通过< `item` > 标签来定义 `action` 按钮， `android` : `id` 用于指定按钮的 `id` ， `android` : `icon` 用于指定按钮的图标， `android` : `title` 用于指定按钮的文字。
> 接着使用 `app` : `showAsAction` 来指定按钮的显示位置，之所以这里再次使用了 `app` 命名空间，同样是为了能够兼容低版本的系统。 `showAsAction` 主要有以下几种值可选： `always` 表示永远显示在 `Toolbar` 中，如果屏幕空间不够则不显示； `ifRoom` 表示屏幕空间足够的情况下显示在 `Toolbar` 中，不够的话就显示在菜单当中； `never` 则表示永远显示在菜单当中。注意， `Toolbar` 中的 `action` 按钮只会显示图标，菜单中的 `action` 按钮只会显示文字。

### 12.3.1 DrawerLayout
> 先来简单介绍一下 `DrawerLayout` 的用法吧。首先它是一个布局，在布局中允许放入两个直接子控件，第一个子控件是主屏幕中显示的内容，第二个子控件是滑动菜单中显示的内容。
> 可以看到，这里最外层的控件使用了 `DrawerLayout` ，这个控件是由 `support` -v4库提供的。 `DrawerLayout` 中放置了两个直接子控件，第一个子控件是 `FrameLayout` ，用于作为主屏幕中显示的内容，当然里面还有我们刚刚定义的 `Toolbar` 。第二个子控件这里使用了一个 `TextView` ，用于作为滑动菜单中显示的内容，其实使用什么都可以， `DrawerLayout` 并没有限制只能使用固定的控件。
> 但是关于第二个子控件有一点需要注意， `layout_gravity` 这个属性是必须指定的，因为我们需要告诉 `DrawerLayout` 滑动菜单是在屏幕的左边还是右边，指定 `left` 表示滑动菜单在左边，指定 `right` 表示滑动菜单在右边。这里我指定了 `start` ，表示会根据系统语言进行判断，如果系统语言是从左往右的，比如英语、汉语，滑动菜单就在左边，如果系统语言是从右往左的，比如阿拉伯语，滑动菜单就在右边。
> `ActionBar` 的实例，虽然这个 `ActionBar` 的具体实现是由 `Toolbar` 来完成的。接着调用 `ActionBar` 的 `setDisplayHomeAsUpEnabled()` 方法让导航按钮显示出来，又调用了 `setHomeAsUpIndicator()` 方法来设置一个导航按钮图标。实际上， `Toolbar` 最左侧的这个按钮就叫作 `HomeAsUp` 按钮，它默认的图标是一个返回的箭头，含义是返回上一个活动。很明显，这里我们将它默认的样式和作用都进行了修改。
> 接下来在 `onOptionsItemSelected()` 方法中对 `HomeAsUp` 按钮的点击事件进行处理， `HomeAsUp` 按钮的 `id` 永远都是 `android` .R. `id` . `home` 。然后调用 `DrawerLayout` 的 `openDrawer()` 方法将滑动菜单展示出来，注意 `openDrawer()` 方法要求传入一个 `Gravity` 参数，为了保证这里的行为和 `XML` 中定义的一致，我们传入了 `GravityCompat` . `START` 。

### 12.3.2　NavigationView
> 事实上，你可以在滑动菜单页面定制任意的布局，不过谷歌给我们提供了一种更好的方法——使用NavigationView。NavigationView是Design Support库中提供的一个控件，它不仅是严格按照Material Design的要求来进行设计的，而且还可以将滑动菜单页面的实现变得非常简单。
````gradle
dependencies {
    compile fileTree(dir: 'libs', include: ['*.jar'])
    compile 'com.android.support:appcompat-v7:24.2.1'
    testCompile 'junit:junit:4.12'
    compile 'com.android.support:design:24.2.1'
    compile 'de.hdodenhof:circleimageview:2.1.0'
}
````
> 我们首先在<menu> 中嵌套了一个<group> 标签，然后将group的checkableBehavior 属性指定为single 。group表示一个组，checkableBehavior 指定为single 表示组中的所有菜单项只能单选。
> 可以看到，我们将之前的TextView换成了NavigationView，这样滑动菜单中显示的内容也就变成NavigationView了。这里又通过app:menu 和app:headerLayout 属性将我们刚才准备好的menu和headerLayout设置了进去，这样NavigationView就定义完成了。
> NavigationView虽然定义完成了，但是我们还要去处理菜单项的点击事件才行。
> 代码还是比较简单的，这里首先获取到了NavigationView的实例，然后调用它的setCheckedItem() 方法将Call菜单项设置为默认选中。接着调用了setNavigationItemSelectedListener() 方法来设置一个菜单项选中事件的监听器，当用户点击了任意菜单项时，就会回调到onNavigationItemSelected() 方法中。我们可以在这个方法中写相应的逻辑处理，不过这里我并没有附加任何逻辑，只是调用了DrawerLayout的closeDrawers() 方法将滑动菜单关闭

### 12.4　悬浮按钮和可交互提示
> 立面设计是Material Design中一条非常重要的设计思想，也就是说，按照Material Design的理念，应用程序的界面不仅仅只是一个平面，而应该是有立体效果的。在官方给出的示例中，最简单且最具代表性的立面设计就是悬浮按钮了，这种按钮不属于主界面平面的一部分，而是位于另外一个维度的，因此就会给人一种悬浮的感觉。

### 12.4.1　FloatingActionButton
> FloatingActionButton是Design Support库中提供的一个控件，这个控件可以帮助我们比较轻松地实现悬浮按钮的效果。其实在之前的图12.2中，我们就已经预览过悬浮按钮是长什么样子的了，它默认会使用colorAccent来作为按钮的颜色，我们还可以通过给按钮指定一个图标来表明这个按钮的作用是什么。
````xml
<android.support.design.widget.FloatingActionButton
    android:id="@+id/fab"
    android:layout_width="wrap_content"
    android:layout_height="wrap_content"
    android:layout_gravity="bottom|end"
    android:layout_margin="16dp"
    android:src="@drawable/ic_done" />
````
> 可以看到，这里我们在主屏幕布局中加入了一个FloatingActionButton。这个控件的用法并没有什么特别的地方，layout_width 和layout_height 属性都指定成wrap_content ，layout_gravity 属性指定将这个控件放置于屏幕的右下角，其中end 的工作原理和之前的start 是一样的，即如果系统语言是从左往右的，那么end 就表示在右边，如果系统语言是从右往左的，那么end 就表示在左边。然后通过layout_margin 属性给控件的四周留点边距，紧贴着屏幕边缘肯定是不好看的，最后通过src 属性给FloatingActionButton设置了一个图标。
> 这里使用app:elevation 属性来给FloatingActionButton指定一个高度值，高度值越大，投影范围也越大，但是投影效果越淡，高度值越小，投影范围也越小，但是投影效果越浓。当然这些效果的差异其实都不怎么明显，我个人感觉使用默认的FloatingActionButton效果就已经足够了。

### 12.4.2　Snackbar
> 首先要明确，Snackbar并不是Toast的替代品，它们两者之间有着不同的应用场景。Toast的作用是告诉用户现在发生了什么事情，但同时用户只能被动接收这个事情，因为没有什么办法能让用户进行选择。而Snackbar则在这方面进行了扩展，它允许在提示当中加入一个可交互按钮，当用户点击按钮的时候可以执行一些额外的逻辑操作。打个比方，如果我们在执行删除操作的时候只弹出一个Toast提示，那么用户要是误删了某个重要数据的话肯定会十分抓狂吧，但是如果我们增加一个Undo按钮，就相当于给用户提供了一种弥补措施，从而大大降低了事故发生的概率，提升了用户体验。
````java
@Override
public void onclick(view view) {
    snackbar.make(view, "data deleted", snackbar.length_short)
            .setaction("undo", new view.onclicklistener() {
                @override
                public void onclick(view v) {
                    toast.maketext(mainactivity.this, "data restored",
                        toast.length_short).show();
                }
            })
            .show();
}
````
> 可以看到，这里调用了Snackbar的make() 方法来创建一个Snackbar 对象，make() 方法的第一个参数需要传入一个View，只要是当前界面布局的任意一个View都可以，Snackbar会使用这个View来自动查找最外层的布局，用于展示Snackbar。第二个参数就是Snackbar中显示的内容，第三个参数是Snackbar显示的时长。这些和Toast都是类似的。不管是出现还是消失，Snackbar都是带有动画效果的，因此视觉体验也会比较好。

### 12.4.3　CoordinatorLayout
> CoordinatorLayout可以说是一个加强版的FrameLayout，这个布局也是由Design Support库提供的。它在普通情况下的作用和FrameLayout基本一致，不过既然是Design Support库中提供的布局，那么就必然有一些Material Design的魔力了。
> 事实上，CoordinatorLayout可以监听其所有子控件的各种事件，然后自动帮助我们做出最为合理的响应。举个简单的例子，刚才弹出的Snackbar提示将悬浮按钮遮挡住了，而如果我们能让CoordinatorLayout监听到Snackbar的弹出事件，那么它会自动将内部的FloatingActionButton向上偏移，从而确保不会被Snackbar遮挡到。
> 至于CoordinatorLayout的使用也非常简单，我们只需要将原来的FrameLayout替换一下就可以了。由于CoordinatorLayout本身就是一个加强版的FrameLayout，因此这种替换不会有任何的副作用。另外悬浮按钮的向上和向下偏移也是伴随着动画效果的，且和Snackbar完全同步，整体效果看上去特别赏心悦目。
> 不过我们回过头来再思考一下，刚才说的是CoordinatorLayout可以监听其所有子控件的各种事件，但是Snackbar好像并不是CoordinatorLayout的子控件吧，为什么它却可以被监听到呢？
> 其实道理很简单，还记得我们在Snackbar的make() 方法中传入的第一个参数吗？这个参数就是用来指定Snackbar是基于哪个View来触发的，刚才我们传入的是FloatingActionButton本身，而FloatingActionButton是CoordinatorLayout中的子控件，因此这个事件就理所应当能被监听到了。你可以自己再做个试验，如果给Snackbar的make() 方法传入一个DrawerLayout，那么Snackbar就会再次遮挡住悬浮按钮，因为DrawerLayout不是CoordinatorLayout的子控件，CoordinatorLayout也就无法监听到Snackbar的弹出和隐藏事件了。

### 12.5　卡片式布局
### 12.5.1　CardView
> CardView是用于实现卡片式布局效果的重要控件，由appcompat-v7库提供。实际上，CardView也是一个FrameLayout，只是额外提供了圆角和阴影等效果，看上去会有立体的感觉。
> 这里定义了一个CardView布局，我们可以通过app:cardCornerRadius 属性指定卡片圆角的弧度，数值越大，圆角的弧度也越大。另外还可以通过app:elevation 属性指定卡片的高度，高度值越大，投影范围也越大，但是投影效果越淡，高度值越小，投影范围也越小，但是投影效果越浓，这一点和FloatingActionButton是一致的。
> 然后我们在CardView布局中放置了一个TextView，那么这个TextView就会显示在一张卡片当中了，CardView的用法就是这么简单。
> 但是我们显然不可能在如此宽阔的一块空白区域内只放置一张卡片，为了能够充分利用屏幕的空间，这里我准备综合运用一下第3章中学到的知识，使用RecyclerView来填充MaterialTest项目的主界面部分。还记得之前实现过的水果列表效果吗？这次我们将升级一下，实现一个高配版的水果列表效果。
````gradle
dependencies {
    compile fileTree(dir: 'libs', include: ['*.jar'])
    compile 'com.android.support:appcompat-v7:24.2.1'
    testCompile 'junit:junit:4.12'
    compile 'com.android.support:design:24.2.1'
    compile 'de.hdodenhof:circleimageview:2.1.0'
    compile 'com.android.support:recyclerview-v7:24.2.1'
    compile 'com.android.support:cardview-v7:24.2.1'
    compile 'com.github.bumptech.glide:glide:3.7.0'
}
````
> 注意上述声明的最后一行，这里添加了一个Glide库的依赖。Glide是一个超级强大的图片加载库，它不仅可以用于加载本地图片，还可以加载网络图片、GIF图片、甚至是本地视频。最重要的是，Glide的用法非常简单，只需一行代码就能轻松实现复杂的图片加载功能，因此这里我们准备用它来加载水果图片。[Glide的项目主页地址](https://github.com/bumptech/glide) 。
> 内容倒也没有什么特殊的地方，就是定义了一个ImageView用于显示水果的图片，又定义了一个TextView用于显示水果的名称，并让TextView在水平方向上居中显示。注意在ImageView中我们使用了一个scaleType 属性，这个属性可以指定图片的缩放模式。由于各张水果图片的长宽比例可能都不一致，为了让所有的图片都能填充满整个ImageView，这里使用了centerCrop模式，它可以让图片保持原有比例填充满ImageView，并将超出屏幕的部分裁剪掉。
> 那么这里就顺便来看一下Glide的用法吧，其实并没有太多好讲的，因为Glide的用法实在是太简单了。首先调用Glide.with() 方法并传入一个Context 、Activity 或Fragment 参数，然后调用load() 方法去加载图片，可以是一个URL地址，也可以是一个本地路径，或者是一个资源id，最后调用into() 方法将图片设置到具体某一个ImageView中就可以了。
> 那么我们为什么要使用Glide而不是传统的设置图片方式呢？因为这次我从网上找的这些水果图片像素都非常高，如果不进行压缩就直接展示的话，很容易就会引起内存溢出。而使用Glide就完全不需要担心这回事，因为Glide在内部做了许多非常复杂的逻辑操作，其中就包括了图片压缩，我们只需要安心按照Glide的标准用法去加载图片就可以了。

### 12.5.2　AppBarLayout
> 首先我们来分析一下为什么 `RecyclerView` 会把 `Toolbar` 给遮挡住吧。其实并不难理解，由于 `RecyclerView` 和 `Toolbar` 都是放置在 `CoordinatorLayout` 中的，而前面已经说过， `CoordinatorLayout` 就是一个加强版的 `FrameLayout` ，那么 `FrameLayout` 中的所有控件在不进行明确定位的情况下，默认都会摆放在布局的左上角，从而也就产生了遮挡的现象。其实这已经不是你第一次遇到这种情况了，我们在3.3.3小节学习 `FrameLayout` 的时候就早已见识过了控件与控件之间遮挡的效果。
> 既然已经找到了问题的原因，那么该如何解决呢？传统情况下，使用偏移是唯一的解决办法，即让 `RecyclerView` 向下偏移一个 `Toolbar` 的高度，从而保证不会遮挡到 `Toolbar` 。不过我们使用的并不是普通的 `FrameLayout` ，而是 `CoordinatorLayout` ，因此自然会有一些更加巧妙的解决办法。
> 这里我准备使用 `Design Support` 库中提供的另外一个工具—— `AppBarLayout` 。 `AppBarLayout` 实际上是一个垂直方向的 `LinearLayout` ，它在内部做了很多滚动事件的封装，并应用了一些 `Material Design` 的设计理念。
> 那么我们怎样使用 `AppBarLayout` 才能解决前面的覆盖问题呢？其实只需要两步就可以了，第一步将 `Toolbar` 嵌套到 `AppBarLayout` 中，第二步给 `RecyclerView` 指定一个布局行为。
> 可以看到，布局文件并没有什么太大的变化。我们首先定义了一个 `AppBarLayout` ，并将 `Toolbar` 放置在了 `AppBarLayout` 里面，然后在 `RecyclerView` 中使用 `app : layout_behavior ` 属性指定了一个布局行为。其中 `appbar_scrolling_view_behavior ` 这个字符串也是由 `Design Support` 库提供的。
> 虽说使用 `AppBarLayout` 已经成功解决了 `RecyclerView` 遮挡 `Toolbar` 的问题，但是刚才有提到过，说 `AppBarLayout` 中应用了一些 `Material Design` 的设计理念，好像从上面的例子完全体现不出来呀。事实上，当 `RecyclerView` 滚动的时候就已经将滚动事件都通知给 `AppBarLayout` 了，只是我们还没进行处理而已。那么下面就让我们来进一步优化，看看 `AppBarLayout` 到底能实现什么样的 `Material Design` 效果。
> 当 `AppBarLayout` 接收到滚动事件的时候，它内部的子控件其实是可以指定如何去影响这些事件的，通过 `app` : `layout_scrollFlags ` 属性就能实现。
> 这里在 `Toolbar` 中添加了一个 `app:layout`  `_scrollFlags ` 属性，并将这个属性的值指定成了 `scroll|enterAlways|snap ` 。其中， `scroll ` 表示当 `RecyclerView` 向上滚动的时候， `Toolbar` 会跟着一起向上滚动并实现隐藏； `enterAlways ` 表示当 `RecyclerView` 向下滚动的时候， `Toolbar` 会跟着一起向下滚动并重新显示。 `snap ` 表示当 `Toolbar` 还没有完全隐藏或显示的时候， 会根据当前滚动的距离， 自动选择是隐藏还是显示。

### 12.6　下拉刷新
> SwipeRefreshLayout就是用于实现下拉刷新功能的核心类，它是由support-v4库提供的。我们把想要实现下拉刷新功能的控件放置到SwipeRefreshLayout中，就可以迅速让这个控件支持下拉刷新。那么在MaterialTest项目中，应该支持下拉刷新功能的控件自然就是RecyclerView了。
> 可以看到，这里我们在RecyclerView的外面又嵌套了一层SwipeRefreshLayout，这样RecyclerView就自动拥有下拉刷新功能了。另外需要注意，由于RecyclerView现在变成了SwipeRefreshLayout的子控件，因此之前使用app:layout_behavior 声明的布局行为现在也要移到SwipeRefreshLayout中才行。
````java
public class MainActivity extends AppCompatActivity {
    ...
    private SwipeRefreshLayout swipeRefresh;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ...
        swipeRefresh = (SwipeRefreshLayout) findViewById(R.id.swipe_refresh);
        swipeRefresh.setColorSchemeResources(R.color.colorPrimary);
        swipeRefresh.setOnRefreshListener(new SwipeRefreshLayout.
            OnRefreshListener() {
            @Override
            public void onRefresh() {
                refreshFruits();
            }
        });
    }
    private void refreshFruits() {
        new Thread(new Runnable() {
            @Override
            public void run() {
                try {
                    Thread.sleep(2000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        initFruits();
                        adapter.notifyDataSetChanged();
                        swipeRefresh.setRefreshing(false);
                    }
                });
            }
        }).start();
    }
    ...
}
````
> 这段代码应该还是比较好理解的，首先通过findViewById() 方法拿到SwipeRefreshLayout的实例，然后调用setColorSchemeResources() 方法来设置下拉刷新进度条的颜色，这里我们就使用主题中的colorPrimary作为进度条的颜色了。接着调用setOnRefreshListener() 方法来设置一个下拉刷新的监听器，当触发了下拉刷新操作的时候就会回调这个监听器的onRefresh() 方法，然后我们在这里去处理具体的刷新逻辑就可以了。
> 通常情况下，onRefresh() 方法中应该是去网络上请求最新的数据，然后再将这些数据展示出来。这里简单起见，我们就不和网络进行交互了，而是调用一个refreshFruits() 方法进行本地刷新操作。refreshFruits() 方法中先是开启了一个线程，然后将线程沉睡两秒钟。之所以这么做，是因为本地刷新操作速度非常快，如果不将线程沉睡的话，刷新立刻就结束了，从而看不到刷新的过程。沉睡结束之后，这里使用了runOnUiThread() 方法将线程切换回主线程，然后调用initFruits() 方法重新生成数据，接着再调用FruitAdapter的notifyDataSetChanged() 方法通知数据发生了变化，最后调用SwipeRefreshLayout的setRefreshing() 方法并传入false ，用于表示刷新事件结束，并隐藏刷新进度条。

### 12.7　可折叠式标题栏
### 12.7.1　CollapsingToolbarLayout
> 顾名思义，CollapsingToolbarLayout是一个作用于Toolbar基础之上的布局，它也是由Design Support库提供的。CollapsingToolbarLayout可以让Toolbar的效果变得更加丰富，不仅仅是展示一个标题栏，而是能够实现非常华丽的效果。
> 不过，CollapsingToolbarLayout是不能独立存在的，它在设计的时候就被限定只能作为AppBarLayout的直接子布局来使用。而AppBarLayout又必须是CoordinatorLayout的子布局，因此本节中我们要实现的功能其实需要综合运用前面所学的各种知识。
````xml
<android.support.design.widget.CollapsingToolbarLayout
    android:id="@+id/collapsing_toolbar"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:theme="@style/ThemeOverlay.AppCompat.Dark.ActionBar"
    app:contentScrim="?attr/colorPrimary"
    app:layout_scrollFlags="scroll|exitUntilCollapsed">
</android.support.design.widget.CollapsingToolbarLayout>
````
> android:theme 属性指定了一个ThemeOverlay.AppCompat.Dark.ActionBar的主题，其实对于这部分我们也并不陌生，因为之前在activity_main.xml 中给Toolbar指定的也是这个主题，只不过这里要实现更加高级的Toolbar效果，因此需要将这个主题的指定提到上一层来。app:contentScrim 属性用于指定CollapsingToolbarLayout在趋于折叠状态以及折叠之后的背景色，其实CollapsingToolbarLayout在折叠之后就是一个普通的Toolbar，那么背景色肯定应该是colorPrimary了，具体的效果我们待会儿就能看到。app:layout_scrollFlags 属性我们也是见过的，只不过之前是给Toolbar指定的，现在也移到外面来了。其中，scroll表示CollapsingToolbarLayout会随着水果内容详情的滚动一起滚动，exitUntilCollapsed 表示当CollapsingToolbarLayout随着滚动完成折叠之后就保留在界面上，不再移出屏幕。
> 可以看到，我们在CollapsingToolbarLayout中定义了一个ImageView和一个Toolbar，也就意味着，这个高级版的标题栏将是由普通的标题栏加上图片组合而成的。这里定义的大多数属性我们都是见过的，就不再解释了，只有一个app:layout_collapseMode 比较陌生。它用于指定当前控件在CollapsingToolbarLayout折叠过程中的折叠模式，其中Toolbar指定成pin，表示在折叠的过程中位置始终保持不变，ImageView指定成parallax，表示会在折叠的过程中产生一定的错位偏移，这种模式的视觉效果会非常好。
> 水果内容详情的最外层布局使用了一个NestedScrollView，注意它和AppBarLayout是平级的。我们之前在9.2.1小节学过ScrollView的用法，它允许使用滚动的方式来查看屏幕以外的数据，而NestedScrollView在此基础之上还增加了嵌套响应滚动事件的功能。由于CoordinatorLayout本身已经可以响应滚动事件了，因此我们在它的内部就需要使用NestedScrollView或RecyclerView这样的布局。另外，这里还通过app:layout_behavior 属性指定了一个布局行为，这和之前在RecyclerView中的用法是一模一样的。
> 不管是ScrollView还是NestedScrollView，它们的内部都只允许存在一个直接子布局。因此，如果我们想要在里面放入很多东西的话，通常都会先嵌套一个LinearLayout，然后再在LinearLayout中放入具体的内容就可以了，
> 可以看到，这里加入了一个FloatingActionButton，它和AppBarLayout以及NestedScrollView是平级的。FloatingActionButton中使用app:layout_anchor 属性指定了一个锚点，我们将锚点设置为AppBarLayout，这样悬浮按钮就会出现在水果标题栏的区域内，接着又使用app:layout_anchorGravity 属性将悬浮按钮定位在标题栏区域的右下角。其他一些属性都比较简单，就不再进行解释了。

### 12.7.2　充分利用系统状态栏空间
> 想要让背景图能够和系统状态栏融合，需要借助android:fitsSystemWindows 这个属性来实现。在CoordinatorLayout、AppBarLayout、CollapsingToolbarLayout这种嵌套结构的布局中，将控件的android:fitsSystemWindows 属性指定成true ，就表示该控件会出现在系统状态栏里。对应到我们的程序，那就是水果标题栏中的ImageView应该设置这个属性了。不过只给ImageView设置这个属性是没有用的，我们必须将ImageView布局结构中的所有父布局都设置上这个属性才可以
> 但是，即使我们将android:fitsSystemWindows 属性都设置好了还是没有用的，因为还必须在程序的主题中将状态栏颜色指定成透明色才行。指定成透明色的方法很简单，在主题中将android:statusBarColor 属性的值指定成@android:color/transparent 就可以了。但问题在于，android:statusBarColor 这个属性是从API 21，也就是Android 5.0系统开始才有的，之前的系统无法指定这个属性。那么，系统差异型的功能实现就要从这里开始了。
> 右击res目录→New→Directory，创建一个values-v21目录，然后右击values-v21目录→New→Values resource file，创建一个styles.xml文件。接着对这个文件进行编写，代码如下所示：
````xml
<resources>
    <style name="FruitActivityTheme" parent="AppTheme">
        <item name="android:statusBarColor">@android:color/transparent</item>
    </style>
</resources>
````
> 这里我们定义了一个 FruitActivityTheme 主题，它是专门给FruitActivity使用的。FruitActivityTheme的parent主题是AppTheme，也就是说，它继承了AppTheme中的所有特性。然后我们在FruitActivityTheme中将状态栏的颜色指定成透明色，由于values-v21目录是只有Android 5.0及以上的系统才会去读取的，因此这么声明是没有问题的。
> 但是Android 5.0之前的系统却无法识别 FruitActivityTheme 这个主题，因此我们还需要对 values/styles.xml 文件进行修改，定义了一个FruitActivityTheme主题，并且parent主题也是AppTheme，但是它的内部是空的。因为Android 5.0之前的系统无法指定状态栏的颜色，因此这里什么都不用做就可以了。

## 第 13 章　继续进阶——你还应该掌握的高级技巧
### 13.1　全局获取Context的技巧
> Android提供了一个Application 类，每当应用程序启动的时候，系统就会自动将这个类进行初始化。而我们可以定制一个自己的Application 类，以便于管理程序内一些全局的状态信息，比如说全局Context 。
> 定制一个自己的Application 其实并不复杂，首先我们需要创建一个MyApplication 类继承自Application 
> 可以看到，MyApplication 中的代码非常简单。这里我们重写了父类的onCreate() 方法，并通过调用getApplicationContext() 方法得到了一个应用程序级别的Context ，然后又提供了一个静态的getContext() 方法，在这里将刚才获取到的Context 进行返回。
> 接下来我们需要告知系统，当程序启动的时候应该初始化MyApplication 类，而不是默认的Application 类。这一步也很简单，在AndroidManifest.xml文件的<application> 标签下进行指定就可以了，注意这里在指定MyApplication 的时候一定要加上完整的包名，不然系统将无法找到这个类。
> 这样我们就已经实现了一种全局获取Context 的机制，之后不管你想在项目的任何地方使用Context ，只需要调用一下MyApplication.getContext() 就可以了。
> 不过这里你可能又会产生疑问，如果我们已经配置过了自己的Application 怎么办？这样岂不是和LitePalApplication 冲突了？没错，任何一个项目都只能配置一个Application ，对于这种情况，LitePal提供了很简单的解决方案，那就是在我们自己的Application 中去调用LitePal的初始化方法就可以了，使用这种写法，就相当于我们把全局的Context 对象通过参数传递给了LitePal，效果和在AndroidManifest.xml中配置LitePalApplication 是一模一样的。

### 13.2　使用Intent传递对象
> Intent的用法相信你已经比较熟悉了，我们可以借助它来启动活动、发送广播、启动服务等。在进行上述操作的时候，我们还可以在Intent中添加一些附加数据，以达到传值的效果，

### 13.2.1　Serializable方式
> 使用Intent来传递对象通常有两种实现方式：Serializable和Parcelable，本小节中我们先来学习一下第一种实现方式。
> Serializable是序列化的意思，表示将一个对象转换成可存储或可传输的状态。序列化后的对象可以在网络上进行传输，也可以存储到本地。至于序列化的方法也很简单，只需要让一个类去实现Serializable 这个接口就可以了。
> 其中，get 、set 方法都是用于赋值和读取字段数据的，最重要的部分是在第一行。这里让Person 类去实现了Serializable 接口，这样所有的Person 对象就都是可序列化的了。
> 可以看到，这里我们创建了一个Person 的实例，然后就直接将它传入到putExtra() 方法中了。由于Person 类实现了Serializable 接口，所以才可以这样写。
> 接下来在SecondActivity 中获取这个对象也很简单，写法如下：
> `Person person = (Person) getIntent().getSerializableExtra("person_data");`

### 13.2.2　Parcelable方式
> 除了 `Serializable` 之外，使用 `Parcelable` 也可以实现相同的效果，不过不同于将对象进行序列化， `Parcelable` 方式的实现原理是将一个完整的对象进行分解，而分解后的每一部分都是 `Intent` 所支持的数据类型，这样也就实现传递对象的功能了。
> `Parcelable` 的实现方式要稍微复杂一些。可以看到，首先我们让 `Person` 类去实现了 `Parcelable` 接口，这样就必须重写 `describeContents()` 和 `writeToParcel()` 这两个方法。其中 `describeContents()` 方法直接返回0就可以了，而 `writeToParcel()` 方法中我们需要调用 `Parcel` 的 `writeXxx()` 方法，将 `Person` 类中的字段一一写出。注意，字符串型数据就调用 `writeString()` 方法，整型数据就调用 `writeInt()` 方法，以此类推。
> 除此之外，我们还必须在 `Person` 类中提供一个名为 `CREATOR` 的常量，这里创建了 `Parcelable` . `Creator` 接口的一个实现，并将泛型指定为 `Person` 。接着需要重写 `createFromParcel()` 和 `newArray()` 这两个方法，在 `createFromParcel()` 方法中我们要去读取刚才写出的 `name` 和 `age` 字段，并创建一个 `Person` 对象进行返回，其中 `name` 和 `age` 都是调用 `Parcel` 的 `readXxx()` 方法读取到的， 注意这里读取的顺序一定要和刚才写出的顺序完全相同。 而 `newArray()` 方法中的实现就简单多了，只需要 `new` 出一个 `Person` 数组，并使用方法中传入的 `size` 作为数组大小就可以了。
> 接下来，在 `FirstActivity` 中我们仍然可以使用相同的代码来传递 `Person` 对象，只不过在 `SecondActivity` 中获取对象的时候需要稍加改动，如下所示：
> `Person person = (Person) getIntent().getParcelableExtra("person_data");`
> 这样我们就把使用Intent来传递对象的两种实现方式都学习完了，对比一下，Serializable的方式较为简单，但由于会把整个对象进行序列化，因此效率会比Parcelable方式低一些，所以在通常情况下还是更加推荐使用Parcelable的方式来实现Intent传递对象的功能。

### 13.4　调试Android程序
> 这种调试方式虽然完全可以正常工作，但在调试模式下，程序的运行效率将会大大地降低，如果你的断点加在一个比较靠后的位置，需要执行很多的操作才能运行到这个断点，那么前面这些操作就都会有一些卡顿的感觉。没关系，Android还提供了另外一种调试的方式，可以让程序随时进入到调试模式，下面我们就来尝试一下。
> 这次不需要选择调试模式来启动程序了，就使用正常的方式来启动程序。由于现在不是在调试模式下，程序的运行速度比较快，可以先把账号和密码输入好。然后点击Android Studio顶部工具栏的Attach debugger to Android process按钮（图13.7中最左边的按钮）。

### 13.5　创建定时任务
> Android中的定时任务一般有两种实现方式，一种是使用Java API里提供的Timer类，一种是使用Android的Alarm机制。这两种方式在多数情况下都能实现类似的效果，但Timer有一个明显的短板，它并不太适用于那些需要长期在后台运行的定时任务。我们都知道，为了能让电池更加耐用，每种手机都会有自己的休眠策略，Android手机就会在长时间不操作的情况下自动让CPU进入到睡眠状态，这就有可能导致Timer中的定时任务无法正常运行。而Alarm则具有唤醒CPU的功能，它可以保证在大多数情况下需要执行定时任务的时候CPU都能正常工作。需要注意，这里唤醒CPU和唤醒屏幕完全不是一个概念，千万不要产生混淆。
````java
AlarmManager manager = (AlarmManager) getSystemService(Context.ALARM_SERVICE);
> long triggerAtTime = SystemClock.elapsedRealtime() + 10 * 1000;
> manager.set(AlarmManager.ELAPSED_REALTIME_WAKEUP, triggerAtTime, pendingIntent);
````
> 上面的两行代码你不一定能看得明白，因为set() 方法中需要传入的3个参数稍微有点复杂，下面我们就来仔细地分析一下。第一个参数是一个整型参数，用于指定AlarmManager 的工作类型，有4种值可选，分别是ELAPSED_REALTIME 、ELAPSED_REALTIME_WAKEUP 、RTC 和RTC_WAKEUP 。其中ELAPSED_REALTIME 表示让定时任务的触发时间从系统开机开始算起，但不会唤醒CPU。ELAPSED_REALTIME_WAKEUP 同样表示让定时任务的触发时间从系统开机开始算起，但会唤醒CPU。RTC 表示让定时任务的触发时间从1970年1月1日0点开始算起，但不会唤醒CPU。RTC_WAKEUP 同样表示让定时任务的触发时间从1970年1月1日0点开始算起，但会唤醒CPU。使用SystemClock.elapsedRealtime() 方法可以获取到系统开机至今所经历时间的毫秒数，使用System.currentTimeMillis() 方法可以获取到1970年1月1日0点至今所经历时间的毫秒数。
> 然后看一下第二个参数，这个参数就好理解多了，就是定时任务触发的时间，以毫秒为单位。如果第一个参数使用的是ELAPSED_REALTIME 或ELAPSED_REALTIME_WAKEUP ，则这里传入开机至今的时间再加上延迟执行的时间。如果第一个参数使用的是RTC 或RTC_WAKEUP ，则这里传入1970年1月1日0点至今的时间再加上延迟执行的时间。
> 第三个参数是一个PendingIntent ，对于它你应该已经不会陌生了吧。这里我们一般会调用getService() 方法或者getBroadcast() 方法来获取一个能够执行服务或广播的PendingIntent 。这样当定时任务被触发的时候，服务的onStartCommand() 方法或广播接收器的onReceive() 方法就可以得到执行。
> 那么，如果我们要实现一个长时间在后台定时运行的服务该怎么做呢？其实很简单，首先新建一个普通的服务，比如把它起名叫LongRunningService ，然后将触发定时任务的代码写到onStartCommand() 方法中，可以看到，我们先是在onStartCommand() 方法中开启了一个子线程，这样就可以在这里执行具体的逻辑操作了。之所以要在子线程里执行逻辑操作，是因为逻辑操作也是需要耗时的，如果放在主线程里执行可能会对定时任务的准确性造成轻微的影响。
> 另外需要注意的是，从Android 4.4系统开始，Alarm任务的触发时间将会变得不准确，有可能会延迟一段时间后任务才能得到执行。这并不是个bug，而是系统在耗电性方面进行的优化。系统会自动检测目前有多少Alarm任务存在，然后将触发时间相近的几个任务放在一起执行，这就可以大幅度地减少CPU被唤醒的次数，从而有效延长电池的使用时间。
> 当然，如果你要求Alarm任务的执行时间必须准确无误，Android仍然提供了解决方案。使用AlarmManager的setExact() 方法来替代set() 方法，就基本上可以保证任务能够准时执行了。

### 13.5.2　Doze模式
> 虽然Android的每个系统版本都在手机电量方面努力进行优化，不过一直没能解决后台服务泛滥、手机电量消耗过快的问题。于是在Android 6.0系统中，谷歌加入了一个全新的Doze模式，从而可以极大幅度地延长电池的使用寿命。本小节中我们就来了解一下这个模式，并且掌握一些编程时的注意事项。
> 首先看一下到底什么是Doze模式。当用户的设备是Android 6.0或以上系统时，如果该设备未插接电源，处于静止状态（Android 7.0中删除了这一条件），且屏幕关闭了一段时间之后，就会进入到Doze模式。在Doze模式下，系统会对CPU 、网络、Alarm等活动进行限制，从而延长了电池的使用寿命。
> 可以看到，随着设备进入Doze模式的时间越长，间歇性地退出Doze模式的时间间隔也会越长。因为如果设备长时间不使用的话，是没必要频繁退出Doze模式来执行同步等操作的，Android在这些细节上的把控使得电池寿命进一步得到了延长。
> 接下来我们具体看一看在Doze模式下有哪些功能会受到限制吧。
> - 网络访问被禁止。
> - 系统忽略唤醒CPU或者屏幕操作。
> - 系统不再执行WIFI扫描。
> - 系统不再执行同步服务。
> - Alarm任务将会在下次退出Doze模式的时候执行。
> 注意其中的最后一条，也就是说，在Doze模式下，我们的Alarm任务将会变得不准时。当然，这在大多数情况下都是合理的，因为只有当用户长时间不使用手机的时候才会进入Doze模式，通常在这种情况下对Alarm任务的准时性要求并没有那么高。
> 不过，如果你真的有非常特殊的需求，要求Alarm任务即使在Doze模式下也必须正常执行，Android还是提供了解决方案。调用AlarmManager的setAndAllowWhileIdle() 或setExactAndAllowWhileIdle() 方法就能让定时任务即使在Doze模式下也能正常执行了，这两个方法之间的区别和set() 、setExact() 方法之间的区别是一样的。

## 13.6　多窗口模式编程
> Android 7.0系统中却引入了一个非常有特色的功能——多窗口模式，它允许我们在同一个屏幕中同时打开两个应用程序。

### 13.6.1　进入多窗口模式
> 我们可以通过以下两种方式进入多窗口模式。
> - 在Overview列表界面长按任意一个活动的标题，将该活动拖动到屏幕突出显示的区域，则可以进入多窗口模式。
> - 打开任意一个程序，长按Overview按钮，也可以进入多窗口模式。
> 在多窗口模式下，整个应用的界面会缩小很多，那么编写程序时就应该多考虑使用match_parent 属性、RecyclerView、ListView、ScrollView等控件，来让应用的界面能够更好地适配各种不同尺寸的屏幕，尽量不要出现屏幕尺寸变化过大时界面就无法正常显示的情况。

### 13.6.2　多窗口模式下的生命周期
> 接下来我们学习一下多窗口模式下的生命周期。其实多窗口模式并不会改变活动原有的生命周期，只是会将用户最近交互过的那个活动设置为运行状态，而将多窗口模式下另外一个可见的活动设置为暂停状态。如果这时用户又去和暂停的活动进行交互，那么该活动就变成运行状态，之前处于运行状态的活动变成暂停状态。
> 了解了多窗口模式下活动的生命周期规则，那么我们在编写程序的时候，就可以将一些关键性的点考虑进去了。比如说，在多窗口模式下，用户仍然可以看到处于暂停状态的应用，那么像视频播放器之类的应用在此时就应该能继续播放视频才对。因此，我们最好不要在活动的onPause() 方法中去处理视频播放器的暂停逻辑，而是应该在onStop() 方法中去处理，并且在onStart() 方法恢复视频的播放。
> 另外，针对于进入多窗口模式时活动会被重新创建，如果你想改变这一默认行为，可以在AndroidManifest.xml中对活动进行如下配置：
````xml
<activity
    android:name=".MainActivity"
    android:label="Fruits"
    android:configChanges="orientation|keyboardHidden|screenSize|screenLayout">
    ...
</activity>
````
> 加入了这行配置之后，不管是进入多窗口模式，还是横竖屏切换，活动都不会被重新创建，而是会将屏幕发生变化的事件通知到Activity的onConfigurationChanged() 方法当中。因此，如果你想在屏幕发生变化的时候进行相应的逻辑处理，那么在活动中重写onConfigurationChanged() 方法即可。

### 13.6.3　禁用多窗口模式
> 多窗口模式虽然功能非常强大，但是未必就适用于所有的程序。比如说，手机游戏就非常不适合在多窗口模式下运行，很难想象我们如何一边玩着游戏，一边又操作着其他应用。因此，Android还是给我们提供了禁用多窗口模式的选项，如果你非常不希望自己的应用能够在多窗口模式下运行，那么就可以将这个功能关闭掉。
> 禁用多窗口模式的方法非常简单，只需要在AndroidManifest.xml的<application> 或<activity> 标签中加入如下属性即可：
> android:resizeableActivity=["true" | "false"]
> 其中，true 表示应用支持多窗口模式，false 表示应用不支持多窗口模式
> 可以看到，现在是无法进入到多窗口模式的，而且屏幕下方还会弹出一个Toast提示来告知用户，当前应用不支持多窗口模式。
> 虽说android:resizeableActivity 这个属性的用法很简单，但是它还存在着一个问题，就是这个属性只有当项目的targetSdkVersion指定成24或者更高的时候才会有用，否则这个属性是无效的。那么比如说我们将项目的targetSdkVersion指定成23，这个时候尝试进入多窗口模式，虽说界面上弹出了一个提示，告知我们此应用在多窗口模式下可能无法正常工作，但还是进入了多窗口模式。那这样我们就非常头疼了，因为有很多的老项目，它们的targetSdkVersion都没有指定到24，岂不是这些老项目都无法禁用多窗口模式了？
> 针对这种情况，还有一种解决方案。Android规定，如果项目指定的targetSdkVersion低于24，并且*（任一？）*活动是不允许横竖屏切换的，那么该应用也将不支持多窗口模式。
> 默认情况下，我们的应用都是可以随着手机的旋转自由地横竖屏切换的，如果想要让应用不允许横竖屏切换，那么就需要在AndroidManifest.xml的<activity> 标签中加入如下配置：
`android:screenOrientation=["portrait" | "landscape"]`
> 其中，portrait 表示活动只支持竖屏，landscape 表示活动只支持横屏。

## 13.7　Lambda表达式
> 如果想要在Android项目中使用Lambda表达式或者Java 8的其他新特性，首先我们需要在app/build.gradle中添加如下配置：
````gradle
android {
    ...
    defaultConfig {
        ...
        jackOptions.enabled = true
    }
    compileOptions {
        sourceCompatibility JavaVersion.VERSION_1_8
        targetCompatibility JavaVersion.VERSION_1_8
    }
    ...
}
````
````java
new Thread(new Runnable() {
    @Override
    public void run() {
        // 处理具体的逻辑
    }
}).start();
// lamda
new Thread(() -> {
    // 处理具体的逻辑
}).start();
Button button = (Button) findViewById(R.id.button);
button.setOnClickListener(v -> {
    // 处理点击事件
});
````
> 那么为什么我们可以使用这么神奇的写法呢？这是因为Thread 类的构造函数接收的参数是一个Runnable 接口，并且该接口中只有一个待实现方法。

## 第 15 章　最后一步——将应用发布到360应用商店
### 15.1　生成正式签名的APK文件
> Android系统会将所有的APK文件识别为应用程序的安装包，类似于Windows系统上的EXE文件。
> 但并不是所有的APK文件都能成功安装到手机上，Android系统要求只有签名后的APK文件才可以安装，因此我们还需要对生成的APK文件进行签名才行。那么你可能会有疑问了，直接通过Android Studio来运行程序的时候好像并没有进行过签名操作啊，为什么还能将程序安装到手机上呢？这是因为Android Studio 使用了一个默认的 keystore 文件帮我们自动进行了签名。点击 Android Studio 右侧工具栏的 Gradle→ 项目名 → :app → Tasks → android，双击signingReport，
````
Variant: debug
Config: debug
Store: C:\Users\toushou\.android\debug.keystore
Alias: AndroidDebugKey
````
> 也就是说，我们所有通过Android Studio来运行的程序都是使用了这个debug.keystore文件来进行签名的。不过这仅仅适用于开发阶段而已

### 15.1.1　使用Android Studio生成
> 点击Android Studio导航栏上的Build→Generate Signed APK，首次点击可能会提示让我们输入操作系统的密码，输入密码之后点击OK，则会弹出如图15.3所示的创建签名APK对话框。
> 由于目前我们还没有一个正式的keystore文件，所以应该点击Create new按钮，然后会弹出一个新的对话框来让我们填写创建keystore文件所必要的信息。根据自己的实际情况进行填写就行了
> 这里需要注意，在Validity那一栏填写的是keystore文件的有效时长，单位是年，一般建议时间可以填得长一些，比如我填了30年。

### 15.1.2　使用Gradle生成
> Gradle的用法极为丰富，想要完全掌握它的用法，其复杂程度并不亚于学习一门新的语言（Gradle是使用Groovy语言编写的）。
> 这里在android闭包中添加了一个signingConfigs闭包，然后在signingConfigs闭包中又添加了一个config闭包。接着在config闭包中配置keystore文件的各种信息，storeFile用于指定keystore文件的位置，storePassword用于指定密码，keyAlias用于指定别名， keyPassword用于指定别名密码。
> 现在build.gradle文件已经配置完成，那么我们如何才能生成APK文件呢？其实非常简单，Android Studio中内置了很多的Gradle Tasks，其中就包括了生成APK文件的Task。点击右侧工具栏的Gradle→项目名→:app→Tasks→build
> 其中assembleDebug用于生成测试版的APK文件，assembleRelease用于生成正式版的APK文件，assemble用于同时生成测试版和正式版的APK文件。在生成APK之前，先要双击clean这个Task来清理一下当前项目，然后双击assembleRelease
> 可以看到，这里提示我们BUILD SUCCESSFUL，说明assembleRelease执行成功了。APK文件会自动生成在app/build/outputs/apk目录下
> 虽说现在APK文件已经成功生成了，不过还有一个小细节需要注意一下。目前keystore文件的所有信息都是以明文的形式直接配置在build.gradle中的，这样就不太安全。Android推荐的做法是将这类敏感数据配置在一个独立的文件里面，然后再在build.gradle中去读取这些数据。
> 这里只需要将原来的明文配置改成相应的键值，一切就完工了。这样直接查看build.gradle文件是无法看到keystore文件的各种信息的，只有查看gradle.properties文件才能看得到。然后我们只需要将gradle.properties文件保护好就行了，比如说将它从Git版本控制中排除。这样gradle.properties文件就只会保留在本地，从而也就不用担心keystore文件的信息会泄漏了。

### 15.1.3　生成多渠道APK文件
> 现在Android Studio提供了一种非常方便的方法来应对这种差异性需求，极大程度地解决了之前版本维护困难的问题，比如说这里我们准备生成360和百度两个渠道的APK文件，那么修改app/build.gradle文件，添加了一个productFlavors 闭包，然后在该闭包中添加所有的渠道配置就可以了。注意Gradle中的配置规定不能以数字开头，因此这里我将360的渠道名配置成了qihoo。渠道名的闭包中可以覆写defaultConfig中的任何一个属性，比如说这里将applicationId 属性进行了覆写，那么最终生成的各渠道APK文件的包名也将各不相同。
> 接下来我们开始针对不同渠道编写差异性需求。在app/src目录下（main的平级目录）新建一个baidu目录，然后在baidu目录下再新建java和res这两个目录，这样我们就可以在这里编写百度渠道特有的功能了，java目录用于存放代码，res目录用于存放资源，如果需要覆写AndroidManifest文件中的内容，还可以在baidu目录下再新建一个AndroidManifest.xml文件。
> 这样我们就以一个简单的示例实现渠道差异性需求了，下面开始来生成多渠道的APK文件。观察右侧工具栏的Gradle Tasks列表，你会发现里面多出了几个新的Task，如果你只想生成百度渠道的APK文件，那么就执行assembleBaidu；如果你只想生成360渠道的APK文件，那么就执行assembleQihoo；如果你想一次性生成所有渠道的APK文件，那么就还是执行assembleRelease。
> 除了使用Gradle的方式生成之外，使用Android Studio提供的可视化工具也是能生成多渠道APK文件的，这里我们可以选择是生成百度渠道的APK文件，还是生成360渠道的APK文件，如果你想一次性生成多个渠道的APK文件，按住CTRL键就可以进行多选了。
> 接下来我们可以通过adb install 命令将生成好的APK文件安装到模拟器上，adb install 命令的后面加上APK文件的路径，就可以将该APK文件安装到模拟器上了。

### 15.3　发布应用程序
> 点击下载应用按钮，先将加固后的APK文件下载下来。接下来的工作就有点烦琐了，因为Android Studio中并没有提供对一个未签名的APK直接进行签名的功能，因此我们只能通过最原始的方式，使用jarsigner 命令来进行签名。
> 在命令行界面按照以下格式输入签名命令：
````bash
jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore [keystore文件路径] -storepass [keystore文件密码] [待签名APK路径] [keystore文件别名]
````
> 将[] 中的描述替换成keystore文件的具体信息就能签名成功了，注意[] 符号是不需要的。接着我们将签名后的APK文件重新上传就可以了。