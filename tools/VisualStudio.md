## Write Faster Code by Adding VIM to Visual Studio
1. One of the greatest productivity gains you can make is to type less and navigate through your code faster. VsVim, is an extension for Visual Studio 2010 and later which will get you doing just that. To get VsVim, you can download it from the Visual Studio Gallery or via the extension manager in Visual Studio. Mastering VsVim takes an investment of time, but learning it will pay dividends.
2. In addition to all this, you still get IntelliSense, tab completion, snippets and all other base Visual Studio features when in insert mode. There's built in support for key binding collisions, enabling you to choose if VsVim or Visual Studio itself will handle the shortcuts; just click the options button in the bottom right of your code file. 
3. If you need to exit VsVim, you can temporarily disable (and restore) it by pressing `ctrl+Shift+F12`.

## toggle full screen
> Shift + Alt + Enter

## show the project manage view
> Alt + Ctrl + l
> Ctrl + Tab : come back to editer

## Package Manager Console
1. In all cases, you open the Console in Visual Studio through the Tools > NuGet Package Manager > Package Manager Console command.
2. At the top of the pane you can select the desired package source, manage sources (by clicking the gear icon), and select the default project to which commands will be applied.
3. You can override these settings with most commands by using the -Source and -ProjectName options.

## PM: Finding a package
1. In the console, Get-Package -ListAvailable see all the packages available from the selected source. For nuget.org, the list will contain thousands of packages, so it's helpful to use the -Filter switch along with -PageSize. In NuGet 3.0 and later, you can instead use the Find-Package command that is better suited to this operation.

## PM: Installing a package
1. Once you know the identifier of the package you want to install use Install-Package, such as Install-Package elmah.+
2. NuGet downloads the package from the specified package source and installs it in the default project of the solution, unless you specify another project using the -ProjectName switch.
3. Installing a package performs the following actions:
> 1. Display applicable license terms in the Console window with implied agreement. If you do not agree to the terms, you should uninstall the package immediately.
> 2. Creates a packages folder (if needed) and copies package files into a subfolder within it.
> 3. Adds references to the project, which subsequently appear in Solution Explorer
> 4. Updates app.config and/or web.config if the package uses source and config file transformations.
> 5. Installs any dependencies if not already present in the project. This might update package versions in the process, as described in Dependency Resolution.

## PM: Uninstalling a package
1. If you do not already know the name of the package you want to remove, use the Get-Package command with no parameters to see all of the currently-installed packages.
2. To uninstall a package, use Uninstall-Package with the package ID, such as Uninstall-Package jQuery.
3. Uninstalling a package performs the following actions:
> 1. References to the package no longer appear in the Reference or Bin  folders in Solution Explorer. (You might need to rebuild the project to see it removed from the Bin folder.)
> 2. The folder for the package is removed from the packages folder; the packages folder itself is deleted if no packages remain.
> 3. Any changes made to app.config or web.config when the package was installed are removed.
> 4. If other packages were installed because they were dependencies of the package that was removed, and if no remaining packages use those dependencies, the dependency packages are also removed.

## PM: Updating a package
1. The Get-Package -updates command checks if there are newer versions available for any installed packages.
2. To update a package, use Update-Package with the package ID, such as Update-Package jQuery.
