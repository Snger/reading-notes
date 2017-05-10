## Bash tips: Colors and formatting (ANSI/VT100 Control sequences)
1. The ANSI/VT100 terminals and terminal emulators are not just able to display black and white text ; they can display colors and formatted texts thanks to escape sequences. Those sequences are composed of the Escape character (often represented by ”^[” or ”<Esc>”) followed by some other characters: ”<Esc>[FormatCodem”.
2. In Bash, the <Esc> character can be obtained with the following syntaxes: `\e` , `\033`, `\x1B`, `\u001b`
3. [Example] `echo -e "\033[31mHello\e[0m World"`: 
> NOTE¹: The -e option of the echo command enable the parsing of the escape sequences.
> NOTE²: The ”\e[0m” sequence removes all attributes (formatting and colors). It can be a good idea to add it at the end of each colored text. ;)
> NOTE³: The examples in this page are in Bash but the ANSI/VT100 escape sequences can be used in every programming languages.
4. [Attributes combination] Terminals allow attribute combinations. The attributes must be separated by a semicolon (”;”).

## What's is the difference between “>” and “>>” in shell command?
1. > is used to write to a file and >> is used to append to a file. Thus, when you use ps aux > file, the output of ps aux will be written to file and if a file named file was already present, its contents will be overwritten. And if you use ps aux >> file, the output of ps aux will be written to file and if the file named file was already present, the file will now contain its previous contents and also the contents of ps aux, written after its older contents of file.

## What are the shell's control and redirection operators?
1. These are called shell operators and yes, there are more of them. I will give a brief overview of the most common among the two major classes, control operators and [redirection operators](https://www.gnu.org/software/bash/manual/bashref.html#Redirections), and how they work with respect to the bash shell. 
2. A. Control operators: These are tokens that perform control functions, one of `||`, `!`, `&&`, `&`, `;`, `;;`, `|`, `|&`, `(`, or `)`. 
> 2.1 List terminators
> `;` : Will run one command after another has finished, irrespective of the outcome of the first.
> `&` : This will run a command in the background, allowing you to continue working in the same shell.
> 2.2 Logical operators
> `&&` : Used to build AND lists, it allows you to run one command only if another exited successfully.
> `||` : Used to build OR lists, it allows you to run one command only if another exited unsuccessfully.
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
