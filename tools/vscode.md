# vs code

<!-- MarkdownTOC -->

- How to open Visual Studio Code from the command line on OSX?
- Advanced search options

<!-- /MarkdownTOC -->

## How to open Visual Studio Code from the command line on OSX?
> Download, install and open Visual Studio Code for Mac.
> Open the Command Palette (⌘ + ⇧ + P on Mac)
> Type shell command to find  Shell Command: Install 'code' command in PATH command
> Install it and you're done

## Advanced search options
> In the input box below the search box, you can enter patterns to include or exclude from the search. If you enter example, that will match every folder and file named example in the workspace. If you enter ./example, that will match the folder example/ at the top level of your workspace. Use ! to exclude those patterns from the search. !example will skip searching any folder or file named example. You can also use glob syntax:
````text
	* to match one or more characters in a path segment
	? to match on one character in a path segment
	** to match any number of path segments, including none
	{} to group conditions (e.g. {**/*.html,**/*.txt} matches all HTML and text files)
	[] to declare a range of characters to match (e.g., example.[0-9] to match on example.0, example.1, …)
````
> VS Code excludes some folders by default to reduce the number of search results that you are not interested in (for example: node_modules). Open settings to change these rules under the files.exclude and search.exclude section.
> Also note the Use Exclude Settings and Ignore Files toggle button in the files to exclude box. The toggle determines whether to exclude files that are ignored by your .gitignore files and/or matched by your files.exclude and search.exclude settings.
