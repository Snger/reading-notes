## Insert Mode - Inserting/Appending text
> i - start insert mode at cursor
> I - insert at the beginning of the line
> a - append after the cursor
> A - append at the end of the line
> o - open (append) blank line below current line (no need to press return)
> O - open blank line above current line
> ea - append at end of word
> Esc - exit insert mode

## Cut and Paste
> yy - yank (copy) a line
> 2yy - yank 2 lines
> yw - yank word
> y$ - yank to end of line
> p - put (paste) the clipboard after cursor
> P - put (paste) before cursor
> dd - delete (cut) a line
> dw - delete (cut) the current word
> x - delete (cut) current character

## How to unfreeze after accidentally pressing Ctrl-S in a terminal?
1. Ctrl-Q
2. To disable this altogether, stick stty -ixon in a startup script. To allow any key to get things flowing again, use stty ixany.
3. ps: It's neither the terminal nor the shell that does this, but the OS's terminal driver.