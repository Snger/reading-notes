# win10
<!-- MarkdownTOC -->

- Win10英文输入法如何切换全角和半角输入？
- 把应用加入开机启动
- Windows 10 自带输入法如何快速切换简繁体?
- open the Run window so that you can run quick commands
- cmd- change to e drive?
- Location of the Hosts File
- How do I set system environment variables in Windows 10?
- How can I refresh my PATH variable from the registry, without a reboot, logoff, or restarting explorer?
- How to turn on IIS in Windows 10
- How to: Create \(Local\) IIS Web Sites
- How to open firewall ports in Windows 10
- How to join a Homegroup from a Windows 10 computer

<!-- /MarkdownTOC -->

## Win10英文输入法如何切换全角和半角输入？
1. 在win10系统中英文输入状态时我们需要使用全角时只要按 SHIFT键+ 空格键 就可以切换了

## 把应用加入开机启动
1. 首先创建应用程序的快捷方式
2. 如果没有显示隐藏的文件夹，则把“显示隐藏文件夹”选项打开
在资源管理器中点击“查看”->"隐藏的项目"，打上钩
此时ProgrameData文件夹就会显示出来了
3. 进入目录
C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp
4. 把应用程序快捷方式剪切（或者复制）并粘贴到
C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp 目录中
5. 进阶：打开运行对话框（win键+R），输入命令 `shell:startup` 会直接弹出启动项对应的目录，然后像前面方法一样把应用程序快捷方式复制到启动目录

## Windows 10 自带输入法如何快速切换简繁体?
1. Ctrl + Shift + F
2. 我用的 Sublime text 3 编辑器高级搜索也是这个快捷键，也是从前段时间开始不能使用：每次要先按Ctrl + F，然后 Ctrl 键不放，再按下 Shift + F，这样才能打开高级搜索面板。(win10 不能自定义系统快捷键)

## open the Run window so that you can run quick commands
1. Both Windows 8.1 and Windows 10 have a hidden power user menu that includes a shortcut for the Run window. There are many ways to access this menu, the easiest being to use the Windows + X keyboard shortcut.

## cmd- change to e drive?
1. type the below at the C:\> prompt: `E:` That's all!

## Location of the Hosts File
1. C:\Windows\System32\Drivers\etc
2. /c/Windows/System32/Drivers/etc

## How do I set system environment variables in Windows 10?
> 1. Go into Settings and click on System.
> 2. Then on the left side click About and select System info at the bottom.
> 3. In the new Control Panel window that opens, click Advanced system settings on the left.
> 4. Now in the new window that comes up, select Environment Variables... at the bottom.
> - I typed "envir" in the "Search the web and Windows" box and selected "Edit environment variables for your account" under the "Best Match".

## How can I refresh my PATH variable from the registry, without a reboot, logoff, or restarting explorer?
1. If you are trying to use the new value of the path variable from within a Windows command shell, all you should need to do is close your command shell window and open a new one. The new command shell will load the updated path variable.

## How to turn on IIS in Windows 10
> - Press Windows logo + X keys on the keyboard and select Control panel from the context menu.
> - Search Features - Turn Windows Features On or Off
> - Internet Information Services. To turn a feature on, select its checkbox.
>> - Web Management Tools
>>> IIS Management Console
>> - World Wide Web Services
>>> - Applacation Development Features
>>>> .NET Extensibility 3.5
>>>> .NET Extensibility 4.7
>>>> ASP.NET 3.5
>>>> ASP.NET 4.7
>>>> ISAPI Extensions
>>>> ISAPI Filters
>>> - Common HTTP Features
>>>> Default Document
>>>> Directory Browsing
>>>> HTTP Errors
>>>> Static Content
>>> - Health and Diagnostics
>>>> HTTP Logging
>>> - Perormance Features
>>>> Static Content Pression
>>> - Security
>>>> Request Filtering

## How to: Create (Local) IIS Web Sites
> - Open the IIS Manager
> - Add the website
>> – Expand the tree on the connections column.
>> – Right click Sites.
>> – Select Add Web Site…
> - Configure the new website
>> – In Site name, enter a name to identify your website. The domain or name of the site is best.
>> – In Physical path enter the *path to the website files*. You can put this anywhere on your hard drive but the default is c:\inetpub\wwwroot\. In the binding set, you can select how the site is bound to the server.
>> – Type: Select HTTP if you don’t know what you’re doing here.
>> – IP Address: Select your IP here. When using Windows 7 you’re probably hosting at home, so this will probably be your local IP such as 192.168.1.123 otherwise it may be something else.
>> – Port: This should not be changed unless required as port 80 is the only port you can use without adding :port at the end of your domain. You should only change this if your ISP blocks port 80.
>> – Host name: This should be your domain name. If you don’t have one and want to use your IP, leave it blank.
> - Extra Configuration
>> – Right click on the website we have just created and select Edit Bindings.
> - Set up your domain’s DNS
>> - Set up a new A record that points to your IP. You will need to do this twice, once with and once without www.

## How to open firewall ports in Windows 10
0. Press Windows logo + X keys on the keyboard and select Control panel from the context menu.
1. Navigate to Control Panel, System and Security and Windows Firewall.
2. Select Advanced settings and highlight Inbound Rules in the left pane.
3. Right click Inbound Rules and select New Rule.
4. Add the port you need to open and click Next.
5. Add the protocol (TCP or UDP) and the port number into the next window and click Next.
6. Select Allow the connection in the next window and hit Next.
7. Select the network type as you see fit and click Next.
8. Name the rule something meaningful and click Finish.


## How to join a Homegroup from a Windows 10 computer
> Click on the Start button on your computer, Type "Homegroup" in the search box, In the search results, click on "Homegroup"
> If you already have a computer hosting a Homegroup, you will see the option to Join the group
> If you don't have a Homegroup already setup, you will see the option to Create a new Homegroup.
> In the next step, share the files and devices you want to share and click "Next"
> In the next step, you will need to enter the password of your Homegroup. If you are joining a Homegroup created on another computer, you will need to obtain the password from the administrator of that computer. The computer name and username will be displayed on the screen so that you can ask the appropriate person for the password.