## What does 'declare' do in 'export declare class Actions'?
1. The TypeScript declare keyword is used to declare variables that may not have originated from a TypeScript file.
2. Imagine that we have a library called myLibrary that doesn’t have a TypeScript declaration file and have a namespace called myLibrary in the global namespace. If you want to use that library in your TypeScript code, you can use the following code: `declare var myLibrary;`
3. Starting with the ECMAScript 2015, JavaScript has a concept of modules. TypeScript shares this concept. Modules are executed within their own scope, not in the global scope; this means that variables, functions, classes, etc. declared in a module are not visible outside the module unless they are explicitly exported using one of the export forms. Conversely, to consume a variable, function, class, interface, etc. exported from a different module, it has to be imported using one of the import forms.