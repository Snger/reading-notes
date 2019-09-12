# shell
<!-- MarkdownTOC -->

- Bash tips: Colors and formatting \(ANSI/VT100 Control sequences\)
- What's is the difference between “>” and “>>” in shell command?
- What are the shell's control and redirection operators?
- How do I remove a directory and all its contents?
- How to get the MD5 hash of a string directly in the terminal?
- tar
- tree
- Replace one substring for another string in shell script
- Linux ls 命令只显示目录和只显示文件
- How can I have a newline in a string in sh?
- How to read and write from a file in a Linux bash shell script
- How do I pause my shell script for a second before continuing?
- Replacing some characters in a string with another character
- How to tell bash that the line continues on the next line
- How to pipe command output to other commands?
- How to Get Current Date and Time in Bash Script
- How to iterate through json in bash script
- Recursively change file extensions in Bash
- Add Filename as first line of file in shell script
- List file using ls command in Linux with full path

<!-- /MarkdownTOC -->

## Bash tips: Colors and formatting (ANSI/VT100 Control sequences)
> 1. The ANSI/VT100 terminals and terminal emulators are not just able to display black and white text ; they can display colors and formatted texts thanks to escape sequences. Those sequences are composed of the Escape character (often represented by ”^[” or ”<Esc>”) followed by some other characters: ”<Esc>[FormatCodem”.
2. In Bash, the <Esc> character can be obtained with the following syntaxes: `\e` , `\033`, `\x1B`, `\u001b`
3. [Example] `echo -e "\033[31mHello\e[0m World"`:
> NOTE¹: The -e option of the echo command enable the parsing of the escape sequences.
> NOTE²: The ”\e[0m” sequence removes all attributes (formatting and colors). It can be a good idea to add it at the end of each colored text. ;)
> NOTE³: The examples in this page are in Bash but the ANSI/VT100 escape sequences can be used in every programming languages. 4. [Attributes combination] Terminals allow attribute combinations. The attributes must be separated by a semicolon (”;”).
4. [Attributes combination] Terminals allow attribute combinations. The attributes must be separated by a semicolon (”;”).

## What's is the difference between “>” and “>>” in shell command?
> `>` is used to write to a file and `>>` is used to append to a file. Thus, when you use ps aux > file, the output of ps aux will be written to file and if a file named file was already present, its contents will be overwritten. And if you use ps aux `>>` file, the output of ps aux will be written to file and if the file named file was already present, the file will now contain its previous contents and also the contents of ps aux, written after its older contents of file.

## What are the shell's control and redirection operators?
> 1. These are called shell operators and yes, there are more of them. I will give a brief overview of the most common among the two major classes, control operators and [redirection operators](https://www.gnu.org/software/bash/manual/bashref.html#Redirections), and how they work with respect to the bash shell.
2. A. Control operators: These are tokens that perform control functions, one of `||`, `!`, `&&`, `&`, `;`, `;;`, `|`, `|&`, `(`, or `)`.
> 2.1 List terminators
> `;` : Will run one command after another has finished, irrespective of the outcome of the first.
> `&` : This will run a command in the background, allowing you to continue working in the same shell.
> 2.2 Logical operators
> `&&` : Used to build AND lists, it allows you to run one command only if another exited successfully.
> `||` : Used to build OR lists, it allows you to run one command only if another exited unsuccessfully.
> `!`: This is the “not” operator, used to negate the return status of a command — return 0 if the command returns a nonzero status, return 1 if it returns the status 0. 3. Pipe operator
> `|` : The pipe operator, it passes the output of one command as input to another. A command built from the pipe operator is called a pipeline.
> `|&` : This is a shorthand for `2>&1 |` in bash and zsh. It passes both standard output and standard error of one command as input to another. 4. Other list punctuation
> `;;` is used solely to mark the end of a case statement. Ksh, bash and zsh also support ;& to fall through to the next case and ;;& (not in ATT ksh) to go on and test subsequent cases.
> `(` and `)` are used to group commands and launch them in a subshell. `{` and `}` also group commands, but do not launch them in a subshell. See this answer for a discussion of the various types of parentheses, brackets and braces in shell syntax. 5. B. Redirection Operators: These allow you to control the input and output of your commands. They can appear anywhere within a simple command or may follow a command. Redirections are processed in the order they appear, from left to right.
> `!`: This is the “not” operator, used to negate the return status of a command — return 0 if the command returns a nonzero status, return 1 if it returns the status 0.
3. Pipe operator
> `|` : The pipe operator, it passes the output of one command as input to another. A command built from the pipe operator is called a pipeline.
> `|&` : This is a shorthand for `2>&1 |` in bash and zsh. It passes both standard output and standard error of one command as input to another.
4. Other list punctuation
> `;;` is used solely to mark the end of a case statement. Ksh, bash and zsh also support ;& to fall through to the next case and ;;& (not in ATT ksh) to go on and test subsequent cases.
> `(` and `)` are used to group commands and launch them in a subshell. `{` and `}` also group commands, but do not launch them in a subshell. See this answer for a discussion of the various types of parentheses, brackets and braces in shell syntax.
5. B. Redirection Operators: These allow you to control the input and output of your commands. They can appear anywhere within a simple command or may follow a command. Redirections are processed in the order they appear, from left to right.
> `<` : Gives input to a command.
> `<>` : same as above, but the file is open in read+write mode instead of read-only:
> `>` : Directs the output of a command into a file.
> `>|` : Does the same as `>`, but will overwrite the target, even if the shell has been configured to refuse overwriting (with set -C or set -o noclobber).
> `>>` : Does the same as `>`, except that if the target file exists, the new data are appended.
> `&>`, `>&`, `>>&` and `&>>` : (non-standard). Redirect both standard error and standard output, replacing or appending, respectively.
> `<<` : A here document. It is often used to print multi-line strings. If you want to pipe the output of command `<< WORD ... WORD` directly into another command or commands, you have to put the pipe on the same line as `<< WORD`, you can't put it after the terminating `WORD` or on the line following.
> `<<<` : Here strings, similar to here documents, but intended for a single line. These exist only in the Unix port or rc (where it originated), zsh, some implementations of ksh, yash and bash.

## How do I remove a directory and all its contents?
> `rm -rf directoryname`
> `rmdir directoryname`

## How to get the MD5 hash of a string directly in the terminal?
> 1. echo -n Welcome | md5sum
> Notice that the -n is mandatory. Without it, your hash will be totally wrong since it includes the newline character.
> -n     do not output the trailing newline
1. md5sum <<<"my string"
> Very simple, it accepts stdin, and using the <<< operator sends a newline to the md5sum.
1. printf '%s' "my string" | md5sum
> To avoid the trailing newline added by the shell
1. echo -n 123456 | md5sum | awk '{print $1}'
1. echo -n 123456 | openssl md5
> Notice that the -n is mandatory. Without it, your hash will be totally wrong since it includes the newline character.
> -n     do not output the trailing newline 1. md5sum <<<"my string"
> Very simple, it accepts stdin, and using the <<< operator sends a newline to the md5sum. 1. printf '%s' "my string" | md5sum
> To avoid the trailing newline added by the shell 1. echo -n 123456 | md5sum | awk '{print $1}' 1. echo -n 123456 | openssl md5

## tar
> tar - an archiving utility
> Options  to  GNU  tar  can  be given in three different styles.  **In traditional style**, the first argument is a cluster of option letters and all subsequent  arguments  supply  argu‐ ments to those options that require them.  The arguments are read in the same order as the option letters.  Any command line words that remain after all options has  been  processed are treated as non-optional arguments: file or archive member names.
> For example, the c option requires creating the archive, the v option requests the verbose operation, and the f option takes an argument that sets the name of the archive to operate upon.  The following command, written in the traditional style, instructs tar to store all files from the directory /etc into the archive file etc.tar verbosely  listing  the  files being archived:
	tar cfv a.tar /etc
> In  UNIX  or  **short-option style**, each option letter is prefixed with a single dash, as in other command line utilities.  If an option  takes  argument,  the  argument  follows  it, either  as a separate command line word, or immediately following the option.  However, if the option takes an optional argument, the argument must follow the option letter  without any intervening whitespace, as in -g/tmp/snar.db.
> Any  number of options not taking arguments can be clustered together after a single dash, e.g. -vkp.  Options that take arguments (whether mandatory or optional), can appear at the end of such a cluster, e.g. -vkpf a.tar.
> The example command above written in the **short-option** style could look like:
	tar -cvf a.tar /etc or tar -c -v -f a.tar /etc
> In GNU or **long-option style**, each option begins with two dashes and has a meaningful name, consisting of lower-case letters and dashes.  When used, the long option can  be  abbrevi‐ ated  to  its initial letters, provided that this does not create ambiguity.  Arguments to long options are supplied either as a separate command line  word,  immediately  following the option, or separated from the option by an equals sign with no intervening whitespace. Optional arguments must always use the latter method.
> Here are several ways of writing the example command in this style:
	tar --create --file a.tar --verbose /etc
	// or (abbreviating some options):
	tar --cre --file=a.tar --verb /etc
The options in all three styles can be intermixed, although doing so with old  options  is
not encouraged.
> - using with ssh
> `$ cd && tar czv src | ssh user@host 'tar xz'`
> 将$HOME/src/目录下面的所有文件，复制到远程主机的$HOME/src/目录。
> -c, --create
>> Create a new archive.  Arguments supply the names of  the  files  to  be  archived. Directories are archived recursively, unless the --no-recursion option is given.
> -z, --gzip, --gunzip, --ungzip
>> Filter the archive through gzip(1).
> -v, --verbose
>> Verbosely list files processed.
> -x, --extract, --get
>> Extract files from an archive.  Arguments are optional.  When given,  they  specify names of the archive members to be extracted.

## tree
> `tree -I 'node_modules|.git' --dirsfirst -L 2 -a`
> `-I` ignore
> `--dirsfirst`
> `-L` level
> `-a` show all

## Replace one substring for another string in shell script
> To replace the *first* occurrence of a pattern with a given string, use <code>${*parameter*/*pattern*/*string*}</code>:

    #!/bin/bash
    firstString="I love Suzi and Marry"
    secondString="Sara"
    echo "${firstString/Suzi/$secondString}"    
    # prints 'I love Sara and Marry'

> To replace *all* occurrences, use <code>${*parameter*//*pattern*/*string*}</code>:

    message='The secret code is 12345'
    echo "${message//[0-9]/X}"           
    # prints 'The secret code is XXXXX'

> (This is documented in [the *Bash Reference Manual*, &sect;3.5.3 "Shell Parameter Expansion"](https://www.gnu.org/software/bash/manual/bash.html#Shell-Parameter-Expansion).)
> Note that this feature is not specified by POSIX &mdash; it's a Bash extension &mdash; so not all Unix shells implement it. For the relevant POSIX documentation, see [*The Open Group Technical Standard Base Specifications, Issue 7*, the *Shell & Utilities* volume, &sect;2.6.2 "Parameter Expansion"](http://pubs.opengroup.org/onlinepubs/9699919799/utilities/V3_chap02.html#tag_18_06_02).

## Linux ls 命令只显示目录和只显示文件
> 1. 只显示目录
` ls -F | grep "/$" `
> -F 文件类型（File type）。在每一个列举项目之后添加一个符号。这些符号包括： / 表明是一个目录； @ 表明是到其它文件的符号链接； * 表明是一个可执行文件
> 只显示文件
` ls -al | grep "^-" `

## How can I have a newline in a string in sh?
> [link](https://stackoverflow.com/questions/3005963/how-can-i-have-a-newline-in-a-string-in-sh#3182519)
> The solution is to use $'string', for example:
````bash
$ STR=$'Hello\nWorld'
$ echo "$STR"
#Hello
#World
NL=$'\n'
SUB_GROUPS=$SUB_GROUPS$NL'web'$NL'web/resource'
````

## How to read and write from a file in a Linux bash shell script
> this is how I write my counter to that file:
````bash
# create a variable to represent the filename
COUNTER_FILE="counter.tmp"
# write to the file
echo "0" > $COUNTER_FILE
````
> Later in the code I increment the counter and write it to the file like this:
````bash
((count++))
echo $count > $COUNTER_FILE
````
>Finally, this is how I read the counter from the file:
````bash
count=`cat $COUNTER_FILE`
````

## How do I pause my shell script for a second before continuing?
> Use the sleep command.
Example:
````bash
sleep .5 # Waits 0.5 second.
sleep 5  # Waits 5 seconds.
sleep 5s # Waits 5 seconds.
sleep 5m # Waits 5 minutes.
sleep 5h # Waits 5 hours.
sleep 5d # Waits 5 days.
````
> One can also employ decimals when specifying a time unit; e.g. sleep 1.5s

## Replacing some characters in a string with another character
> `echo "$string" | tr xyz _`
> would replace each occurrence of x, y, or z with `_`, giving `A__BC___DEF__LMN` in your example.
````bash
echo "$string" | sed -r 's/[xyz]+/_/g'
````
> would replace repeating occurrences of x, y, or z with a single `_`, giving `A_BC_DEF_LMN` in your example.

## How to tell bash that the line continues on the next line
> The character is a backslash \
From the bash manual:
The backslash character ‘\’ may be used to remove any special meaning for the next character read and for line continuation.

## How to pipe command output to other commands?
> There is a distinction between command line arguments and standard input. A pipe will connect standard output of one process to standard input of another. So
````bash
ls | echo
````
> Connects standard output of ls to standard input of echo. Fine right? Well, echo ignores standard input and will dump its command line arguments - which are none in this case to - its own stdout. The output: nothing at all.
> There are a few solutions in this case. One is to use a command that reads stdin and dumps to stdout, such as cat.
````bash
ls | cat
````
> Will 'work', depending on what your definition of work is.
> But what about the general case. What you really want is to convert stdout of one command to command line args of another. As others have said, xargs is the canonical helper tool in this case, reading its command line args for a command from its stdin, and constructing commands to run.
````bash
ls | xargs echo
````
> You could also convert this some, using the substitution command $()
````bash
echo $(ls)
````
> Would also do what you want.
> Both of these tools are pretty core to shell scripting, you should learn both.
For completeness, as you indicate in the question, the other base way to convert stdin to command line args is the shell's builtin read command. It converts "words" (words as defined by the IFS variable) to a temp variable, which you can use in any command runs.

## How to Get Current Date and Time in Bash Script
> 1. Uses of date Command:
Simple date command returns the current date and time with the current timezone set in your system.
````bash
date
Mon Mar  6 14:40:32 IST 2019
````
> You can also store the output of command in a variable for further use.
````bash
currentDate=`date`
echo $currentDate
Mon Mar 25 14:40:32 IST 2019
````
> 2. Formated Output of date Command:
There are several switches, you can use to format the output of date command.
Get date time in MM/DD/YY HH:MM:SS format:
````bash
date +"%D %T"
03/25/17 14:40:32
````
Get current Unix epoch time:
````bash
date +%s
1554542637
````
Get date time in YYYY-MM-DD HH:MM:SS format:
````bash
date +"%Y-%m-%d %T"
2019-03-25 14:40:32
````

## How to iterate through json in bash script
> If this is valid json and the email field is the only one containing a @ character, you can do something like this:
````bash
echo $value | tr '"' '\n' | grep @
````
> It replaces double-quotes by new line character and only keeps lines containing @. It is really not json parsing, but it works.
> You can store the result in a bash array
````bash
emails=($(echo $value | tr '"' '\n' | grep @))
````
> and iterate on them
````bash
for email in ${emails[@]}
do
    echo $email
done
````

## Recursively change file extensions in Bash
> If you have rename available then use:
````bash
find . -name '*.t1' -exec rename .t1 .t2 {} + 
find . -name "*.t1" -exec rename 's/\.t1$/.t2/' '{}' \;
````
> If rename isn't available then use:
````bash
find . -name "*.t1" -exec bash -c 'mv "$1" "${1%.t1}".t2' - '{}' \;
````

## Add Filename as first line of file in shell script
````bash
# only first one
f=$(ls -1tr *.txt | head -1); sed -e 1i$f $f > $f-tmp && mv $f-tmp $f
# echo
files=$(ls -R | grep '\.txt$');for f in $files; do echo $f; done;
files=$(ls | grep '\.md$');for f in $files; do echo $f; done;
files=$(ls | grep '\.md$');for f in $files; do echo $f-tmp; done;
# without recursite
files=$(ls | grep '\.txt$');for f in $files; do sed -e 1i$f $f > $f-tmp && mv $f-tmp $f; done;
files=$(ls | grep '\.md$');for f in $files; do sed -e 1i$f $f > $f-tmp && mv $f-tmp $f; done;
# sth wrong
files=$(ls -R | grep '\.txt$');for f in $files; do sed -e 1i$f $f > $f-tmp && mv $f-tmp $f; done;
# sed: can't find label for jump to `est11.txt'
# add filename is  'hello.txt'$'\n''test11.txt-tmp'
````

## List file using ls command in Linux with full path
> 1. It will also catch hidden files.
````bash
ls -lrt -d -1 $PWD/{*,.*}   
find $PWD -maxdepth 1
````
> 2.
````bash
ls -d $PWD/*
````
