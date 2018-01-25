# GNU
<!-- MarkdownTOC -->

- What's GNU Project?
- CLI pdf viewer - xpdf
	- How do I open a .pdf in cygwin? - xpdf
- What's Bash
- Why most programs should be using '/bin/sh' and not bash?
- How to navigate long commands faster?
	- Bash Shortcuts For Maximum Productivity
- Bash Command Editing Shortcuts
- Bash Command Recall Shortcuts
- Bash Command Control Shortcuts
- Bash Bang \(!\) Commands
- md5sum - compute and check MD5 message digest

<!-- /MarkdownTOC -->

## What's GNU Project?
1. The GNU Project Listeni/ɡnuː/[3] is a free-software, mass-collaboration project, first announced on September 27, 1983 by Richard Stallman at MIT. Its aim is to give computer users freedom and control in their use of their computers and computing devices, by collaboratively developing and providing software that is based on the following freedom rights: users are free to run the software, share it (copy, distribute), study it and modify it. GNU software guarantees these freedom-rights legally (via its license), and is therefore free software; the use of the word "free" always being taken to refer to freedom.
2. In order to ensure that the entire software of a computer grants its users all freedom rights (use, share, study, modify), even the most fundamental and important part, the operating system (including all its numerous utility programs), needed to be free software. According to its manifesto, the founding goal of the project was to build a free operating system and, if possible, "everything useful that normally comes with a Unix system so that one could get along without any software that is not free." Stallman decided to call this operating system GNU (a recursive acronym meaning "GNU's not Unix"), basing its design on that of Unix, a proprietary operating system.[4] Development was initiated in January 1984. In 1991, the kernel Linux appeared, developed outside of the GNU project by Linus Torvalds,[5] and in December 1992 it was made available under version 2 of the GNU General Public License.[6] Combined with the operating system utilities already developed by the GNU project, it allowed for the first operating system that was free software, known as Linux or GNU/Linux.
3. The project's current work includes software development, awareness building, political campaigning and sharing of the new material.
4. Once the kernel and the compiler were finished, GNU was able to be used for program development. The main goal was to create many other applications to be like the Unix system. GNU was able to run Unix programs but was not identical to it.

## CLI pdf viewer - xpdf
1. XPDF's pdftotext CLI utility: pdftotext /path/to/your/pdf | less
2. pact install poppler (xpdf)
3. PDFToText – Extract all the text from PDF document. I suggest you use the -Layout option for getting the content in the right order.
4. The Xpdf tools look for a config file in two places:
>> 1. ~/.xpdfrc
>> 2. in a system-wide directory, typically /etc/xpdfrc
5. cp /etc/xpdfrc ~/.xpdfrc
6. restart computer, which can be invoked from the command line utility pdftotext.

### How do I open a .pdf in cygwin? - xpdf
> Do you have an X server installed? You'll need one to run graphical programs.
> [Xming X Server](http://www.straightrunning.com/XmingNotes/)
> The "website releases" require a donation; the "public domain" ones do not.

## What's Bash
1. Bash is an sh-compatible command language interpreter that executes commands read from the standard input or from a file.  Bash also incorporates useful features from the Korn and C shells (ksh and csh).
2. Bash  is  intended to be a conformant implementation of the Shell and Utilities portion of the IEEE POSIX specification (IEEE Standard 1003.1).  Bash can be configured to be  POSIX- conformant by default.

## Why most programs should be using '/bin/sh' and not bash?
1. These two shells are different and the reason that FreeBSD keeps '/bin/sh' is because it was designed to be secure and reliable instead of full-featured. Makes sense as a choice, it is aligned with the general UNIX philosophy: do one thing, do it good, keep it as simple as possible.
2. Given the fact that the bug was found in bash, I guess it's just (another) win for this harsh philosophy that so many geeks seem to strongly embrace.

## How to navigate long commands faster?
### Bash Shortcuts For Maximum Productivity
+ Ctrl-A: go to the beginning of line
+ Ctrl-E: go to the end of line
+ Alt-B: skip one word backward
+ Alt-F: skip one word forward
+ Ctrl-U: delete to the beginning of line
+ Ctrl-K: delete to the end of line
+ Alt-D: delete to the end of word

## Bash Command Editing Shortcuts
+ Ctrl + a – go to the start of the command line
+ Ctrl + e – go to the end of the command line
+ Ctrl + k – delete from cursor to the end of the command line
+ Ctrl + u – delete from cursor to the start of the command line
+ Ctrl + w – delete from cursor to start of word (i.e. delete backwards one word)
+ Ctrl + y – paste word or text that was cut using one of the deletion shortcuts (such as the one above) after the cursor
+ Ctrl + xx – move between start of command line and current cursor position (and back again)
+ Alt + b – move backward one word (or go to start of word the cursor is currently on)
+ Alt + f – move forward one word (or go to end of word the cursor is currently on)
+ Alt + d – delete to end of word starting at cursor (whole word if cursor is at + the beginning of word)
+ Alt + c – capitalize to end of word starting at cursor (whole word if cursor is at the beginning of word)
+ Alt + u – make uppercase from cursor to end of word
+ Alt + l – make lowercase from cursor to end of word
+ Alt + t – swap current word with previous
+ Ctrl + f – move forward one character
+ Ctrl + b – move backward one character
+ Ctrl + d – delete character under the cursor
+ Ctrl + h – delete character before the cursor
+ Ctrl + t – swap character under cursor with the previous one

## Bash Command Recall Shortcuts
Ctrl + r – search the history backwards
Ctrl + g – escape from history searching mode
Ctrl + p – previous command in history (i.e. walk back through the command history)
Ctrl + n – next command in history (i.e. walk forward through the command history)
Alt + . – use the last word of the previous command

## Bash Command Control Shortcuts
Ctrl + l – clear the screen
Ctrl + s – stops the output to the screen (for long running verbose command)
Ctrl + q – allow output to the screen (if previously stopped using command above)
Ctrl + c – terminate the command
Ctrl + z – suspend/stop the command

## Bash Bang (!) Commands
Bash also has some handy features that use the ! (bang) to allow you to do some funky stuff with bash commands.
!! – run last command
!blah – run the most recent command that starts with ‘blah’ (e.g. !ls)
!blah:p – print out the command that !blah would run (also adds it as the latest command in the command history)
!$ – the last word of the previous command (same as Alt + .)
!$:p – print out the word that !$ would substitute
!* – the previous command except for the last word (e.g. if you type ‘find some_file.txt /‘, then !* would give you ‘find some_file.txt‘)
!*:p – print out what !* would substitute

## md5sum - compute and check MD5 message digest
> Print or check MD5 (128-bit) checksums.
> With no FILE, or when FILE is -, read standard input.
	-b, --binary
read in binary mode (default unless reading tty stdin)
	-c, --check
read MD5 sums from the FILEs and check them
	--tag
create a BSD-style checksum
	-t, --text
read in text mode (default if reading tty stdin)
> For checking, go to the directory that contains filename and run this command:
	md5sum filename | grep hash
