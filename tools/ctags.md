# ctags

<!-- MarkdownTOC -->

- What is ctags?
- ctags识别很多语言，可以用如下命令来查看
- 用如下命令来查看默认哪些扩展名对应哪些语言：
- 如下命令告知ctags，以inl为扩展名的文件是c++文件。
- 用如下命令查看ctags可以识别的语法元素：
- 单独查看可以识别的c++的语法元素
- 如下命令要求ctags记录c++文件中的函数声明和各种外部和前向声明：
- 强制ctags给类的成员函数多记一行的命令为：
- Tags file formats
    - Proposed tagfield names:
- Modern JavaScript ctags configuration
    - Generating ctags
    - Jumping to a definition under the cursor
    - Searching the available tags
    - Navigating through multiple matches
    - Your new .ctags file
    - Wrapping it up into an alias
- Ctags with Swift

<!-- /MarkdownTOC -->

## What is ctags?
> Ctags generates an index (or tag) file of language objects found in source files that allows these items to be quickly and easily located by a text editor or other utility. A tag signifies a language object for which an index entry is available (or, alternatively, the index entry created for that object).

## ctags识别很多语言，可以用如下命令来查看
`ctags --list-languages`

## 用如下命令来查看默认哪些扩展名对应哪些语言：
`ctags --list-maps`

## 如下命令告知ctags，以inl为扩展名的文件是c++文件。
`ctags --langmap=c++:+.inl –R`

## 用如下命令查看ctags可以识别的语法元素：
`ctags --list-kinds`

## 单独查看可以识别的c++的语法元素
`ctags --list-kinds=c++`

## 如下命令要求ctags记录c++文件中的函数声明和各种外部和前向声明：
`ctags -R --c++-kinds=+px`

## 强制ctags给类的成员函数多记一行的命令为：
`ctags -R --extra=+q`

## Tags file formats
> A tags file that is generated in the new format should still be usable by Vi.
This makes it possible to distribute tags files that are usable by all
versions and descendants of Vi.
This restricts the format to what Vi can handle.  The format is:
1. The tags file is a list of lines, each line in the format:
````tagFormat
	{tagname}<Tab>{tagfile}<Tab>{tagaddress}
   {tagname}	Any identifier, not containing white space..
   <Tab>	Exactly one TAB character (although many versions of Vi can
		handle any amount of white space).
   {tagfile}	The name of the file where {tagname} is defined, relative to
   		the current directory (or location of the tags file?).
   {tagaddress}	Any Ex command.  When executed, it behaves like 'magic' was
		not set.
