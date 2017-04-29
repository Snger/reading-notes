## Multiple Cursors in Sublime Text 2 Windows
1. Windows : Extend selection upward/downward at all carets: Ctrl + Alt + Up/Down

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

