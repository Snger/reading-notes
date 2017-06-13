## Insert Mode - Inserting/Appending text
- i - start insert mode at cursor
- I - insert at the beginning of the line
- a - append after the cursor
- A - append at the end of the line
- o - open (append) blank line below current line (no need to press return)
- O - open blank line above current line
- ea - append at end of word
- Esc - exit insert mode

## Cut and Paste
- yy - yank (copy) a line
- 2yy - yank 2 lines
- yw - yank word
- y$ - yank to end of line
- p - put (paste) the clipboard after cursor
- P - put (paste) before cursor
- dd - delete (cut) a line
- dw - delete (cut) the current word
- x - delete (cut) current character

## How to unfreeze after accidentally pressing Ctrl-S in a terminal?
1. Ctrl-Q
2. To disable this altogether, stick stty -ixon in a startup script. To allow any key to get things flowing again, use stty ixany.
3. ps: It's neither the terminal nor the shell that does this, but the OS's terminal driver.

## Switching case of characters
1. Toggle case "HellO" to "hELLo" with g~ then a movement.
2. Uppercase "HellO" to "HELLO" with gU then a movement.
3. Lowercase "HellO" to "hello" with gu then a movement.
4. Alternatively, you can visually select text then press ~ to toggle case, or U to convert to uppercase, or u to convert to lowercase.

## Repeat last change
1. The "." command repeats the last change made in normal mode. For example, if you press dw to delete a word, you can then press . to delete another word (. is dot, aka period or full stop).
2. The "@:" command repeats the last command-line change (a command invoked with ":", for example :s/old/new/).

## Indent multiple lines quickly in vi
1. Use the > command. To indent 5 lines, 5>>. To mark a block of lines and indent it, Vjj> to indent 3 lines (vim only). To indent a curly-braces block, put your cursor on one of the curly braces and use >%.
2. If you’re copying blocks of text around and need to align the indent of a block in its new location, use ]p instead of just p. This aligns the pasted block with the surrounding text.
3. Also, the shiftwidth setting allows you to control how many spaces to indent.
4. General Commands
- >>   Indent line by shiftwidth spaces
- <<   De-indent line by shiftwidth spaces
- 5>>  Indent 5 lines
- 5==  Re-indent 5 lines
- >%   Increase indent of a braced or bracketed block (place cursor on brace first)
- =%   Reindent a braced or bracketed block (cursor on brace)
- <%   Decrease indent of a braced or bracketed block (cursor on brace)
- ]p   Paste text, aligning indentation with surroundings
- =i{  Re-indent the 'inner block', i.e. the contents of the block
- =a{  Re-indent 'a block', i.e. block and containing braces
- =2a{ Re-indent '2 blocks', i.e. this block and containing block
- >i{  Increase inner block indent
- <i{  Decrease inner block indent

## Searching and Replacing
1. vi also has powerful search and replace capabilities. To search the text of an open file for a specific string (combination of characters or words), in the command mode type a colon (:), "s," forward slash (/) and the search string itself. What you type will appear on the bottom line of the display screen. Finally, press ENTER, and the matching area of the text will be highlighted, if it exists. If the matching string is on an area of text that is not currently displayed on the screen, the text will scroll to show that area.
2. The formal syntax for searching is: `:s/string`
3. The syntax for replacing one string with another string in the current line is `:s/pattern/replace/`
4. Here "pattern" represents the old string and "replace" represents the new string. 
5. To perform a global search and replace in vi, use the search and replace command in command mode: `:%s/search_string/replacement_string/g`
6. The % is a shortcut that tells vi to search all lines of the file for search_string and change it to replacement_string. The global (g) flag at the end of the command tells vi to continue searching for other occurrences of search_string. To confirm each replacement, add the confirm (c) flag after the global flag.
7. You can supply the additional range(s) to it (and concatenate as many as you like): `:6,10s/<search_string>/<replace_string>/g`

## Indent or comment several text lines with vi
1. visual block mode
- block lines with  ctrl+v
- Insert comment sign (//) with I
- escape with ESC
- the key typing is
- ctrl+v → jjjj → I → // → ESC
2. command line
- type :set number. take note of the start and end line number of the block you want to comment. then do an address range substitution, eg
- :12,17s/^/#

