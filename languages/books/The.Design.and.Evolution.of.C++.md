# The Design and Evolution of C++
> Bjarne Stroustrup

## 2.2 Feature overview
> The features provided in the initial 1980 implementation can be summarized:
[1] Classes (§2.3)
[2] Derived classes (but no virtual functions yet, §2.9)
[3] Public/private access control (§2.10)
[4] Constructors and destructors (§2.11.1)
[5] Call and return functions (later removed, §2.11.3)
[6] friend classes (§2.10)
[7] Type checking and conversion of function arguments (§2.6)
During 1981, three more features were added:
[8] Inline functions (§2.4.1)
[9] Default arguments (§2.12.2)
[10] Overloading of the assignment operator (§2.12.1)
> Since a preprocessor was used for the implementation of C with Classes, only new features (that is, features not present in C) had to be described and the full power of C was available to users. Both aspects were appreciated at the time. Having C as a sub-set dramatically reduced the support and documentation work needed. This was most important because for several years I did all of the C with Classes and C++ documentation and support in addition to doing the experimentation, design, and implementation. Having all C features available further ensured that no limitations introduced through prejudice or lack of foresight on my part would deprive a user of features already available in C. Naturally, portability to machines supporting C was ensured. Initially, C with Classes was implemented and used on a DEC PDP/11, but soon it was ported to machines such as the DEC VAX and Motorola 68000 based machines. C with Classes was still seen as a dialect of C rather than as a separate language. Furthermore, classes were referred to as "an abstract data type facility" [Stroustrup,1980]. Support for object-oriented programming was not claimed until the provision of virtual functions in C++ in 1983 [Stroustrup,1984].

## 2.3 Classes
> Clearly, the most important aspect of C with Classes - and later of C++ - was the
class concept. Many aspects of the C with Classes class concept can be observed by
examining a simple example from [Stroustrup,1980]†:
    class stack {
        char s[SIZE]; /* array of characters */
        char* min; /* pointer to bottom of stack */
        char* top; /* pointer to top of stack */
        char* max; /* pointer to top of allocated space */
        void new(); /* initialize function (constructor) */

        public:
            void push(char);
            char pop();
    };
A class is a user-defined data type. A class specifies the type of class members that
define the representation of a variable of the type (an object of the class), the set of
operations (functions) that manipulate such objects, and the access users have to these
members. Member functions are typically defined "elsewhere:"
    char stack.pop ( )
    {
        if (top <= min) error("stack underflow");
        return *(--top);
    }
Objects of class stack can now be defined and used:
