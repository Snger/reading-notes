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

## Momentum Scrolling on iOS Overflow Elements
1. Web pages on iOS by default have a "momentum" style scrolling where a flick of the finger sends the web page scrolling and it keeps going until eventually slowing down and stopping as if friction is slowing it down. Like if you were to push a hockey puck across the ice or something. You might think that any element with scrolling would have this behavior as well, but it doesn't. You can add it back with a special property.
2. css
````css
overflow-y: scroll; /* has to be scroll, not auto */
-webkit-overflow-scrolling: touch;
````
3. The -webkit-overflow-scrolling CSS property controls whether or not touch devices use momentum-based scrolling for the given element.
- [Value] auto: Use "regular" scrolling, where the content immediately ceases to scroll when you remove your finger from the touchscreen.
- [Value] touch: Use momentum-based scrolling, where the content continues to scroll for a while after finishing the scroll gesture and removing your finger from the touchscreen. The speed and duration of the continued scrolling is proportional to how vigorous the scroll gesture was. Also creates a new stacking context.

## UIKit
1. Construct and manage your app’s user interface for iOS and tvOS. Respond to user interactions and system events, access various device features, enable accessibility, and work with animations, text, and images. In watchOS apps, enable accessibility and work with fonts and images.
2. [Overview] The UIKit framework (UIKit.framework) provides the crucial infrastructure needed to construct and manage iOS and tvOS apps. This framework provides the window and view architecture needed to manage an app’s user interface, the event handling infrastructure needed to respond to user input, and the app model needed to drive the main run loop and interact with the system.

## UIKit > UIApplication
1. The UIApplication class provides a centralized point of control and coordination for apps running in iOS. Every app has exactly one instance of UIApplication (or, very rarely, a subclass of UIApplication). When an app is launched, the system calls the `UIApplicationMain(_:_:_:_:)` function; among its other tasks, this function creates a Singleton UIApplication object. Thereafter you access the object by calling the shared class method.
2. [Overview] A major role of your app’s application object is to handle the initial routing of incoming user events. It dispatches action messages forwarded to it by control objects (instances of the UIControl class) to appropriate target objects. The application object maintains a list of open windows (UIWindow objects) and through those can retrieve any of the app’s UIView objects. The UIApplication class defines a delegate that conforms to the UIApplicationDelegate protocol and must implement some of the protocol’s methods. The application object informs the delegate of significant runtime events—for example, app launch, low-memory warnings, and app termination—giving it an opportunity to respond appropriately.

## UIKit > UIApplicationMain(_:_:_:_:) (Global Function)
1. This function is called in the main entry point to create the application object and the application delegate and set up the event cycle.
2. [Declaration] `func UIApplicationMain(_ argc: Int32, _ argv: UnsafeMutablePointer<UnsafeMutablePointer<Int8>>!, _ principalClassName: String?, _ delegateClassName: String?) -> Int32`
3. Parameters
- argc: The count of arguments in argv; this usually is the corresponding parameter to main.
- argv: A variable list of arguments; this usually is the corresponding parameter to main.
- principalClassName: The name of the UIApplication class or subclass. If you specify nil, UIApplication is assumed.
- delegateClassName: The name of the class from which the application delegate is instantiated. If principalClassName designates a subclass of UIApplication, you may designate the subclass as the delegate; the subclass instance receives the application-delegate messages. Specify nil if you load the delegate object from your application’s main nib file.

