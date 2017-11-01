# sublime text
<!-- MarkdownTOC -->

- Setting
- Sublime Text from Command Line \(Win10\)
- memory too high
- Multiple Cursors in Sublime Text 2 Windows
- How to jump to previous and last cursor in Sublime Text 3?
- Vintage Mode \(Vi/Vim\)
- Search Filters
- Search – Single File
- Replace – Single File
- Sublime 3 Increase Goto Symbol Font Size
- HTML-CSS-JS Prettify
- Markdown Package
- React Package

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
>> ConvertToUTF8, BracketHighlighter, SidebarEnhancements, afterglow-theme, Sublime SFTP, TypeScript, LESS, Pretty JSON, DocBlockr, JavaScriptNext, SublimeLinter 3 (or Sublime-JSHint), HTML-CSS-JS Prettify, MarkdownTOC, JSX

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
1. [Table Editor](https://github.com/vkocubinsky/SublimeTableEditor)
> Table Editor is a package for the Sublime Text 2 and Sublime Text 3 editor for edit text tables. Table Editor is has almost the same keys as Emacs-org mode table editor.
2. [MarkdownTOC](https://github.com/naokazuterada/MarkdownTOC)
> Sublime Text 3 plugin for generating a Table of Contents (TOC) in a Markdown document.

## React Package
> 1. [JSX](https://github.com/allanhortle/JSX/)  - Syntax & Autocomplete
