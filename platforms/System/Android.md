# Android

<!-- MarkdownTOC -->

- Android.gitignore
- Gradle android-apt plugin
- 解析包时出现问题
- gradle plugins : com.android.application source code
- Configure Your Build
- Android: API level VS. Android version
- Uses of API Level in Android
- Android Bundle

<!-- /MarkdownTOC -->

## Android.gitignore
> [github/gitignore](https://github.com/github/gitignore/blob/master/Android.gitignore)

## Gradle android-apt plugin
> [code](https://bitbucket.org/hvisser/android-apt)
> [blog](https://code.neenbedankt.com/gradle-android-apt-plugin/)
> The android-apt plugin assists in working with annotation processors in combination with Android Studio. It has two purposes:
- Allow to configure a compile time only annotation processor as a dependency, not including the artifact in the final APK or library
- Set up the source paths so that code that is generated from the annotation processor is correctly picked up by Android Studio.

## 解析包时出现问题
> 手机版本过低（只支持5.0以上）， 或者之前手机上已经有装同样的APP并且版本号大于或者等于新的安装包

## gradle plugins : com.android.application source code
> The source for com.android.application plugin is at: [link](https://android.googlesource.com/platform/tools/build/+/cab495f54cd31e4e93c36e6aa4b7af661aac2357/gradle/src/main/groovy/com/android/build/gradle/AppPlugin.groovy)
> The plugin name comes from this properties file [link](https://android.googlesource.com/platform/tools/base/+/e66115c586309759af1480d73c3d3a13bd0edd5f/build-system/gradle/src/main/resources/META-INF/gradle-plugins/com.android.application.properties)
> and its contents point to the class implementing it.
> [source code](https://android.googlesource.com/platform/tools/build), [source page](https://android.googlesource.com/platform/tools/build/)

## Configure Your Build
> [android doc - Configure Your Build](https://developer.android.com/studio/build/index.html)
> [gradle doc - The Application Plugin](https://docs.gradle.org/current/userguide/application_plugin.html)

## Android: API level VS. Android version
> [What is API Level?](https://developer.android.com/guide/topics/manifest/uses-sdk-element.html#ApiLevels)
````markdown
| API Level                 | VERSION_CODE     |
| -----------               | ---------------: |
| Android 8.1               | 27               |
| Android 8.0               | 26               |
| Android 7.1, 7.1.1        | 25 N_MR1         |
| Android 7.0               | 24 N             |
| Android 6.0               | 23 M             |
| Android 5.1               | 22 L             |
| Android 5.0               | 21 L             |
| Android 4.4w              | 20               |
| Android 4.4               | 19               |
| Android 4.3               | 18               |
| Android 4.2, 4.2.2        | 17               |
| Android 4.1, 4.1.1        | 16               |
| Android 4.0.3, 4.0.4      | 15               |
| Android 4.0, 4.0.1, 4.0.2 | 14               |
| Android 3.2               | 13               |
| Android 3.1.x             | 12               |
| Android 3.0.x             | 11               |
| Android 2.3.3, 2.3.4      | 10               |
````

## Uses of API Level in Android
> [link](https://developer.android.com/guide/topics/manifest/uses-sdk-element.html#ApiLevels)
> The API Level identifier serves a key role in ensuring the best possible experience for users and application developers:
> It lets the Android platform describe the maximum framework API revision that it supports
It lets applications describe the framework API revision that they require
It lets the system negotiate the installation of applications on the user's device, such that version-incompatible applications are not installed.
Each Android platform version stores its API Level identifier internally, in the Android system itself.
> Applications can use a manifest element provided by the framework API — <uses-sdk> — to describe the minimum and maximum API Levels under which they are able to run, as well as the preferred API Level that they are designed to support. The element offers three key attributes:
> android:minSdkVersion — Specifies the minimum API Level on which the application is able to run. The default value is "1".
android:targetSdkVersion — Specifies the API Level on which the application is designed to run. In some cases, this allows the application to use manifest elements or behaviors defined in the target API Level, rather than being restricted to using only those defined for the minimum API Level.
android:maxSdkVersion — Specifies the maximum API Level on which the application is able to run. Important: Please read the <uses-sdk> documentation before using this attribute.

## Android Bundle
> A mapping from String values to various Parcelable types.
> Bundle 类是一个 final 类， 是一个存储和管理 key-value 对的类，多应用于 Activity 之间相互传递值