## What does “@UIApplicationMain” mean?
1. The @UIApplicationMain attribute in Swift replaces the trivial main.m file found in Objective-C projects (whose purpose is to implement the main function that's the entry point for all C programs and call UIApplicationMain to kick off the Cocoa Touch run loop and app infrastructure).
2. In Objective-C, the main (heh) bit of per-app configuration that the UIApplicationMain function provides is designating one of your app's custom classes as the delegate of the shared UIApplication object. In Swift, you can easily designate this class by adding the @UIApplicationMain attribute to that class' declaration. (You can also still invoke the UIApplicationMain function directly if you have reason to. In Swift you put that call in top-level code in a main.swift file.)
3. @UIApplicationMain is for iOS only. In OS X, the app delegate is traditionally set in the main nib file designated by the Info.plist (the same for Swift as for ObjC) — but with OS X storyboards there's no main nib file, so @NSApplicationMain does the same thing there.

## Language Reference > Attributes
1. Attributes provide more information about a declaration or type. There are two kinds of attributes in Swift, those that apply to declarations and those that apply to types. You specify an attribute by writing the @ symbol followed by the attribute’s name and any arguments that the attribute accepts: `@attribute name`, `@attribute name(attribute arguments)`
2. Some declaration attributes accept arguments that specify more information about the attribute and how it applies to a particular declaration. These attribute arguments are enclosed in parentheses, and their format is defined by the attribute they belong to.
3. @UIApplicationMain: Apply this attribute to a class to indicate that it is the application delegate. Using this attribute is equivalent to calling the UIApplicationMain function and passing this class’s name as the name of the delegate class. If you do not use this attribute, supply a main.swift file with code at the top level that calls the UIApplicationMain(_:_:_:_:) function. For example, if your app uses a custom subclass of UIApplication as its principal class, call the UIApplicationMain(_:_:_:_:) function instead of using this attribute.

## UIKit > UIApplicationDelegate
1. The UIApplicationDelegate protocol defines methods that are called by the singleton UIApplication object in response to important events in the lifetime of your app.
2. The app delegate works alongside the app object to ensure your app interacts properly with the system and with other apps. Specifically, the methods of the app delegate give you a chance to respond to important changes. For example, you use the methods of the app delegate to respond to state transitions, such as when your app moves from foreground to background execution, and to respond to incoming notifications. In many cases, the methods of the app delegate are the only way to receive these important notifications.
3. Xcode provides an app delegate class for every new project, so you do not need to define one yourself initially. When your app launches, UIKit automatically creates an instance of the app delegate class provided by Xcode and uses it to execute the first bits of custom code in your app. All you have to do is take the class that Xcode provides and add your custom code.
4. The app delegate is effectively the root object of your app. Like the UIApplication object itself, the app delegate is a singleton object and is always present at runtime. Although the UIApplication object does most of the underlying work to manage the app, you decide your app’s overall behavior by providing appropriate implementations of the app delegate’s methods. Although most methods of this protocol are optional, you should implement most or all of them.
5. Launch time is an important point in an app’s life cycle. At launch time, the app delegate is responsible for executing any custom code required to initialize your app. For example, the app delegate typically creates the app’s initial data structures, registers for any required services, and tweaks the app’s initial user interface based on any available data.

## UIKit > UIApplicationDelegate > func application(UIApplication, didFinishLaunchingWithOptions: [UIApplicationLaunchOptionsKey : Any]? = nil)
1. Tells the delegate that the launch process is almost done and the app is almost ready to run.
2. [Declaration] `optional func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplicationLaunchOptionsKey : Any]? = nil) -> Bool`
3. [Parameters]
- application: Your singleton app object.
- launchOptions: A dictionary indicating the reason the app was launched (if any). The contents of this dictionary may be empty in situations where the user launched the app directly. For information about the possible keys in this dictionary and how to handle them, see Launch Options Keys.
4. [Return Value] false if the app cannot handle the URL resource or continue a user activity, otherwise return true. The return value is ignored if the app is launched as a result of a remote notification.
5. [Discussion]
- Use this method (and the corresponding application(_:willFinishLaunchingWithOptions:) method) to complete your app’s initialization and make any final tweaks. This method is called after state restoration has occurred but before your app’s window and other UI have been presented. At some point after this method returns, the system calls another of your app delegate’s methods to move the app to the active (foreground) state or the background state.
- This method represents your last chance to process any keys in the launchOptions dictionary. If you did not evaluate the keys in your application(_:willFinishLaunchingWithOptions:) method, you should look at them in this method and provide an appropriate response.
- Objects that are not the app delegate can access the same launchOptions dictionary values by observing the notification named UIApplicationDidFinishLaunching and accessing the notification’s userInfo dictionary. That notification is sent shortly after this method returns.
- The return result from this method is combined with the return result from the application(_:willFinishLaunchingWithOptions:) method to determine if a URL should be handled. If either method returns false, the URL is not handled. If you do not implement one of the methods, only the return value of the implemented method is considered.

## Swift 3 '[UIApplicationLaunchOptionsKey : Any]?' is not convertible to '[String : NSString]'
1. You'd better work with [UIApplicationLaunchOptionsKey : Any] as it is.
````swift
if let launchOptions = launchOptions {
    for (kind, value) in launchOptions {
        appControllerContext.launchOptions[kind.rawValue] = value
    }
}
````

## UIKit > UIViewController
1. Provides the infrastructure for managing the views of your UIKit app.
1. A view controller manages a set of views that make up a portion of your app’s user interface. It is responsible for loading and disposing of those views, for managing interactions with those views, and for coordinating responses with any appropriate data objects. View controllers also coordinate their efforts with other controller objects—including other view controllers—and help manage your app’s overall interface.
1. You rarely create instances of the UIViewController class directly. Instead, you create instances of UIViewController subclasses and use those objects to provide the specific behaviors and visual appearances that you need.
