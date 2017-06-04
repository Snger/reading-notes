## Xcode Project vs. Xcode Workspace - Differences
1. I think there are three key items you need to understand regarding project structure: Targets, projects, and workspaces. Targets specify in detail how a product/binary (i.e., an application or library) is built. They include build settings, such as compiler and linker flags, and they define which files (source code and resources) actually belong to a product. When you build/run, you always select one specific target.
2. It is likely that you have a few targets that share code and resources. These different targets can be slightly different versions of an app (iPad/iPhone, different brandings,…) or test cases that naturally need to access the same source files as the app. All these related targets can be grouped in a project. While the project contains the files from all its targets, each target picks its own subset of relevant files. The same goes for build settings: You can define default project-wide settings in the project, but if one of your targets needs different settings, you can always override them
3. In Xcode, you always open projects (or workspaces, but not targets), and all the targets it contains can be built/run, but there’s no way/definition of building a project, so every project needs at least one target in order to be more than just a collection of files and settings.
4. In a lot of cases, projects are all you need. If you have a dependency that you build from source, you can embed it as a subproject. Subprojects can be opened separately or within their super project. If you add one of the subproject’s targets to the super project’s dependencies, the subproject will be automatically built unless it has remained unchanged. The advantage here is that you can edit files from both your project and your dependencies in the same Xcode window, and when you build/run, you can select from the project’s and its subprojects’ targets
5. If, however, your library (the subproject) is used by a variety of other projects (or their targets, to be precise), it makes sense to put it on the same hierarchy level – that’s what workspaces are for. Workspaces contain and manage projects, and all the projects it includes directly (i.e., not their subprojects) are on the same level and their targets can depend on each other (projects’ targets can depend on subprojects’ targets, but not vice versa).
6. You can still open your project files separately, but it is likely their targets won’t build because Xcode cannot resolve the dependencies unless you open the workspace file. Workspaces give you the same benefit as subprojects: Once a dependency changes, Xcode will rebuild it to make sure it’s up-to-date (although I have had some issues with that, it doesn’t seem to work reliably).

## What's Storyboard?
1. A storyboard is a visual representation of the user interface of an iOS application, showing screens of content and the connections between those screens. A storyboard is composed of a sequence of scenes, each of which represents a view controller and its views; scenes are connected by segue objects, which represent a transition between two view controllers.
2. Xcode provides a visual editor for storyboards, where you can lay out and design the user interface of your application by adding views such as buttons, table views, and text views onto scenes. In addition, a storyboard enables you to connect a view to its controller object, and to manage the transfer of data between view controllers. Using storyboards is the recommended way to design the user interface of your application because they enable you to visualize the appearance and flow of your user interface on one canvas.

## A Segue Manages the Transition Between Two Scenes
1. You can set the type of transition (for example, modal or push) on a segue. Additionally, you can subclass a segue object to implement a custom transition.
2. You can pass data between scenes with the method prepareForSegue:sender:, which is invoked on the view controller when a segue is triggered. This method allows you to customize the setup of the next view controller before it appears on the screen. Transitions usually occur as the result of some event, such as a button being tapped, but you can programmatically force a transition by calling performSegueWithIdentifier:sender: on the view controller.

## WHAT IS COCOAPODS
1. CocoaPods is a dependency manager for Swift and Objective-C Cocoa projects. It has over 32 thousand libraries and is used in over 2.1 million apps. CocoaPods can help you scale your projects elegantly.
2. Search for pods (above). Then list the dependencies in a text file named Podfile in your Xcode project directory. Tip: CocoaPods provides a pod init command to create a Podfile with smart defaults. You should use it.
3. Now you can install the dependencies in your project: `$ pod install`
4. Make sure to always open the Xcode workspace instead of the project file when building your project: `$ open App.xcworkspace`.
5. Now you can import your dependencies e.g.: `#import <Reachability/Reachability.h>`

## Podspec Syntax Reference
1. A specification describes a version of Pod library. It includes details about where the source should be fetched from, what files to use, the build settings to apply, and other general metadata such as its name, version, and description.
2. A stub specification file can be generated by the pod spec create command.

## Processing Symbol Files in Xcode
1. It downloads the (debug) symbols from the device, so it becomes possible to debug on devices with that specific iOS version and also to symbolicate crash reports that happened on that iOS version.
2. Since symbols are CPU specific, the above only works if you have imported the symbols not only for a specific iOS device but also for a specific CPU type. The currently CPU types needed are armv7 (e.g. iPhone 4, iPhone 4s), armv7s (e.g. iPhone 5) and arm64 (e.g. iPhone 5s).
3. So if you want to symbolicate a crash report that happened on an iPhone 5 with armv7s and only have the symbols for armv7 for that specific iOS version, Xcode won't be able to (fully) symbolicate the crash report.
4. In Xcode Version 6.1.1 (6A2008a), after "Processing Symbol Files", a folder containing symbols associated with the device (including iOS version and CPU type) was created in ~/Library/Developer/Xcode/iOS DeviceSupport/
5. xCode just copy all crashes logs. If you want to speed-up: delete number of crash reports after you analyze it, directly in this window. `Devices -> View Device Logs -> All Logs`

## Code signing is required for product type 'Application' in SDK 'iOS 10.0' - StickerPackExtension requires a development team error
1. Go to your app and click on the general tab. Under the signing section, uncheck "Automatically manage signing". As soon as you do that you will get a status of red error as shown below.
2. Now here's the tricky part. You need to uncheck "Automatically manage Signing" in both the targets under your project. This step is very important.
3. Now go under "build settings" tab of each of those targets and set "iOS Developer" under code signing identity. Do the same steps for your "PROJECT".
4. Now do Xcode → Product → Clean. Close your project in Xcode and reopen it again.
5. After this go to the general tab of each of your targets and check "Automatically manage signing" and under team drop down select your developer account
6. Do an archive of your project again and everything should work.

