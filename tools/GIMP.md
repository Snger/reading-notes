# GIMP

<!-- MarkdownTOC -->

- Single-Window Mode
- Layer Groups
- [Simple Math In Size Entries][GIMP 2.8]
- How do I select a layer “sitting” under the mouse cursor in Gimp?
- Gimp: How can I change the text on a layer using Gimp
- How to extract text from a PSD file?
- printout the resources used in the PSD Imgae
- Change the Size of an Image for the screen

<!-- /MarkdownTOC -->

## Single-Window Mode
1. GIMP 2.8 introduces an optional single-window mode. You can toggle between the default multi-window mode and the new single-window mode through the Single-window mode checkbox in the Windows menu. In single-window mode, GIMP will put dockable dialogs and images in a single, tabbed image window. The single-window mode setting is of course preserved if you quit and start GIMP again. Single-window mode removes the necessity for users of having to deal with multiple windows.

## Layer Groups
1. For complex compositions, a flat layer structure is very limiting. GIMP 2.8 lets users organize their compositions better through the introduction of layer groups which allow layers to be organized in tree-like structures. Layer groups are fully scriptable through the GIMP plug-in API.

## Simple Math In Size Entries[GIMP 2.8]
1. Enhancements have also been made to the size entry widget, which is used for inputting most of the x, y, width, height parameters. For example, in the scale dialog it is now possible to write ‘50%’ in the Width field to scale the image to 50% of the width. Expressions such as ‘30in + 40px’ and ‘4 * 5.4in’ work, too.

## How do I select a layer “sitting” under the mouse cursor in Gimp?
> Open Gimp preferences by going to "Edit" menu.
> In "Preferences" dialog box click on "Tool Options" and enable the "set layer or path as active" option. Close the "Preferences".
> Select "Move Tool" (shortcut - m), Now Click on your desired object and it's layer will be selected automatically. Hare's an example! 

## Gimp: How can I change the text on a layer using Gimp
> Sorry - GIMP stable does not import the text information for PSD files - which means all it "sees" is pixels.
> A little bit over 10 years ago, Adobe completely closed the informations about the PSD file format, and the import/export for this format in GIMP stopped evolving. Some 2-3 years ago, the file format started being documented again - but GIMP is a developer-starved project, with few people working on it, everyone as volunteers. Last year, with the Google Summer of Code project, there was some development in the PSD plug-in, and there is some advances incorporated into the development version of GIMP.
> Looking from 10000 meters, it looks like there is logic in place to open the text layers preserving the text information on the new code. I can't be sure because I have no PSD file to test it here.
> If,as a workaround, you want to findout the typeface names inside the PSD files, in the past I made a simple Python script to print just that - then it is at least possible to recreate the same layer again inside GIMP: https://github.com/jsbueno/psd_print_resources

## How to extract text from a PSD file?
> VIM comes with a flag that lets you edit a binary file.
> `vim -b file.psd`

## printout the resources used in the PSD Imgae
> [This script](https://github.com/jsbueno/psd_print_resources/blob/master/psd_print_resources.py) simply parses file from a PSD Imgae (Adobe Phtooshop native image format), and printout the resources used in the file tagged with "/Name" -- most of them are font (typeface) names.
> Since GIMP as of 2.8 can't import Photoshop text layers as text, this script can help designers to see what fonts where used in a given image without resorting to a Photoshop install.

## Change the Size of an Image for the screen
> The first thing that you might notice after opening the image, is that GIMP opens the image at a logical size for viewing. If your image is very large, like the sample image, GIMP sets the zoom so that it displays nicely on the screen. The zoom level is shown in the status area at the bottom of the Image window. This does not change the actual image.
> The other thing to look at in the title-bar is the mode. If the mode shows as RGB in the title bar, you are fine. If the mode says Indexed or Grayscale, read the Section 4.7, “Change the Mode”.
> Use Image → Scale Image to open the “Scale Image” dialog. You can right click on the image to open the menu, or use the menu along the top of the Image window. Notice that the “Scale Image” menu item contains three dots, which is a hint that a dialog will be opened.
> The unit of size for the purpose of displaying an image on a screen is the pixel. You can see the dialog has two sections: one for width and height and another for resolution. Resolution applies to printing only and has no effect on the image's size when it is displayed on a monitor or a mobile device. The reason is that different devices have different pixels sizes and so, an image that displays on one device (such as a smartphone) with a certain physical size, might display on other devices (such as an LCD projector) in another size altogether. For the purpose of displaying an image on a screen, you can ignore the resolution parameter. For the same reason, do not use any size unit other than the pixel in the height / width fields.
