# Eclipse

<!-- MarkdownTOC -->

- 导入项目
- search
- single click to open file
- How to change default text file encoding in Eclipse?
- How do I get to the command line in Eclipse

<!-- /MarkdownTOC -->

## 导入项目
> File -> import -> exit maven -> path(have pom.xml)

## search
> ctrl+h (Search-search) -> file search -> containing text -> schoolList" -> File name patterns -> \*controller.java -> search 
> on search pannel -> Expand All -> double click match file
> select last string of file name -> ctrl+shift+r(Navigate-Open Resource) -> check which one is you want

## single click to open file
> preferences -> general -> open model -> single click

## How to change default text file encoding in Eclipse?
> Window -> Preferences -> General -> Workspace : Text file encoding
> Window > Preferences > General > Content Types
- Select Text > HTML in the tree
- Select all file associations, particularly .html
- Input "UTF-8" in the text-field "default encoding"

## How do I get to the command line in Eclipse
> In the Eclipse Menubar select Window->Show View-> Other
> Find or type "Terminal" in the filter box
> You should now see a Terminal view in the bottom pane. In the icon section for that bottom pane you'll see an icon that looks like a very stylized terminal window with a plus-sign on it.
> Click it and select "New Terminal Connection in current view", and then use the resulting dialog to create either a telnet or ssh connection to "localhost" depending on what you have available on your local system.
> This works on Eclipse Indigo Java EE edition, with no additional plugins installed. I don't know if it was available in previous releases.
