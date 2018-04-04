# javascript

<!-- MarkdownTOC -->

- How can I round a number in JavaScript? .toFixed\(\) returns a string?
- Return multiple values in JavaScript?
- Why function foo\(\){return 1,2,3;} doing console.log\(\[\].push(foo(\))) prints out 1?
- Chrome Development Tool: \[VM\] file from javascript, What are these strange and mysterious scripts titled "\[VM\](XXXX " and where do they come from?
- javascript Object.assign\(\)
- angular.js $parse\(expression\);
- conditional \(ternary\) operator
- Arrow functions
- Using a variable for a key in a JavaScript object literal
- Base64 encoding and decoding
- Array.prototype.splice\(\)
- Convert Array to Object
- js隐藏手机号中间四位，变成 * 星号
- How can I get a specific parameter from location.search?
- How to serialize an Object into a list of parameters?
- url params to object
- How do you get a timestamp in JavaScript?
- Why does JS minification convert 1000 to 1E3?

<!-- /MarkdownTOC -->

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
## conditional (ternary) operator
1. The conditional (ternary) operator is the only JavaScript operator that takes three operands. This operator is frequently used as a shortcut for the if statement.
2. Syntax : condition ? expr1 : expr2
3. If condition is true, the operator returns the value of expr1; otherwise, it returns the value of expr2.
4. You can also do more than one operation during the assignation of a value. In this case, the last comma-separated value of the parenthesis will be the value to be assigned.

## Arrow functions
1. An arrow function expression has a shorter syntax than a function expression and does not bind its own this, arguments, super, or new.target. These function expressions are best suited for non-method functions, and they cannot be used as constructors.
2. Two factors influenced the introduction of arrow functions: shorter functions and non-binding of this.

## Using a variable for a key in a JavaScript object literal
1. `var thetop = 'top', var obj = { thetop : 10 }` is a valid object literal. The code will create an object with a property named thetop that has a value of 10. In ES5 and earlier, you cannot use a variable as a property name inside an object literal.
2. Assign the variable property name with a value of 10: `aniArgs[thetop] = 10`;
3. ES6 defines ComputedPropertyName as part of the grammar for object literals, which allows you to write the code like this: `var thetop = "top",obj = { [thetop]: 10 };`
4. This is the HTML rendering of ECMA-262 6th Edition, The ECMAScript 2015 Language Specification. -> 12 ECMAScript Language: Expressions -> 12.2 Primary Expression -> 12.2.6 Object Initializer: An object initializer is an expression describing the initialization of an Object, written in a form resembling a literal. It is a list of zero or more pairs of property keys and associated values, enclosed in curly brackets. The values need not be literals; they are evaluated each time the object initializer is evaluated. -> 12.2.6.6 Static Semantics: PropName -> ComputedPropertyName : [ AssignmentExpression ] Return empty.

## Base64 encoding and decoding
1. Base64 is a group of similar binary-to-text encoding schemes that represent binary data in an ASCII string format by translating it into a radix-64 representation. The term Base64 originates from a specific MIME content transfer encoding.
2. Base64 encoding schemes are commonly used when there is a need to encode binary data that needs to be stored and transferred over media that are designed to deal with textual data. This is to ensure that the data remain intact without modification during transport. Base64 is commonly used in a number of applications including email via MIME, and storing complex data in XML.
3. In JavaScript there are two functions respectively for decoding and encoding base64 strings: atob(), btoa()
4. The atob() function decodes a string of data which has been encoded using base-64 encoding. Conversely, the btoa() function creates a base-64 encoded ASCII string from a "string" of binary data.
5. Both atob() and btoa() work on strings. If you want to work on ArrayBuffers, please, read this paragraph.

