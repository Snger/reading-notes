# Unix

<!-- MarkdownTOC -->

- Unix less commands
- Switch back to the last working directory
- Go back to home directory
- List the contents of a directory
- Running multiple commands in one single command
- Running multiple commands in one single command only if the previous command was successful
- Easily search and use the commands that you had used in the past
- Unfreeze your Linux terminal from accidental Ctrl+S
- Move to beginning or end of line
- Reading a log file in real time
- Reading compressed logs without extracting
- Use less to read files
- Reuse the last item from the previous command with !$
- Reuse the previous command in present command with !!
- Using alias to fix typos
- Copy Paste in Linux terminal
- Kill a running command/process
- Using yes command for commands or scripts that need interactive response
- Empty a file without deleting it
- Find if there are files containing a particular text
- Using help with any command
- How can I decode a base64 string from the command line?
- find

<!-- /MarkdownTOC -->

## Unix less commands
1.  Less  is  a program similar to more (1), but which allows backward movement in the file as well as forward movement.  Also, less does not have to read the entire input  file  before starting,  so  with  large  input files it starts up faster than text editors like vi (1). Less uses termcap (or terminfo on some systems), so it can run on a variety of  terminals. There  is  even  limited  support  for hardcopy terminals.  (On a hardcopy terminal, lines which should be printed at the top of the screen are prefixed with a caret.) Commands are based on both more and vi.  Commands may be preceded  by  a  decimal  number, called N in the descriptions below.  The number is used by some commands, as indicated.
2. That should scroll for a while. To break up the output screen by screen, just pipe it through less: $ ls -l | less

## Switch back to the last working directory
1. cd -

## Go back to home directory
1. cd ~
1. cd

## List the contents of a directory
1. ll

## Running multiple commands in one single command
1. command_1; command_2; command_3

## Running multiple commands in one single command only if the previous command was successful
1. command_1 && command_2

## Easily search and use the commands that you had used in the past
1. ctrl+r search_term

## Unfreeze your Linux terminal from accidental Ctrl+S
1. ctrl+Q

## Move to beginning or end of line
1. you can use Ctrl+A to go to the beginning of the line and Ctrl+E to go to the end.

## Reading a log file in real time
1. tail -f path_to_Log
1. tail -f path_to_log | grep search_term

## Reading compressed logs without extracting
1. These Z commands provide a ‘Z’ equivalent of the regular file manipulation commands.
> zcat for cat to view compressed file
> zgrep for grep to search inside the compressed file
> zless for less, zmore for more, to view the file in pages
> zdiff for diff to see the difference between two compressed files

## Use less to read files
1. less path_to_file

## Reuse the last item from the previous command with !$
1. Using the argument of the previous command comes handy in many situations.
1. Say you have to create a directory and then go into the newly created directory. There you can use the !$ options.
1. A better way to do the same is to use alt+. . You can use . a number times to shuffle between the options of the last commands.

## Reuse the previous command in present command with !!
1. You can call the entire previous command with !!. This comes particularly useful when you have to run a command and realize that it needs root privileges.
1. A quick sudo !! saves plenty of keystrokes here.

## Using alias to fix typos
1. alias gerp=grep

## Copy Paste in Linux terminal
1. This one is slightly ambiguous because it depends on Linux distributions and terminal applications. But in general, you should be able to copy paste commands with these shortcuts:
> Select the text for copying and right click for paste (works in Putty and other Windows SSH clients)
> Select the text for copying and middle click (scroll button on the mouse) for paste
> Ctrl+Shift+C for copy and Ctrl+Shift+V for paste

## Kill a running command/process
1. This one is perhaps way too obvious. If there is a command running in the foreground and you want to exit it, you can press Ctrl+C to stop that running command.

## Using yes command for commands or scripts that need interactive response
1. 	If there are some commands or scripts that need user interaction and you know that you have to enter Y each time it requires an input, you can use Yes command.
1. yes | command_or_script

## Empty a file without deleting it
1. If you just want to empty the contents of a text file without deleting the file itself, you can use a command similar to this:
1. > filename

## Find if there are files containing a particular text
1. There are multiple ways to search and find in Linux command line. But in the case when you just want to see if there are files that contain a particular text, you can use this command:
> grep -Pri Search_Term path_to_directory

## Using help with any command
1. I’ll conclude this article with one more obvious and yet very important ‘trick’, using help with a command or a command line tool.
1. Almost all command and command line tool come with a help page that shows how to use the command. Often using help will tell you the basic usage of the tool/command.
1. command_tool --help

## How can I decode a base64 string from the command line?
> Just use the base64 program from the coreutils package:
	echo QWxhZGRpbjpvcGVuIHNlc2FtZQ== | base64 --decode
> Or, to include the newline character
	echo `echo QWxhZGRpbjpvcGVuIHNlc2FtZQ== | base64 --decode`
> output (includes newline):
	Aladdin:open sesame
> Add the following to the bottom of your ~/.bashrc file:
````bash
decode () {
  echo "$1" | base64 -d ; echo
}
````
> Now, open a new Terminal and run the command.
````bash
	decode QWxhZGRpbjpvcGVuIHNlc2FtZQ==
````
> This will do exactly what you asked for in your question.

## find
> find - search for files in a directory hierarchy
	find /tmp -name core -type f -print | xargs /bin/rm -f
> Find  files  named  core  in or below the directory /tmp and delete them. Note that this will work incorrectly if  there are  any  filenames  containing  newlines,  single or double quotes, or spaces.
	-type c
        File is of type c:
        b      block (buffered) special
        c      character (unbuffered) special
        d      directory
        p      named pipe (FIFO)
        f      regular file
        l      symbolic  link;  this  is never true if the -L
               option or the -follow  option  is  in  effect,
               unless  the  symbolic  link is broken.  If you
               want to search for symbolic links when  -L  is
               in effect, use -xtype.
        s      socket
        D      door (Solaris)
