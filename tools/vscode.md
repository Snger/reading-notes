# vs code

<!-- MarkdownTOC -->

- Settings Sync
- How to open Visual Studio Code from the command line on OSX?
- Advanced search options
- 显示"没有活动的源代码控制提供程序“处理
- git extension
- VSCode 快捷键

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

## VSCode 快捷键
**全局**
Ctrl + Shift + P, F1 显示命令面板
Ctrl + P 快速打开
Ctrl + Shift + N 打开新窗口
Ctrl + Shift + W 关闭窗口
**基本**
Ctrl + X 剪切（未选中文本的情况下，剪切光标所在行）
Ctrl + C 复制（未选中文本的情况下，复制光标所在行）
Alt + Up 向上移动行
Alt + Down 向下移动行
Shift + Alt + Up 向上复制行
Shift + Alt + Down 向下复制行
Ctrl + Shift + K 删除行
Ctrl + Enter 下一行插入
Ctrl + Shift + Enter 上一行插入
Ctrl + Shift + \ 跳转到匹配的括号
Ctrl + ] 增加缩进
Ctrl + [ 减少缩进
Home 跳转至行首
End 跳转到行尾
Ctrl + Home 跳转至文件开头
Ctrl + End 跳转至文件结尾
Ctrl + Up 按行向上滚动
Ctrl + Down 按行向下滚动
Alt + PgUp 按屏向上滚动
Alt + PgDown 按屏向下滚动
Ctrl + Shift + [ 折叠代码块
Ctrl + Shift + ] 展开代码块
Ctrl + K Ctrl + [ 折叠全部子代码块
Ctrl + K Ctrl + ] 展开全部子代码块
Ctrl + K Ctrl + 0 折叠全部代码块
Ctrl + K Ctrl + J 展开全部代码块
Ctrl + K Ctrl + C 添加行注释
Ctrl + K Ctrl + U 移除行注释
Ctrl + / 添加、移除行注释
Shift + Alt + A 添加、移除块注释
Alt + Z 自动换行、取消自动换行
**多光标与选择**
Alt + 点击 插入多个光标
Ctrl + Alt + Up 向上插入光标
Ctrl + Alt + Down 向下插入光标
Ctrl + U 撤销上一个光标操作
Shift + Alt + I 在所选行的行尾插入光标
Ctrl + I 选中当前行
Ctrl + Shift + L 选中所有与当前选中内容相同部分
Ctrl + F2 选中所有与当前选中单词相同的单词
Shift + Alt + Left 折叠选中
Shift + Alt + Right 展开选中
Shift + Alt + 拖动鼠标 选中代码块
Ctrl + Shift + Alt + Up 列选择 向上
Ctrl + Shift + Alt + Down 列选择 向下
Ctrl + Shift + Alt + Left 列选择 向左
Ctrl + Shift + Alt + Right 列选择 向右
Ctrl + Shift + Alt + PgUp 列选择 向上翻页
Ctrl + Shift + Alt + PgDown 列选择 向下翻页
**查找替换**
Ctrl + F 查找
Ctrl + H 替换
F3 查找下一个
Shift + F3 查找上一个
Alt + Enter 选中所有匹配项
Ctrl + D 向下选中相同内容
Ctrl + K Ctrl + D 移除前一个向下选中相同内容
Alt + C 区分大小写
Alt + R 正则
Alt + W 完整匹配
**进阶**
Ctrl + Space 打开建议
Ctrl + Shift + Space 参数提示
Tab Emmet插件缩写补全
Shift + Alt + F 格式化
Ctrl + K Ctrl + F 格式化选中内容
F12 跳转到声明位置
Alt + F12 查看具体声明内容
Ctrl + K F12 分屏查看具体声明内容
Ctrl + . 快速修复
Shift + F12 显示引用
F2 重命名符号
Ctrl + Shift + . 替换为上一个值
Ctrl + Shift + , 替换为下一个值
Ctrl + K Ctrl + X 删除行尾多余空格
Ctrl + K M 更改文件语言
**导航**
Ctrl + T 显示所有符号
Ctrl + G 跳转至某行
Ctrl + P 跳转到某个文件
Ctrl + Shift + O 跳转到某个符号
Ctrl + Shift + M 打开问题面板
F8 下一个错误或警告位置
Shift + F8 上一个错误或警告位置
Ctrl + Shift + Tab 编辑器历史记录
Alt + Left 后退
Alt + Right 前进
Ctrl + M 切换焦点
**编辑器管理**
Ctrl + F4, Ctrl + W 关闭编辑器
Ctrl + K F 关闭文件夹
Ctrl + \ 编辑器分屏
Ctrl + 1 切换到第一分组
Ctrl + 2 切换到第二分组
Ctrl + 3 切换到第三分组
Ctrl + K Ctrl + Left 切换到上一分组
Ctrl + K Ctrl + Right 切换到下一分组
Ctrl + Shift + PgUp 左移编辑器
Ctrl + Shift + PgDown 右移编辑器
Ctrl + K Left 激活左侧编辑组
Ctrl + K Right 激活右侧编辑组
**文件管理**
Ctrl + N 新建文件
Ctrl + O 打开文件
Ctrl + S 保存
Ctrl + Shift + S 另存为
Ctrl + K S 全部保存
Ctrl + F4 关闭
Ctrl + K Ctrl + W 全部关闭
Ctrl + Shift + T 重新打开被关闭的编辑器
Ctrl + K Enter 保持打开
Ctrl + Tab 打开下一个
Ctrl + Shift + Tab 打开上一个
Ctrl + K P 复制当前文件路径
Ctrl + K R 在资源管理器中查看当前文件
Ctrl + K O 新窗口打开当前文件
**显示**
F11 全屏、退出全屏
Shift + Alt + 1 切换编辑器分屏方式（横、竖）
Ctrl + + 放大
Ctrl + - 缩小
Ctrl + B 显示、隐藏侧边栏
Ctrl + Shift + E 显示资源管理器 或 切换焦点
Ctrl + Shift + F 显示搜索框
Ctrl + Shift + G 显示Git面板
Ctrl + Shift + D 显示调试面板
Ctrl + Shift + X 显示插件面板
Ctrl + Shift + H 全局搜索替换
Ctrl + Shift + J 显示、隐藏高级搜索
Ctrl + Shift + C 打开新命令提示符窗口
Ctrl + Shift + U 显示输出面板
Ctrl + Shift + V 显示、隐藏 Markdown预览窗口
Ctrl + K V 分屏显示 Markdown预览窗口
**调试**
F9 设置 或 取消断点
F5 开始 或 继续
F11 进入
Shift + F11 跳出
F10 跳过
Ctrl + K Ctrl + I 显示悬停信息
**集成终端**
Ctrl + ` 显示命令提示符窗口
Ctrl + Shift + ` 新建命令提示符窗口
Ctrl + Shift + C 复制所选内容
Ctrl + Shift + V 粘贴所选内容
Ctrl + Up 向上滚动
Ctrl + Down 向下滚动
Shift + PgUp 向上翻页
Shift + PgDown 向下翻页
Ctrl + Home 滚动到顶部
Ctrl + End 滚sh动到底部