## Array.prototype.splice()
1. The splice() method changes the content of an array by removing existing elements and/or adding new elements.
1. Syntax
````javascript
array.splice(start)
array.splice(start, deleteCount)
array.splice(start, deleteCount, item1, item2, ...)
````
1. Parameters
- start: Index at which to start changing the array (with origin 0). If greater than the length of the array, actual starting index will be set to the length of the array. If negative, will begin that many elements from the end of the array.
- deleteCount [Optional]: An integer indicating the number of old array elements to remove. If deleteCount is 0, no elements are removed. In this case, you should specify at least one new element. If deleteCount is greater than the number of elements left in the array starting at start, then all of the elements through the end of the array will be deleted. If deleteCount is omitted, deleteCount will be equal to (arr.length - start).
- item1, item2, ... [Optional]: The elements to add to the array, beginning at the start index. If you don't specify any elements, splice() will only remove elements from the array.
1. [Return value] An array containing the deleted elements. If only one element is removed, an array of one element is returned. If no elements are removed, an empty array is returned.
1. [Description] If you specify a different number of elements to insert than the number you're removing, the array will have a different length at the end of the call.

## Convert Array to Object
````js
let accountInfo = list.reduce(function (acc, cur, i) {
    acc[cur['coinCode']] = cur;
    return acc;
}, {});
````

## js隐藏手机号中间四位，变成 * 星号
````
var tel = "13888888888";
var reg = /^(\d{3})\d{4}(\d{4})$/;
tel = tel.replace(reg, "$1****$2");
````

## How can I get a specific parameter from location.search?
````javascript
var parseQueryString = function() {
    var str = window.location.search;
    var objURL = {};
    str.replace(
        new RegExp( "([^?=&]+)(=([^&]*))?", "g" ),
        function( $0, $1, $2, $3 ){
            objURL[ $1 ] = $3;
        }
    );
    return objURL;
};
//Example how to use it:
var params = parseQueryString();
alert(params["foo"]);
````

## How to serialize an Object into a list of parameters?
````javascript
var str = "";
for (var key in obj) {
    if (str != "") {
        str += "&";
    }
    str += key + "=" + encodeURIComponent(obj[key]);
}
````
````es6
function params(data) {
  return Object.keys(data).map(key => `${key}=${encodeURIComponent(data[key])}`).join('&');
}
````
````es2017
Object.entries(obj).map(([key, val]) => `${key}=${encodeURIComponent(val)}`).join('&')
````

## url params to object
````javascript
function parToObject(params) {
	var rv = {};
	var arr = params.split('&');
	for (var i = 0; i < arr.length; ++i){
		var par = arr[i].split('=');
		var key = par[0];
		var value=par[1];
		rv[key] = decodeURIComponent(value);
	}
	return rv;
}
````

## How do you get a timestamp in JavaScript?
> new Date().valueOf();
- Short & Snazzy:
	+ new Date()
A unary operator like plus triggers the valueOf method in the Date object and it returns the timestamp (without any alteration).
- Details:
On almost all current browsers you can use Date.now() to get the UTC timestamp in milliseconds; a notable exception to this is IE8 and earlier (see compatibility table).
You can easily make a shim for this, though:
	if (!Date.now) {
	    Date.now = function() { return new Date().getTime(); }
	}
To get the timestamp in seconds, you can use:
	Math.floor(Date.now() / 1000)
Or alternatively you could use:
	Date.now() / 1000 | 0
Which should be slightly faster, but also less readable (also see this answer).
> I would recommend using Date.now() (with compatibility shim). It's slightly better because it's shorter & doesn't create a new Date object. However, if you don't want a shim & maximum compatibility, you could use the "old" method to get the timestamp in milliseconds:
	new Date().getTime()
Which you can then convert to seconds like this:
	Math.round(new Date().getTime()/1000)
And you can also use the valueOf method which we showed above:
	new Date().valueOf()

## Why does JS minification convert 1000 to 1E3?
> they are the same value, 1E3 is 10 to the third power, or 1000
> The whole point of minification is to be able to pass less data over the network but retain the same functionality.
> Taken from wikipedia:
>> Minification (also minimisation or minimization), in computer programming languages and especially JavaScript, is the process of removing all unnecessary characters from source code without changing its functionality. These unnecessary characters usually include white space characters, new line characters, comments, and sometimes block delimiters, which are used to add readability to the code but are not required for it to execute.
> As long as the size is smaller the minification is doing its job.
> 1E3 pretty much means 10 to the power of 3; a shorter way of representing the number 1000.
> [testing in browser](https://jsperf.com/1000-vs-1e3)
