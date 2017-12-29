# C lang

## C - Structures
> Arrays allow to define type of variables that can hold several data items of the same kind. Similarly structure is another user defined data type available in C that allows to combine data items of different kinds. [link](http://www.tutorialspoint.com/cprogramming/c_structures.htm)
> To define a structure, you must use the struct statement. The struct statement defines a new data type, with more than one member. The format of the struct statement is as follows −
    struct [structure tag] {
       member definition;
       member definition;
       ...
       member definition;
    } [one or more structure variables];
> The structure tag is optional and each member definition is a normal variable definition, such as int i; or float f; or any other valid variable definition. At the end of the structure's definition, before the final semicolon, you can specify one or more structure variables but it is optional. Here is the way you would declare the Book structure −
    struct Books {
       char  title[50];
       char  author[50];
       char  subject[100];
       int   book_id;
    } book;
