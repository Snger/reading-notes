# shell
<!-- MarkdownTOC -->

- Bash tips: Colors and formatting \(ANSI/VT100 Control sequences\)
- What's is the difference between “>” and “>>” in shell command?
- What are the shell's control and redirection operators?
- How do I remove a directory and all its contents?
- How to get the MD5 hash of a string directly in the terminal?
- tar
- tree

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
> `tree -I node_modules --dirsfirst -L 2 -a`
> `-I` ignore
> `--dirsfirst`
> `-L` level
> `-a` show all
