# TypeScript
> TypeScript is a language for application-scale JavaScript. TypeScript adds optional types, classes, and modules to JavaScript. TypeScript supports tools for large-scale JavaScript applications for any browser, for any host, on any OS. TypeScript compiles to readable, standards-based JavaScript. 

<!-- MarkdownTOC -->

- About `*.d.ts` in TypeScript
- What does 'declare' do in 'export declare class Actions'?

<!-- /MarkdownTOC -->

## About `*.d.ts` in TypeScript
> The "d.ts" file is used to provide typescript type information about an API that's written in JavaScript. The idea is that you're using something like jQuery or underscore, an existing javascript library. You want to consume those from your typescript code.
> Rather than rewriting jquery or underscore or whatever in typescript, you can instead write the d.ts file, which contains only the type annotations. Then from your typescript code you get the typescript benefits of static type checking while still using a pure JS library.
> - `d` stands for [declaration files](https://en.wikipedia.org/wiki/TypeScript#Declaration_files):
> When a TypeScript script gets compiled there is an option to generate a declaration file (with the extension .d.ts) that functions as an interface to the components in the compiled JavaScript. In the process the compiler strips away all function and method bodies and preserves only the signatures of the types that are exported. The resulting declaration file can then be used to describe the exported virtual TypeScript types of a JavaScript library or module when a third-party developer consumes it from TypeScript.
> The concept of declaration files is analogous to the concept of header file found in C/C++.
	declare module arithmetics {
	    add(left: number, right: number): number;
	    subtract(left: number, right: number): number;
	    multiply(left: number, right: number): number;
	    divide(left: number, right: number): number;
	}
> Type declaration files can be written by hand for existing JavaScript libraries, as has been done for jQuery and Node.js.
> Large collections of declaration files for popular JavaScript libraries are hosted on GitHub in [DefinitelyTyped](https://github.com/DefinitelyTyped) and the [Typings Registry](https://github.com/typings/registry). A command-line utility called [typings](https://github.com/typings/typings) is provided to help search and install declaration files from the repositories.

## What does 'declare' do in 'export declare class Actions'?
> The TypeScript declare keyword is used to declare variables that may not have originated from a TypeScript file.
> Imagine that we have a library called myLibrary that doesn’t have a TypeScript declaration file and have a namespace called myLibrary in the global namespace. If you want to use that library in your TypeScript code, you can use the following code: `declare var myLibrary;`
> Starting with the ECMAScript 2015, JavaScript has a concept of modules. TypeScript shares this concept. Modules are executed within their own scope, not in the global scope; this means that variables, functions, classes, etc. declared in a module are not visible outside the module unless they are explicitly exported using one of the export forms. Conversely, to consume a variable, function, class, interface, etc. exported from a different module, it has to be imported using one of the import forms.
