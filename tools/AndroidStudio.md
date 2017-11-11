# Android Studio
<!-- MarkdownTOC -->

- Error:Connection timed out: connect. If you are behind an HTTP proxy, please config
- Enable VT-x in BIOS
- Android Studio - How to Change Android SDK Path

<!-- /MarkdownTOC -->

## Error:Connection timed out: connect. If you are behind an HTTP proxy, please config
> First check your internet proxy settings copy the proxy settings like proxy host and port no. and go to your “gradle.properties” file in project and paste it like this: 
````
systemProp.http.proxyHost=127.0.0.1 
systemProp.http.proxyPort=1080 
systemProp.https.proxyHost=127.0.0.1 
systemProp.https.proxyPort=1080
````
## Enable VT-x in BIOS
> - Power on/Reboot the machine and open the BIOS (as per Step 1).
> - Open the Processor submenu The processor settings menu may be hidden in the Chipset, Advanced CPU Configuration or Northbridge.
> - Enable Intel Virtualization Technology (also known as Intel VT-x) or AMD-V depending on the brand of the processor. The virtualization extensions may be labelled Virtualization Extensions, Vanderpool or various other names depending on the OEM and system BIOS.
> - Select Save & Exit.

## Android Studio - How to Change Android SDK Path
> - command line
Changing the sdk location in Project Settings will solve the problem partially. When Android Studio is used to download a new SDK, it will place the new SDK in the internal SDK folder (inside Android Studio).
Existing android developers will already have a large sdks folder (hereinafter referred to as external SDK folder) containing all the SDKs downloaded before Android Studio came around.
For Mac/Linux users though there is a good way out. Soft links!
Exit Android Studio and perform the following steps:
```bash
cp -r <Android Studio>/sdk/ <external SDK folder>/
cd <Android Studio>/
mv <Android Studio>/sdk/ mv <Android Studio>/sdk.orig
ln -s <external SDK folder>/ sdk
````
And we're good to go. Launch SDK Manager after starting Android Studio, watch as it discovers all your existing SDKs like a charm :).
> - for projects default:
1. Close current Project (File->Close project)
You'll get a Welcome to Android Studio Dialog. In that:
2. Click on Configure -> Project Defaults -> Project Structure
3. Click on SDK Location in the left column
4. Put the path to the Android SDK in "Android SDK location" field.
(Example SDK location: C:\android-sdk; I have sub-folders like  add-ons, platforms etc under C:\android-sdk)
5. Click OK to save changes
6. Have fun!

