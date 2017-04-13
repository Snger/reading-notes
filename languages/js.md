## How can I round a number in JavaScript? .toFixed() returns a string?
1. The toFixed() method converts a number into a string, keeping a specified number of decimals. (price + priceStepNum).toFixed(2)-0; It returns a string because 0.1, and powers thereof (which are used to display decimal fractions), are not representable (at least not with full accuracy) in binary floating-point systems.
2. For example, 0.1 is really 0.1000000000000000055511151231257827021181583404541015625, and 0.01 is really 0.01000000000000000020816681711721685132943093776702880859375. (Thanks to BigDecimal for proving my point. :-P) 
3. Therefore (absent a decimal floating point or rational number type), outputting it as a string is the only way to get it trimmed to exactly the precision required for display.

## Return multiple values in JavaScript?
1. function l(){var l={};return l.a="hello",l.b="bye",l.sayHello=function(){return this.a;},l};
2. When execute l(), will return Object {a: "hello", b: "bye", sayHello: function};
3. Javascript 1.7 — language extension present in some implementations (e.g. Mozilla) — has so-called "destructuring assignments". var [x, y] = [1, 2]; or [x, y] = (function(){ return [3, 4]; })(); //Here we are using ES6's array destructuring feature to assign the returned values to variables.

## Why function foo(){return 1,2,3;} doing console.log([].push(foo())) prints out 1?
1. that's because push returns the length of the array...
2. function bar(){return 7,8,9;} doing [].push(bar()); is also print out 1;

## Chrome Development Tool: [VM] file from javascript, What are these strange and mysterious scripts titled "[VM](XXXX " and where do they come from?
1. It is abbreviation of the phrase Virtual Machine. In the Chrome JavaScript engine (called V8) each script has its own script ID.
2. Sometimes V8 has no information about the file name of a script, for example in the case of an eval. So devtools uses the text "VM" concatenated with the script ID as a title for these scripts.
3. Some sites may fetch many pieces of JavaScript code via XHR and eval it. If a developer wants to see the actual script name for these scripts she can use sourceURL. DevTools parses and uses it for titles, mapping etc.

## javascript Object.assign()
1. The Object.assign() method is used to copy the values of all enumerable own properties from one or more source objects to a target object. It will return the target object.
2. Syntax: Object.assign(target, ...sources) ; Parameters: target //The target object. sources //The source object(s). Return value: The target object.
3. The Object.assign() method only copies enumerable and own properties from a source object to a target object. It uses [[Get]] on the source and [[Set]] on the target, so it will invoke getters and setters. 
4. var obj = { a: 1 }; var copy = Object.assign({}, obj); console.log(copy); // { a: 1 }
5. 
````javascript
var o1 = { a: 1 };
var o2 = { b: 2 };
var o3 = { c: 3 };
var obj = Object.assign(o1, o2, o3);
console.log(obj); // { a: 1, b: 2, c: 3 }
console.log(o1);  // { a: 1, b: 2, c: 3 }, target object itself is changed.
````

## angular.js $parse(expression);
1. expression   (string)  String expression to compile.
2. Returns: function(context, locals)
> context – {object} – an object against which any expressions embedded in the strings are evaluated against (typically a scope object).
> locals – {object=} – local variables context object, useful for overriding values in context.
> The returned function also has the following properties:
>> literal – {boolean} – whether the expression's top-level node is a JavaScript literal.
>> constant – {boolean} – whether the expression is made entirely of JavaScript constant literals.
>> assign – {?function(context, value)} – if the expression is assignable, this will be set to a function to change its value on the given context.
3. Converts Angular expression into a function.
````javascript
var getter = $parse('user.name');
var setter = getter.assign;
var context = {user:{name:'angular'}};
var locals = {user:{name:'local'}};
expect(getter(context)).toEqual('angular');
setter(context, 'newValue');
expect(context.user.name).toEqual('newValue');
expect(getter(context, locals)).toEqual('local');
````