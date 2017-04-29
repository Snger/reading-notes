## Unix less commands
1.  Less  is  a program similar to more (1), but which allows backward movement in the file as well as forward movement.  Also, less does not have to read the entire input  file  before starting,  so  with  large  input files it starts up faster than text editors like vi (1). Less uses termcap (or terminfo on some systems), so it can run on a variety of  terminals. There  is  even  limited  support  for hardcopy terminals.  (On a hardcopy terminal, lines which should be printed at the top of the screen are prefixed with a caret.) Commands are based on both more and vi.  Commands may be preceded  by  a  decimal  number, called N in the descriptions below.  The number is used by some commands, as indicated.
2. That should scroll for a while. To break up the output screen by screen, just pipe it through less: $ ls -l | less
