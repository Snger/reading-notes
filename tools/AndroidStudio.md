# Android Studio
<!-- MarkdownTOC -->

- Error:Connection timed out: connect. If you are behind an HTTP proxy, please config
- Enable VT-x in BIOS

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
