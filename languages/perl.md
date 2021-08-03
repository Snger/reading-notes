# perl

## env: perl\r: No such file or directory
> `#!/usr/bin/env perl`
get error `env: perl\r: No such file or directory`
Remove \r control chars with
`perl -i -pe 'y|\r||d' script.pl`
it does in-place edit of file, where it removes every occurrence of \r control char (or ^M as shell refers to it).
> Possibly you would need to inspect the file with a binary editor if you do not see the character.
You could do like this to convert the file to Mac line-ending format:
$ vi your_script.sh
`:set ff=unix`
Save and exit:
`:wq`
Done!
### Explanation
ff stands for file format, and can accept the values of unix (\n), dos (\r\n) and mac (\r) (only meant to be used on pre-intel macs, on modern macs use unix)..
To read more about the ff command:
`:help ff`
`:wq` stands for Write and Quit, a faster equivalent is `Shift`+`zz` (i.e. hold down Shift then press z twice).
Both commands must be used in command mode.
### Usage on multiple files
It is not necessary to actually open the file in vim. The modification can be made directly from the command line:
 `vi +':wq ++ff=unix' file_with_dos_linebreaks.py`
To process multiple `*.py` files:
````perl
for file in *.py ; do
    vi +':w ++ff=unix' +':q' ${file}
done
````