````
2. The tags file is sorted on {tagname}.  This allows for a binary search in the file.
3. Duplicate tags are allowed, but which one is actually used is unpredictable (because of the binary search).
### Proposed tagfield names:
[link](http://ctags.sourceforge.net/FORMAT)
````desc
FIELD-NAME	DESCRIPTION
arity		Number of arguments for a function tag.
class		Name of the class for which this tag is a member or method.
enum		Name of the enumeration in which this tag is an enumerator.
file		Static (local) tag, with a scope of the specified file.  When
		the value is empty, {tagfile} is used.
function	Function in which this tag is defined.  Useful for local
		variables (and functions).  When functions nest (e.g., in
		Pascal), the function names are concatenated, separated with
		'/', so it looks like a path.
kind		Kind of tag.  The value depends on the language.  For C and
		C++ these kinds are recommended:
		c	class name
		d	define (from #define XXX)
		e	enumerator
		f	function or method name
		F	file name
		g	enumeration name
		m	member (of structure or class data)
		p	function prototype
		s	structure name
		t	typedef
		u	union name
		v	variable
		When this field is omitted, the kind of tag is undefined.
struct		Name of the struct in which this tag is a member.
union		Name of the union in which this tag is a member.
````

## Modern JavaScript ctags configuration
> [link](https://medium.com/adorableio/modern-javascript-ctags-configuration-199884dbcc1)
### Generating ctags
I use ctags to jump to the definition of a symbol in a given project. There are generally two ways I achieve this: from a cursor over the top of a symbol and using normal-mode commands to search the list of defined tags.
### Jumping to a definition under the cursor
While reading code and the cursor is on top of a known symbol, pressing Ctrl+] will jump to that definition.
### Searching the available tags
If you know the tag you want but are nowhere near it, you can :tag <tagname> to jump to it’s definition. The :tag command supports tab completion; I often use :tag searches to jump to class or constant definitions.
### Navigating through multiple matches
Either of these ways of jumping to definition may result in multiple tag matches. You can navigate the tag stack with :tnext (briefly, as :tn) or :tprevious (:tp). If you’d like to see a list of definitions found for any given tag, you can :tselect (:tsel).

### Your new .ctags file
> After a bit of pruning and studying, this is the JavaScript-specific portion of my ~/.ctags file looks like this:
````ctag
--exclude=node_modules
--exclude=gulp
--languages=-javascript
--langdef=js
--langmap=js:.js
--langmap=js:+.jsx
// js
--regex-js=/[ \t.]([A-Z][A-Z0-9._$]+)[ \t]*[=:][ \t]*([0-9"'\[\{]|null)/\1/n,constant/
--regex-js=/\.([A-Za-z0-9._$]+)[ \t]*=[ \t]*\{/\1/o,object/
--regex-js=/['"]*([A-Za-z0-9_$]+)['"]*[ \t]*:[ \t]*\{/\1/o,object/
--regex-js=/([A-Za-z0-9._$]+)\[["']([A-Za-z0-9_$]+)["']\][ \t]*=[ \t]*\{/\1\.\2/o,object/
--regex-js=/([A-Za-z0-9._$]+)[ \t]*=[ \t]*\(function\(\)/\1/c,class/
--regex-js=/['"]*([A-Za-z0-9_$]+)['"]*:[ \t]*\(function\(\)/\1/c,class/
--regex-js=/class[ \t]+([A-Za-z0-9._$]+)[ \t]*/\1/c,class/
--regex-js=/([A-Za-z$][A-Za-z0-9_$()]+)[ \t]*=[ \t]*[Rr]eact.createClass[ \t]*\(/\1/c,class/
--regex-js=/([A-Z][A-Za-z0-9_$]+)[ \t]*=[ \t]*[A-Za-z0-9_$]*[ \t]*[{(]/\1/c,class/
--regex-js=/([A-Z][A-Za-z0-9_$]+)[ \t]*:[ \t]*[A-Za-z0-9_$]*[ \t]*[{(]/\1/c,class/
--regex-js=/([A-Za-z$][A-Za-z0-9_$]+)[ \t]*=[ \t]*function[ \t]*\(/\1/f,function/
--regex-js=/(function)*[ \t]*([A-Za-z$_][A-Za-z0-9_$]+)[ \t]*\([^)]*\)[ \t]*\{/\2/f,function/
--regex-js=/['"]*([A-Za-z$][A-Za-z0-9_$]+)['"]*:[ \t]*function[ \t]*\(/\1/m,method/
--regex-js=/([A-Za-z0-9_$]+)\[["']([A-Za-z0-9_$]+)["']\][ \t]*=[ \t]*function[ \t]*\(/\2/m,method/
// js
--langdef=typescript
--langmap=typescript:.ts
--regex-typescript=/^[ \t]*(export)?[ \t]*class[ \t]+([a-zA-Z0-9_]+)/\2/c,classes/
--regex-typescript=/^[ \t]*(export)?[ \t]*module[ \t]+([a-zA-Z0-9_]+)/\2/n,modules/
--regex-typescript=/^[ \t]*(export)?[ \t]*function[ \t]+([a-zA-Z0-9_]+)/\2/f,functions/
--regex-typescript=/^[ \t]*export[ \t]+var[ \t]+([a-zA-Z0-9_]+)/\1/v,variables/
--regex-typescript=/^[ \t]*var[ \t]+([a-zA-Z0-9_]+)[ \t]*=[ \t]*function[ \t]*\(\)/\1/v,varlambdas/
--regex-typescript=/^[ \t]*(export)?[ \t]*(public|private)[ \t]+(static)?[ \t]*([a-zA-Z0-9_]+)/\4/m,members/
--regex-typescript=/^[ \t]*(export)?[ \t]*interface[ \t]+([a-zA-Z0-9_]+)/\2/i,interfaces/
--regex-typescript=/^[ \t]*(export)?[ \t]*enum[ \t]+([a-zA-Z0-9_]+)/\2/e,enums/
--regex-typescript=/^[ \t]*import[ \t]+([a-zA-Z0-9_]+)/\1/I,imports/
````

### Wrapping it up into an alias
Finally, and following Mr. Grasso’s example, let’s get rid of some over-greedy matching and wrap it up into a nice alias:
alias jtags=”ctags -R app config lib && sed -i ‘’ -E ‘/^(if|switch|function|module\.exports|it|describe).+language:js$/d’ tags”

## Ctags with Swift
`ctags --langmap=c:+.swift –R`
````ctags
–langdef=Swift
–langmap=Swift:+.swift
–regex-swift=/(var|let)[ \t]+([^:=<]+).*$/\2/,variable/
–regex-swift=/func[ \t]+([^\(\)<]+)\([^\(\)]*\)/\1/,function/
–regex-swift=/class[ \t]+([^:\{<]+).*$/\1/,class/
–regex-swift=/struct[ \t]+([^:\{<]+).*$/\1/,struct/
–regex-swift=/protocol[ \t]+([^:\{<]+).*$/\1/,protocol/
````

