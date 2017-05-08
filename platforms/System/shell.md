## Bash tips: Colors and formatting (ANSI/VT100 Control sequences)
1. The ANSI/VT100 terminals and terminal emulators are not just able to display black and white text ; they can display colors and formatted texts thanks to escape sequences. Those sequences are composed of the Escape character (often represented by ”^[” or ”<Esc>”) followed by some other characters: ”<Esc>[FormatCodem”.
2. In Bash, the <Esc> character can be obtained with the following syntaxes: `\e` , `\033`, `\x1B`, `\u001b`
3. [Example] `echo -e "\033[31mHello\e[0m World"`: 
> NOTE¹: The -e option of the echo command enable the parsing of the escape sequences.
> NOTE²: The ”\e[0m” sequence removes all attributes (formatting and colors). It can be a good idea to add it at the end of each colored text. ;)
> NOTE³: The examples in this page are in Bash but the ANSI/VT100 escape sequences can be used in every programming languages.
4. [Attributes combination] Terminals allow attribute combinations. The attributes must be separated by a semicolon (”;”).

