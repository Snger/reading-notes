# sublime text
<!-- MarkdownTOC -->

- Setting
- Sublime Text 3 : Can't find installed packages
- Sublime Text from Command Line \(Win10\)
- memory too high
- Multiple Cursors in Sublime Text 2 Windows
- How to jump to previous and last cursor in Sublime Text 3?
- Vintage Mode \(Vi/Vim\)
- VintageEx
- advanced Vim
- Emacs like keymaps
- Search Filters
- Search – Single File
- Replace – Single File
- Sublime 3 Increase Goto Symbol Font Size
- HTML-CSS-JS Prettify
- Markdown Package
- React Package
- Packages Location

<!-- /MarkdownTOC -->

## Setting
> - package control
````
- Ctrl+`
- subline text3
- import urllib.request,os; pf = 'Package Control.sublime-package'; ipp = sublime.installed_packages_path(); urllib.request.install_opener( urllib.request.build_opener( urllib.request.ProxyHandler()) ); open(os.path.join(ipp, pf), 'wb').write(urllib.request.urlopen( 'http://sublime.wbond.net/' + pf.replace(' ','%20')).read())
- subline text2
- import urllib2,os;pf='Package Control.sublime-package';ipp=sublime.installed_packages_path();os.makedirs(ipp) if not os.path.exists(ipp) else None;open(os.path.join(ipp,pf),'wb').write(urllib2.urlopen('http://sublime.wbond.net/'+pf.replace(' ','%20')).read())
````
>- Install Package
>> NeoVintageous, Emacs Pro Essentials(sublemacspro)
>> ConvertToUTF8, BracketHighlighter, SidebarEnhancements, afterglow-theme, Compare Side-By-Side, Sublime SFTP, DocBlockr
>> TypeScript, LESS, Pretty JSON, JavaScriptNext, SublimeLinter 3 (or Sublime-JSHint), HTML-CSS-JS Prettify(npm -g install js-beautify), MarkdownTOC, JSX
>> SublimeText-Nodejs(package name: Nodejs, npm install -g commander@"~2.9.0" uglify-js@"~2.6.0", config User -> Nodejs.sublime-settings and Nodejs.sublime-build)

## Sublime Text 3 : Can't find installed packages
> Sublime Text 3 uses .sublime-package zip files to store packages. In Windows, they are stored in AppData/Roaming/Sublime Text 3/Installed Packages. The easiest way to deal with them is to install the PackageResourceViewer plugin via Package Control. Once installed, it gives you Command Palette options to view, edit, and extract packages. 

## Sublime Text from Command Line (Win10)
1. `alias subl='/d/App/Sublime\ Text\ 3/subl.exe '`

## memory too high
1. set "index_files" to false
2. File indexing parses all files in the side bar, and builds an index of their symbols. This is required for Goto Definition to work.

## Multiple Cursors in Sublime Text 2 Windows
1. Windows : Extend selection upward/downward at all carets: Ctrl + Alt + Up/Down

## How to jump to previous and last cursor in Sublime Text 3?
1. Alt + - : Jump Back and Jump Forward – Jump Back allows you to go to previous editing positions. This goes hand in hand with Goto Definition: you can now inspect a symbol definition, and quickly jump back to where you were previously. Jump Back is bound to Alt+Minus by default. The menu entry is Goto > Jump Back
2. Alt + Shift - : Jump forward

## Vintage Mode (Vi/Vim)
1. Vintage is a vi mode editing package for Sublime Text. It allows you to combine vi's command mode with Sublime Text's features, including multiple selections.
2. Vintage is disabled by default, via the ignored_packages setting. If you remove "Vintage" from the list of ignored packages, you'll be able to edit with vi keys
3. Vintage starts in insert mode by default. This can be changed by adding the following setting to your user settings: "vintage_start_in_command_mode": true

## VintageEx
> [but not support to Sublime Text 3](https://github.com/SublimeText/VintageEx/issues/52)
> [VintageEx](https://github.com/SublimeText/VintageEx) gives you a Vim-like command-line where you can at least perform substitutions. Well, that's how far I went when trying it. I don't know how extended the subset of Vim commands it implements is but I'd guess that it's not as large as the original and, like with Vintage, probably different and unsettling enough to keep a relatively experienced Vimmer out.
> Anyway, I just tried it again and indeed you can more or less do the kind of substitution you are looking for, which instantly makes ST a lot more useful:
````vi
:3,5s/foo/bar/g
:.,5s/bar/foo/g
:,5/foo/bar/g
:,+5/bar/foo/g
````
> Unfortunately, it doesn't support the /c flag.

## advanced Vim
> [NeoVintageous](https://github.com/NeoVintageous/NeoVintageous) An advanced Vim emulation layer for Sublime Text (Vintageous fork).
> [Sublime Six](https://github.com/guillermooo/Six) is an advanced Vim emulator implemented entirely as a Python plugin.
> [Vintageous](https://github.com/guillermooo/Vintageous) is a comprehensive vi/Vim emulation layer for Sublime Text 3.

## Emacs like keymaps
> [Emacs Pro Essentials](https://github.com/sublime-emacs/sublemacspro) brings the most common emacs features and key bindings that you love to Sublime Text.
> User keymap
	{ "keys": ["alt+x"], "command": "show_overlay", "args": {"overlay": "goto", "show_files": true} },
    {"keys": ["alt+shift+-"], "command": "redo"},
> paste from global clipboard `ctrl_y` (emacs)
> paste from sublime text vim clipboard `p` (vim)
> save, `ctrl+x,ctrl+s` (emacs), or `:w` (vim)
> new file, `ctrl+x,ctrl+f` (emacs)
> close file, `ctrl+x,0` (emacs), `:q` (vim)

## Search Filters
1. The Where field in Find in Files limits the search scope. You can define filters in several ways:
> * Adding individual directories (Unix-style paths, even on Windows)
> * Adding/excluding files based on wildcards
> * Adding symbolic locations (<open folders>, <open files>...)
2. Relative paths in filters are interpreted to start at the root of the active project.
3. It is also possible to combine filters using commas. You can combine filters in any order.
4. Press the ... button in the search panel to display a menu containing filtering options.
5. (In the Where field, add this filter: `target/`) The filter means "Search in any files that have a folder named `target` in the path. Specify additional subdirectories by separating with commas, e.g. target/foo/,other/bar/.

## Search – Single File
> Open search panel: Ctrl + F
> Toggle regular expressions: Alt + R
> Toggle case sensitivity: Alt + C
> Toggle exact match: Alt + W
> Find next: Enter
> Find previous: Shift + Enter
> Find all: Alt + Enter

## Replace – Single File
> Open replace panel:  Ctrl + H
> Replace next:    Ctrl + Shift + H
> Replace all:  Ctrl + Alt + Enter

## Sublime 3 Increase Goto Symbol Font Size
1. [Quick Panel](http://www.sublimetext.com/docs/3/themes.html#filter_label_properties)
2. quick_panel_label: Filenames in quick_panel_row and all text in mini_quick_panel_row
3. quick_panel_path_label: File paths in quick_panel_row
4. Filter Label Properties: font.size - an integer point size

## HTML-CSS-JS Prettify
1. install: HTML-CSS-JS Prettify
2. usage: htmlprettify
3. config: https://packagecontrol.io/packages/HTML-CSS-JS%20Prettify

## Markdown Package
> 1. [Table Editor](https://github.com/vkocubinsky/SublimeTableEditor)
> Table Editor is a package for the Sublime Text 2 and Sublime Text 3 editor for edit text tables. Table Editor is has almost the same keys as Emacs-org mode table editor.
For first time you should enable table editor with command palette:
> - click ctrl+shift+p
> - select Table Editor: Enable for current syntax or Table Editor: Enable for current view or "Table Editor: Set table syntax ... for current view"
Then when Table Editor is enabled, type
````markdown
| Name | Phone |
|-
Then press Tab key, you will get pretty printed table
| Name | Phone |
|------|-------|
| _    |       |
````
2. [MarkdownTOC](https://github.com/naokazuterada/MarkdownTOC)
> Sublime Text 3 plugin for generating a Table of Contents (TOC) in a Markdown document.

## React Package
> 1. [JSX](https://github.com/allanhortle/JSX/)  - Syntax & Autocomplete

## Packages Location
> Zipped packages may be stored in:
	<executable_path>/Packages/
	<data_path>/Installed Packages/
> Loose packages may be stored in:
	<data_path>/Packages/
> For example, the package Python is stored in <executable_path>/Packages/Python.sublime-package, and any files in the <data_path>/Packages/Python/ directory will override those stored in the .sublime-package file.
> In general, <executable_path>/Packages/ is for packages that ship with Sublime Text, and <data_path>/Installed Packages/ is for packages installed by the user.
> - Special Packages
> There are two special packages: Default and User. Default is always ordered first, and User is always ordered last. Package ordering comes into effect when merging files between packages, for example Main.sublime-menu. Any package may contain a file called Main.sublime-menu, however this won't override the main menu, instead the files will be merged according to the order of the packages.
> Packages other than Default and User are ordered alphabetically.
