## Write Faster Code by Adding VIM to Visual Studio
1. One of the greatest productivity gains you can make is to type less and navigate through your code faster. VsVim, is an extension for Visual Studio 2010 and later which will get you doing just that. To get VsVim, you can download it from the Visual Studio Gallery or via the extension manager in Visual Studio. Mastering VsVim takes an investment of time, but learning it will pay dividends.
2. In addition to all this, you still get IntelliSense, tab completion, snippets and all other base Visual Studio features when in insert mode. There's built in support for key binding collisions, enabling you to choose if VsVim or Visual Studio itself will handle the shortcuts; just click the options button in the bottom right of your code file. 
3. If you need to exit VsVim, you can temporarily disable (and restore) it by pressing `ctrl+Shift+F12`.
4. [notes: back reference regex in VsVim] You need to escape the parentheses to make them work as groupings rather than as actual matches in the text, and not escape the $.

## toggle full screen
> Shift + Alt + Enter

## show the project manage view
> Alt + Ctrl + l
> Ctrl + Tab : come back to editer

## setting vs
1. vsVim: keybinding - Ctrl + r - use vim
2. debug config: uncheck only my code
3. nuget package config
4. debug config: symbol(.pdb) position - http://localhost:33417/ D:\workspace\VS-SymbolCache

## clipboard different from the system one
1. VsVim uses the gVim settings which will default to using the unnamed register for edit and paste commands. But it also implements the clipboard option which allows you to use the Windows System clipboard instead of the unnamed register.
2. To get this behavior put the following in your vimrc file
> `set clipboard=unnamed`

## Package Manager Console
1. In all cases, you open the Console in Visual Studio through the Tools > NuGet Package Manager > Package Manager Console command.
2. At the top of the pane you can select the desired package source, manage sources (by clicking the gear icon), and select the default project to which commands will be applied.
3. You can override these settings with most commands by using the -Source and -ProjectName options.

## Restore packages for all projects in the solution
Update-Package -reinstall

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

## How to: Display Line Numbers in the Editor?
1. On the menu bar, choose Tools, Options. Expand the Text Editor node, and then select either the node for the language you are using, or All Languages to turn on line numbers in all languages. Or you can type line number in the Quick Launch box.

## Difference between Build Solution, Rebuild Solution, and Clean Solution in Visual Studio?
1. Build means compile and link only the source files that have changed since the last build, while Rebuild means compile and link all source files regardless of whether they changed or not. Build is the normal thing to do and is faster. Sometimes the versions of project target components can get out of sync and rebuild is necessary to make the build successful. In practice, you never need to Clean.
2. Build solution: Compiles code files (DLL and EXE) which are changed.
3. Rebuild: Deletes all compiled files and compiles them again irrespective if the code has changed or not.
4. Clean solution: Deletes all compiled files (DLL and EXE file).
5. The difference between Rebuild vs. (Clean + Build), because there seems to be some confusion around this as well:The difference is the way the build and clean sequence happens for every project. Let’s say your solution has two projects, “proj1” and “proj2”. If you do a rebuild it will take “proj1”, clean (delete) the compiled files for “proj1” and build it. After that it will take the second project “proj2”, clean compiled files for “proj2” and compile “proj2”.
6. But if you do a “clean” and build”, it will first delete all compiled files for “proj1” and “proj2” and then it will build “proj1” first followed by “proj2”.

## What is the difference between XML and XSD?
1. Actually the xsd is xml itself. Its purpose is to validate the structure of another xml document. The xsd is not mandatory for any xml, but it assures that the xml could be used for some particular purposes. The xml is only containing data in suitable format and structure.
2. Xml: XML was designed to describe data.It is independent from software as well as hardware.
3. XSD: XSD (XML Schema Definition) specifies how to formally describe the elements in an Extensible Markup Language (XML) document.
4. It enhances the following things.
- Data sharing.
- Platform independent.
- Increasing the availability of Data.
5. Differences:
- XSD is based and written on XML.
- XSD defines elements and structures that can appear in the document, while XML does not.
- XSD ensures that the data is properly interpreted, while XML does not.
- An XSD document is validated as XML, but the opposite may not always be true.
- XSD is better at catching errors than XML.
- An XSD defines elements that can be used in the documents, relating to the actual data with which it is to be encoded.
6. for eg: A date that is expressed as 1/12/2010 can either mean January 12 or December 1st. Declaring a date data type in an XSD document, ensures that it follows the format dictated by XSD.

## CopyLocal Property (Reference Object)
1. Determines whether the reference is copied to the local bin path. At run time, a reference must exist in either the global cache assembly or the output path of the project. If this property is set to true, the reference is copied to the output path of the project at run time.
2. [Remarks] At run time, assemblies must be in one of two locations: the output path of the project or the global assembly cache (see Working with Assemblies and the Global Assembly Cache). If the project contains a reference to an object that is not in one of these locations, then when the project is built, the reference must be copied to the output path of the project. The CopyLocal property indicates whether this copy needs to be made. If the value is true, the reference is copied. If false, the reference is not copied.
3. [Remarks] The common language runtime does not track the changes to the reference to determine if the local copy needs to be updated. Changes are tracked by the project system. As long as the user has not overridden the CopyLocal property, the value will be automatically updated by the project system if needed.

## Metadata file '.dll' exist but could not be found (for some project)
1. Restart VS and try building again.
2. Go to 'Solution Explorer'. Right click on Solution. Go to Properties. Go to 'Configuration Manager'. Check if the checkboxes under 'Build' are checked or not. If any or all of them are unchecked, then check them and try building again.
3. If the above solution(s) do not work, then follow sequence mentioned in step 2 above, and even if all the checkboxes are checked, uncheck them, check again and try to build again.
4. Build Order and Project Dependencies: Go to 'Solution Explorer'. Right click on Solution. Go to 'Project Dependencies...'. You will see 2 tabs: 'Dependencies' and 'Build Order'. This build order is the one in which solution builds. Check the project dependencies and the build order to verify if some project (say 'project1') which is dependent on other (say 'project2') is trying to build before that one (project2). This might be the cause for the error.
5. Check the path of the missing .dll: Check the path of the missing .dll. If the path contains space or any other invalid path character, remove it and try building again.

## Debug Error: The source file is different from when the module was built
1. Go to Tools -> Options -> Debugging -> General and uncheck "Require source files to exactly match the original version". It allows you to use source code which is not the same as original version.
2. Right click your breakpoint for debugging and select Location, please check "Allow the source code to be different from the original version".

## Getting the PublicKeyToken of .Net assemblies
1. Open a command prompt and type one of the following lines according to your Visual Studio version and Operating System Architecture :
> VS 2015 on 64bit Windows :
> "%ProgramFiles(x86)%\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\sn.exe" -T <assemblyname>
> sn -T <assembly> 
1. where <assemblyname> is a full file path to the assembly you're interested in, surrounded by quotes if it has spaces.

## How can you disable Git integration in Visual Studio 2013 permanently?
1. path\to\vs2017\Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git
> change mingw32 to mingw64
2. As you said you can disable the source control plugin going to:
> Tools / Options
> Check "Show all settings"
> Source Control / Plug-in Selection
> Set "Current source control plug-in" to "None"
> Then, as Ade Miller says: Restart Visual Studio.
> My Visual Studio was working really slow since the git plugging was enabled and I managed to disable it "persistently across sessions" following this steps.
