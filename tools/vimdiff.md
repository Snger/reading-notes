# vimdiff

<!-- MarkdownTOC -->

- Use vimdiff as git mergetool
- Resolving merge conflict with vimdiff
- 启动vimdiff
- 窗口布局切换
- 窗口焦点切换，即切换当前窗口
- 光标移动
- 上下文折叠
- 文件合并
- 文件操作

<!-- /MarkdownTOC -->

## Use vimdiff as git mergetool
> - Git config
Prior to doing anything, you need to know how to set vimdiff as a git mergetool. That being said:
````bash
git config merge.tool vimdiff
git config merge.conflictstyle diff3
git config mergetool.prompt false
````
> This will set git as the default merge tool, will display a common ancestor while merging, and will disable the prompt to open the vimdiff.

## Resolving merge conflict with vimdiff
> Let’s resolve the conflict:
git mergetool
> From left to right, top to the bottom:
> LOCAL – this is file from the current branch BASE – common ancestor, how file looked before both changes REMOTE – file you are merging into your branch MERGED – merge result, this is what gets saved in the repo
> Let’s assume that we want to keep the “octodog” change (from REMOTE). For that, move to the MERGED file (Ctrl + w, j), move your cursor to a merge conflict area and then:
````bash
:diffget RE
````
This gets the corresponding change from REMOTE and puts it in MERGED file. You can also:
````bash
:diffg RE  " get from REMOTE
:diffg BA  " get from BASE
:diffg LO  " get from LOCAL
````
> Save the file and quit (a fast way to write and quit multiple files is :wqa).
> Run git commit and you are all set!

## 启动vimdiff
> 方法一：# vimdiff  FILE_LEFT  FILE_RIGHT
方法二：# vim -d  FILE_LEFT  FILE_RIGHT
方法三：# vim FILE_LEFT 之后打开vim后输入:vertical diffsplit FILE_RIGHT

## 窗口布局切换
````vimdiff
Ctrl-w K（把当前窗口移到最上边）
Ctrl-w H（把当前窗口移到最左边）
Ctrl-w J（把当前窗口移到最下边）
Ctrl-w L（把当前窗口移到最右边）
````

## 窗口焦点切换，即切换当前窗口
````vimdiff
CTRL-w h 跳转到左边的窗口
CTRL-w j 跳转到下面的窗口
CTRL-w k 跳转到上面的窗口
CTRL-w l 跳转到右边的窗口
CTRL-w t 跳转到最顶上的窗口
CTRL-w b 跳转到最底下的窗口
CTRL-w w 跳转到另一个窗口
CTRL-w CTRL-w 跳转到另一个窗口，同CTRL-w w
````

## 光标移动
> 移动光标，切分窗口会同步移动，使用:set noscrollbind命令可取消同步
````vimdiff
]c 跳到下一个不同的地方
[c 跳到上一个不同的地方
````

## 上下文折叠
> 默认情况下，vimdiff会将文件中不同之处上下6行之外的相同文本折叠隐藏，可通过 :set diffopt=context:3 修改显示的上下文行数。
````vimdiff
zo 打开折叠
zc 关闭折叠
````

## 文件合并
````vimdiff
dp 将当前窗口光标位置处的内容复制到另一窗口
do 将另一窗口光标位置处的内容复制到当前窗口
diffupdate 重新比较两个文件，如果手动修改文件的话有时不会自动同步
````

## 文件操作
````vimdiff
yy 复制当前行
nyy 复制当前行开始的n行
dd 删除当前行
ndd 删除当前行开始的n行
p 粘贴
u 撤销
CTRL-r 重复(即取消撤销)
wa 全部保存
wqa 全部保存后退出
qa 全部退出
qa! 全部强制退出，不保存文件修改
````
