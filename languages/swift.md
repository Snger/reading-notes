## What's the _ underscore representative of in Swift References? (Why do I need underscores in swift?)
1. There are a few nuances to different use cases, but generally an underscore means "ignore this".
2. When declaring a new function, an underscore tells Swift that the parameter should have no label when called — that's the case you're seeing. A fuller function declaration looks like this: `func myFunc(label name: Int) // call it like myFunc(label: 3)`
- 1. "label" is an argument label, and must be present when you call the function. (And since Swift 3, labels are required for all arguments by default.) "name" is the variable name for that argument that you use inside the function. A shorter form looks like this: `func myFunc(name: Int) // call it like myFunc(name: 3)`
- 1. This is a shortcut that lets you use the same word for both external argument label and internal parameter name. It's equivalent to func myFunc(name name: Int).
- 1. If you want your function to be callable without parameter labels, you use the underscore _ to make the label be nothing/ignored. (In that case you have to provide an internal name if you want to be able to use the parameter.) `func myFunc(_ name: Int) // call it like myFunc(3)`
3. In an assignment statement, an underscore means "don't assign to anything". You can use this if you want to call a function that returns a result but don't care about the returned value.
- `_ = someFunction()`
- Or, like in the article you linked to, to ignore one element of a returned tuple:
- `let (x, _) = someFunctionThatReturnsXandY()`
4. When you write a closure that implements some defined function type, you can use the underscore to ignore certain parameters.
- Similarly, when declaring a function that adopts a protocol or overrides a superclass method, you can use _ for parameter names to ignore parameters. Since the protocol/superclass might also define that the parameter has no label, you can even end up with two underscores in a row.
5. Somewhat related to the last two styles: when using a flow control construct that binds a local variable/constant, you can use _ to ignore it. For example, if you want to iterate a sequence without needing access to its members.
6. If you're binding tuple cases in a switch statement, the underscore can work as a wildcard.

