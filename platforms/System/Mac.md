# Mac
<!-- MarkdownTOC -->

- macOS Sierra: Open an app from an unidentified developer
- How to reinstate the Anywhere setting in Gatekeeper
- Kernel_task taking up RAM in OS X
- How to Sync Safari Bookmarks with Chrome
    - Manually import bookmarks and history from Firefox or Chrome
    - Enable Bookmark Synchronization on a Mac
    - Enable Bookmark Synchronization in Windows
- 如何修改鼠须管默认简繁体？
- How can I make Safari show the URL when I hover over a link?
- Mac "say" not working in tmux session

<!-- /MarkdownTOC -->

## macOS Sierra: Open an app from an unidentified developer
> To override your security settings and open the app anyway:
1. In the Finder, locate the app you want to open.
> Don’t use Launchpad to do this. Launchpad doesn’t allow you to access the shortcut menu.
2. Control-click the app icon, then choose Open from the shortcut menu.
3. Click Open.
> The app is saved as an exception to your security settings, and you can open it in the future by double-clicking it just as you can any registered app.
> Note: You can also grant an exception for a blocked app by clicking the “Open Anyway” button in the General pane of Security & Privacy preferences. This button is available for about an hour after you try to open the app.
> To open this pane, choose Apple menu > System Preferences, click Security & Privacy, then click General.

## How to reinstate the Anywhere setting in Gatekeeper
> If the thought of having to right or control-click to open apps from unidentified developers seems arduous and tiresome, you can turn back time with Gatekeeper and bring back the ability to open apps from anywhere. All it takes is a bit of coding in Terminal.
1. Close System Preferences on your Mac.
2. Open Terminal.
3. Type the following command:
`sudo spctl --master-disable`
4. Hit enter on your keyboard.
5. Enter your administrator password.
6. Hit enter on your keyboard.

## Kernel_task taking up RAM in OS X
>  The kernel in OS X is the software architecture that is responsible for handling resources that processes and programs need. These include the management of multitasking scheduling, virtual memory, system input and output, and various communication routines between processes. In addition, the kernel can be modified and given enhanced functionality by loading kernel extensions (kexts) to supply system-level management of features like Bluetooth and Wi-Fi, graphics processors, third-party hardware, access to peripheral devices, and special filesystem support. In essence, the kernel is responsible for running your hardware and making the hardware resources available to applications and system services.
> When the system starts up, even though you may have kernel extensions loaded, not all of the services are active. The system may be ready to use them, but will not load them fully until needed. Therefore, if you initially start up your system and check Activity Monitor, you may see the kernel_task process taking up a relatively small amount of RAM. When you then start using your system and activating features like your iSight camera, Wi-Fi services, switching GPUs, and using external devices, then the kernel_task will make use of the resources for these devices and will grow in size.
>  For instance, on my MacBook Pro running OS X 10.7 Lion, an initial boot will show the kernel_task process taking up 330-340MB of RAM. The task will idle with this level of RAM until you decide to do something with your system, so if I open a few applications (Word, Pages, iCal, Safari, Preview, etc.) then the amount of RAM used by the kernel_task increases to around 370MB. At this point the system has loaded and interacted with some services these programs need (networking, authentication, firewall, graphics, and user input), so the kernel_task has increased its RAM footprint to accommodate those tasks being active. If the programs are quit, the kernel_task does not relinquish the new RAM it's using, since the system services are still active even though the programs themselves are not. On subsequent launches of these programs; however, the RAM footprint does not increase any further.
>  As with running applications, general use of the system will also increase kernel_task RAM usage. For instance, enabling Bluetooth and Wi-Fi will bump it up about 3-4MB, browsing the filesystem will boost it around 25-30MB, and enabling the onboard GPU (which uses system memory for video RAM) will initially give around a 20-25MB increase in RAM usage, but this will rise further as you perform tasks like playing 3D games, or watch large movie files when using this GPU.
>  While some of the kernel_task services will not unload when you quit the processes that have started them, others will, especially if they are managing hardware in the system. For instance, on systems with multiple GPUs, if you use the onboard GPU, then you will see an increase in RAM usage by the kernel_task, but unlike some applications services, if you switch graphics processing back to the dedicated GPU, then the kernel_task will relinquish the RAM it was using for video memory. Likewise, if you have activated your iSight camera with a program like Photo Booth, then the kernel_task will use another 8-10MB of RAM, which will be relinquished when Photo Booth is shut down.
>  Ultimately there is not much you can do to affect how kernel_task runs and manages the system. If you see the kernel_task process taking up a large amount of RAM on your system, there are a few options to reduce the RAM other than restarting your system. The first is to disable any hardware devices you may have attached to your system, such as external monitors, hard drives, or third-party audio or video interfaces. In addition, you can disable services like Wi-Fi and Bluetooth if you are not using them, and switch to using discrete graphics instead of the onboard GPU. The second thing you can do is quit programs and system services that use kernel extensions, such as the aforementioned Photo Booth, or graphics processing programs and games, especially if you are running with the integrated graphics card.

## How to Sync Safari Bookmarks with Chrome
### Manually import bookmarks and history from Firefox or Chrome
> Choose File > Import From > Google Chrome or File > Import From > Firefox, then select the items you want to import. You can do this any time after you start using Safari, even if you imported items already.
### Enable Bookmark Synchronization on a Mac
> 1. Open the System Preferences app.
> 2. Click iCloud.
> 3. Check the box for Safari if it isn't already checked. If it already is checked, you're done!
> 4. Click OK to confirm you want to merge your Safari bookmarks and Reading List with iCloud.
### Enable Bookmark Synchronization in Windows
>  Download iCloud for Windows from [Apple's site](https://support.apple.com/zh-cn/HT202806)
>  Install iCloud using the installation wizard. You'll be prompted to restart the computer to complete the installation.
> Open the iCloud app. You can do this from the Start menu.
> Sign in with your Apple ID.
> Click the Options button next to Bookmarks.
> Select the browsers you want to sync bookmarks with Safari.
> Click OK.
> Click Apply to finish setting up synchronization.

## 如何修改鼠须管默认简繁体？
> 鼠须管默认是繁体输入，需要切换到简体输入的话，请用快捷键 control+“~”  打开切换菜单，选“漢字→汉字” 即可。


## How can I make Safari show the URL when I hover over a link?
> There are two options. One is a setting, and the other is a workaround.
> - Here are instructions on how to toggle the setting using the Menu Bar:
> Go into the View menu.
Select "Show status bar".
Now, there will be a URL that pops up when you hover over a link, and also tells you if it's going to be in a new tab:
> You can also press ⌘ + / to toggle this setting at ease.
> - The second option is a workaround for when you drag links. Here's how to get this feature to appear:
> Click and drag the link out of where it will originally appear.
At your mouse will be a small box telling you the title of the new window and its URL, although it may be shortened.
You can also drag the link to the plus sign in your tab list, out of the window, or in a folder/the desktop to open that URL in a new tab, new window or save it to your computer, respectively.

## Mac "say" not working in tmux session
````shell
brew install reattach-to-user-namespace
# In .tmux.conf:
set-option -g default-command "reattach-to-user-namespace -l zsh"
# To kill your existing tmux server (and everything running “inside” it!):
tmux kill-server
````

