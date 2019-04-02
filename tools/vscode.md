# vs code

<!-- MarkdownTOC -->

- Settings Sync
- How to open Visual Studio Code from the command line on OSX?
- Advanced search options
- 显示"没有活动的源代码控制提供程序“处理
- git extension

<!-- /MarkdownTOC -->

## Settings Sync
> Synchronize Settings, Snippets, Themes, File Icons, Launch, Keybindings, Workspaces and Extensions Across Multiple Machines Using GitHub Gist.

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

## 显示"没有活动的源代码控制提供程序“处理
> 1、扩展程序git可能未启动
扩展程序——输入**@builtin**——找到git——启动——重启vscode
2、配置git.path
进入setting位置：
在设置中找到“git.path”，会发现后面路径为null，修改为git的安装位置。
“git.path”: “D:/Program Files/Git/bin/git.exe”
3、重启

## git extension
> 1. Git History Diff
GitHD aims to bring the most useful git history inside with the simplest and the most convenient way.
2. Git File History
Quickly browse the history of a file from any git repository.(like website)
3. GitLens — Git supercharged
GitLens simply helps you better understand code. Quickly glimpse into whom, why, and when a line or code block was changed. Jump back through history to gain further insights as to how and why the code evolved. Effortlessly explore the history and evolution of a codebase.
