# Understanding and Using C Pointers
> Richard Reese

## Chapter 1. Introduction
### Pointers and Memory
> When a C program is compiled, it works with three types of memory:
- Static/Global
> Statically declared variables are allocated to this type of memory. Global variables also use this region of memory. They are allocated when the program starts and remain in existence until the program terminates. While all functions have access to global variables, the scope of static variables is restricted to their defining function.
- Automatic
> These variables are declared within a function and are created when a function is called. Their scope is restricted to the function, and their lifetime is limited to the time the function is executing.
- Dynamic
> Memory is allocated from the heap and can be released as necessary. A pointer references the allocated memory. The scope is limited to the pointer or pointers that reference the memory. It exists until it is released.
