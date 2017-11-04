# C sharp

<!-- MarkdownTOC -->

- How to initialize empty array in C
- How to create an anonymous object in C
- Creating an JSON array in C
- What's Assemblies?
- Can Assemblies contain more than one modules?
- Assemblies have the following properties
- lock Statement \(C# Reference\)
- String To Enum Conversion
- When are two enums equal in C#?
- enum \(C# Reference\)
- Enum.Parse Method \(Type, String\)
- DateTime.Parse Method
- JsonSerializerSettings Class
- JsonProperty Class
- JsonConverter Class
- HttpConfiguration Class
- ModelBinders Class
- How model binding works
- Customize model binding behavior with attributes
- Binding formatted data from the request body
- Introduction to model validation
- System.ComponentModel.DataAnnotations Namespace
- Manual validation
- Custom validation
- String.Format Method
- What's the @ in front of a string in C#?
- What does $ mean before a string?
- `=>` Operator, Lambda Expressions \(C# Programming Guide\)
- Using Delegates
- Func Delegate
- out \(C# Reference\)
- What's the difference between the 'ref' and 'out' keywords?
- Enumerable.Select  Method \(IEnumerable, Func\)
- Dictionary Class
- HttpResponseMessage Class
- ActionNameAttribute.Name Property
- ActionNameAttribute Class
- ?? Operator \(C# Reference\)
- ConcurrentDictionary Class
- String.Trim Method \(\)
- Do I need to check the Count\(\) of an Enumerable before foreach?
- How do I identify if a string is a number?
- Inconsistent accessibility: base class 'A' is less accessible than class 'B'

<!-- /MarkdownTOC -->

## How to initialize empty array in C#
> var listOfStrings = new List<string>();
> string[] a= new string[] { };
> string[] a = new string[0];
> String[] a = Array.Empty<string>(); (In .Net 4.6 the preferred way is to use a new method, Array.Empty)

## How to create an anonymous object in C#
> var v = new { Amount = 108, Message = "Hello" };  

## Creating an JSON array in C#
````c#
var context = new[] {
    new { code = "apple", id = 3 },
    new { code = "grape", id = 2 },
    new { code = "TEST", id = 1}
};
````
## What's Assemblies?
1. Assemblies form the fundamental unit of deployment, version control, reuse, activation scoping, and security permissions for a .NET-based application. Assemblies take the form of an executable (.exe) file or dynamic link library (.dll) file, and are the building blocks of the .NET Framework. They provide the common language runtime with the information it needs to be aware of type implementations. You can think of an assembly as a collection of types and resources that form a logical unit of functionality and are built to work together.

## Can Assemblies contain more than one modules?
1. Assemblies can contain one or more modules. For example, larger projects may be planned in such a way that several individual developers work on separate modules, all coming together to create a single assembly. For more information about modules, see the topic How to: Build a Multifile Assembly."

##Assemblies have the following properties
1. Assemblies are implemented as .exe or .dll files.
2. You can share an assembly between applications by putting it in the global assembly cache. Assemblies must be strong-named before they can be included in the global assembly cache. For more information, see Strong-Named Assemblies.
3. Assemblies are only loaded into memory if they are required. If they are not used, they are not loaded. This means that assemblies can be an efficient way to manage resources in larger projects.
4. You can programmatically obtain information about an assembly by using reflection. For more information, see Reflection.
5. If you want to load an assembly only to inspect it, use a method such as ReflectionOnlyLoadFrom."

## lock Statement (C# Reference)
1. The lock keyword marks a statement block as a critical section by obtaining the mutual-exclusion lock for a given object, executing a statement, and then releasing the lock. 
2. The lock keyword ensures that one thread does not enter a critical section of code while another thread is in the critical section. If another thread tries to enter a locked code, it will wait, block, until the object is released.
3. Best practice is to define a private object to lock on, or a private static object variable to protect data common to all instances.
4. You can't use the await keyword in the body of a lock statement.

## String To Enum Conversion
> - Enum to string
To convert enum to string use simply Enum.ToString method.
````C#
Animal animal = Animal.Cat;
string str = animal.ToString();  // "Cat"
````
> - String to enum
To convert string to enum use static method Enum.Parse. Parameters of this method are enum type, the string value and optionally indicator to ignore case.
````C#
string str = "Dog";
Animal animal = (Animal)Enum.Parse(typeof(Animal), str);  // Animal.Dog
Animal animal = (Animal)Enum.Parse(typeof(Animal), str, true); // case insensitive
````

## When are two enums equal in C#?
> - Enum.Equals Method (Object)
> Returns a value indicating whether this instance is equal to a specified object.
> - Parameters
obj
Type: System.Object
An object to compare with this instance, or null.
> - Return Value
Type: System.Boolean
true if obj is an enumeration value of the same type and with the same underlying value as this instance; otherwise, false.
> - Remarks
The Enum.Equals(Object) method overrides ValueType.Equals(Object) to define how enumeration members are evaluated for equality.

## enum (C# Reference)
1. The enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants called the enumerator list. Usually it is best to define an enum directly within a namespace so that all classes in the namespace can access it with equal convenience. However, an enum can also be nested within a class or struct. By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1. 
2. Enumerators can use initializers to override the default values. However, including a constant that has the value of 0 is recommended.
3. Every enumeration type has an underlying type, which can be any integral type except char. The default underlying type of enumeration elements is int. To declare an enum of another integral type, such as byte, use a colon after the identifier followed by the type, The approved types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.

## Enum.Parse Method (Type, String)
> 1. Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
2. Namespace: System; Assembly: mscorlib (in mscorlib.dll)
3. [Remarks] The value parameter contains the string representation of an enumeration member's underlying value or named constant, or a list of named constants delimited by commas (,). One or more blank spaces can precede or follow each value, name, or comma in value. If value is a list, the return value is the value of the specified names combined with a bitwise OR operation. If value is a name that does not correspond to a named constant of enumType, the method throws an ArgumentException. If value is the string representation of an integer that does not represent an underlying value of the enumType enumeration, the method returns an enumeration member whose underlying value is value converted to an integral type. If this behavior is undesirable, call the IsDefined method to ensure that a particular string representation of an integer is actually a member of enumType. The following example defines a Colors enumeration, calls the Parse(Type, String) method to convert strings to their corresponding enumeration values, and calls the IsDefined method to ensure that particular integral values are underlying values in the Colors enumeration.
> If value is a name that does not correspond to a named constant of enumType, the method *throws an ArgumentException*. If value is the string representation of an integer that does not represent an underlying value of the enumType enumeration, the method returns an enumeration member whose underlying value is value converted to an integral type. If this behavior is undesirable, call the IsDefined method to ensure that a particular string representation of an integer is actually a member of enumType. The following example defines a Colors enumeration, calls the Parse(Type, String) method to convert strings to their corresponding enumeration values, and calls the IsDefined method to ensure that particular integral values are underlying values in the Colors enumeration.

## DateTime.Parse Method
1. Converts the string representation of a date and time to its DateTime equivalent.
2. Namespace: System, Assembly: mscorlib (in mscorlib.dll)
3. [Overloaded method syntax] DateTime.Parse(String s): For the conversion, uses the formatting conventions of the current thread culture and interprets the string based on the DateTimeStyles.AllowWhiteSpaces style flag (example).
4. [Parameters] s -- String -- A string that contains the date and time to convert. See The string to parse.
Default value: None (parameter is used by all overloads)

## JsonSerializerSettings Class
1. Specifies the settings on a JsonSerializer object.
2. Namespace: Newtonsoft.Json, Assembly: Newtonsoft.Json (in Newtonsoft.Json.dll) Version: 10.0.0.0 (10.0.1.20720)
3. [Properties] DateTimeZoneHandling: Gets or sets how DateTime time zones are handled during serialization and deserialization.

## JsonProperty Class
1. Maps a JSON property to a .NET member or constructor parameter.
1. Namespace: Newtonsoft.Json.Serialization, Inheritance Hierarchy: System.Object > Newtonsoft.Json.Serialization.JsonProperty

## JsonConverter Class
1. Converts an object to and from JSON.
1. Inheritance Hierarchy: System.Object > Newtonsoft.Json.JsonConverter, Namespace: Newtonsoft.Json

## HttpConfiguration Class
1. Represents a configuration of HttpServer instances.
1. Namespace: System.Web.Http, Assembly: System.Web.Http (in System.Web.Http.dll)

## ModelBinders Class
1. Provides global access to the model binders for the application.
2. Namespace:   System.Web.Mvc, Assembly:  System.Web.Mvc (in System.Web.Mvc.dll)
3. [Properties] Binders: Gets the model binders for the application.
4. Model binding in ASP.NET Core MVC maps data from HTTP requests to action method parameters. The parameters may be simple types such as strings, integers, or floats, or they may be complex types. This is a great feature of MVC because mapping incoming data to a counterpart is an often repeated scenario, regardless of size or complexity of the data. MVC solves this problem by abstracting binding away so developers don't have to keep rewriting a slightly different version of that same code in every app. Writing your own text to type converter code is tedious, and error prone.

## How model binding works
1. When MVC receives an HTTP request, it routes it to a specific action method of a controller. It determines which action method to run based on what is in the route data, then it binds values from the HTTP request to that action method's parameters.
2. MVC will try to bind request data to the action parameters by name. MVC will look for values for each parameter using the parameter name and the names of its public settable properties.
3. In addition to route values MVC will bind data from various parts of the request and it does so in a set order. Below is a list of the data sources in the order that model binding looks through them:
> Form values: These are form values that go in the HTTP request using the POST method. (including jQuery POST requests).
> Route values: The set of route values provided by Routing
> Query strings: The query string part of the URI.
> Note: Form values, route data, and query strings are all stored as name-value pairs.
4. Since model binding asked for a key named id and there is nothing named id in the form values, it moved on to the route values looking for that key.
5. If the action method's parameter were a class such as the Movie type, which contains both simple and complex types as properties, MVC's model binding will still handle it nicely. It uses reflection and recursion to traverse the properties of complex types looking for matches. Model binding looks for the pattern parameter_name.property_name to bind values to properties. If it doesn't find matching values of this form, it will attempt to bind using just the property name. For those types such as Collection types, model binding looks for matches to parameter_name[index] or just [index]. Model binding treats Dictionary types similarly, asking for parameter_name[key] or just [key], as long as the keys are simple types. Keys that are supported match the field names HTML and tag helpers generated for the same model type. This enables round-tripping values so that the form fields remain filled with the user's input for their convenience, for example, when bound data from a create or edit did not pass validation.
6. In order for binding to happen the class must have a public default constructor and member to be bound must be public writable properties. When model binding happens the class will only be instantiated using the public default constructor, then the properties can be set.
7. When a parameter is bound, model binding stops looking for values with that name and it moves on to bind the next parameter. If binding fails, MVC does not throw an error. You can query for model state errors by checking the ModelState.IsValid property.
8. Once model binding is complete, Validation occurs. Default model binding works great for the vast majority of development scenarios. It is also extensible so if you have unique needs you can customize the built-in behavior.

## Customize model binding behavior with attributes
1. MVC contains several attributes that you can use to direct its default model binding behavior to a different source. For example, you can specify whether binding is required for a property, or if it should never happen at all by using the [BindRequired] or [BindNever] attributes. Alternatively, you can override the default data source, and specify the model binder's data source. Below is a list of model binding attributes:+
> [BindRequired]: This attribute adds a model state error if binding cannot occur.
> [BindNever]: Tells the model binder to never bind to this parameter.
> [FromHeader], [FromQuery], [FromRoute], [FromForm]: Use these to specify the exact binding source you want to apply.
> [FromServices]: This attribute uses dependency injection to bind parameters from services.
> [FromBody]: Use the configured formatters to bind data from the request body. The formatter is selected based on content type of the request.
> [ModelBinder]: Used to override the default model binder, binding source and name.

## Binding formatted data from the request body
1. Request data can come in a variety of formats including JSON, XML and many others. When you use the [FromBody] attribute to indicate that you want to bind a parameter to data in the request body, MVC uses a configured set of formatters to handle the request data based on its content type. By default MVC includes a JsonInputFormatter class for handling JSON data, but you can add additional formatters for handling XML and other custom formats.
2. [Note] There can be at most one parameter per action decorated with [FromBody]. The ASP.NET Core MVC run-time delegates the responsibility of reading the request stream to the formatter. Once the request stream is read for a parameter, it's generally not possible to read the request stream again for binding other [FromBody] parameters.
3. [Note] The JsonInputFormatter is the default formatter and is based on Json.NET.
4. ASP.NET selects input formatters based on the Content-Type header and the type of the parameter, unless there is an attribute applied to it specifying otherwise. If you'd like to use XML or another format you must configure it in the Startup.cs file, but you may first have to obtain a reference to Microsoft.AspNetCore.Mvc.Formatters.Xml using NuGet. Code in the Startup.cs file contains a ConfigureServices method with a services argument you can use to build up services for your ASP.NET app. 

## Introduction to model validation
1. Before an app stores data in a database, the app must validate the data. Data must be checked for potential security threats, verified that it is appropriately formatted by type and size, and it must conform to your rules. Validation is necessary although it can be redundant and tedious to implement. In MVC, validation happens on both the client and server.+
2. Fortunately, .NET has abstracted validation into validation attributes. These attributes contain validation code, thereby reducing the amount of code you must write.

## System.ComponentModel.DataAnnotations Namespace
1. The System.ComponentModel.DataAnnotations namespace provides attribute classes that are used to define metadata for ASP.NET MVC and ASP.NET data controls.
2. [Class] CompareAttribute: Provides an attribute that compares two properties.
3. [Class] MaxLengthAttribute: Specifies the maximum length of array or string data allowed in a property.
4. [Class] PhoneAttribute: Specifies that a data field value is a well-formed phone number using a regular expression for phone numbers.

## Manual validation
1. After model binding and validation are complete, you may want to repeat parts of it. For example, a user may have entered text in a field expecting an integer, or you may need to compute a value for a model's property.
2. You may need to run validation manually. To do so, call the TryValidateModel method

## Custom validation
1. Validation attributes work for most validation needs. However, some validation rules are specific to your business, as they're not just generic data validation such as ensuring a field is required or that it conforms to a range of values. For these scenarios, custom validation attributes are a great solution. Creating your own custom validation attributes in MVC is easy. Just inherit from the ValidationAttribute, and override the IsValid method. The IsValid method accepts two parameters, the first is an object named value and the second is a ValidationContext object named validationContext. Value refers to the actual value from the field that your custom validator is validating.
2. Alternatively, this same code could be placed in the model by implementing the Validate method on the IValidatableObject interface. While custom validation attributes work well for validating individual properties, implementing IValidatableObject can be used to implement class-level validation as seen here.

## String.Format Method
1. Converts the value of objects to strings based on the formats specified and inserts them into another string.
2. [Overload] Format(String, Object): Replaces one or more format items in a specified string with the string representation of a specified object.
3. Inserting a string: String.Format starts with a format string, followed by one or more objects or expressions that will be converted to strings and inserted at a specified place in the format string. The {0} in the format string is a format item. 0 is the index of the object whose string value will be inserted at that position. (Indexes start at 0.) If the object to be inserted is not a string, its ToString method is called to convert it to one before inserting it in the result string.
4. Controlling formatting: You can follow the index in a format item with a format string to control how an object is formatted. For example, {0:d} applies the "d" format string to the first object in the object list. 
5. Controlling spacing: You can define the width of the string that is inserted into the result string by using syntax such as {0,12}, which inserts a 12-character string. In this case, the string representation of the first object is right-aligned in the 12-character field. (If the string representation of the first object is more than 12 characters in length, though, the preferred field width is ignored, and the entire string is inserted into the result string.)
6. Controlling alignment: By default, strings are right-aligned within their field if you specify a field width. To left-align strings in a field, you preface the field width with a negative sign, such as {0,-12} to define a 12-character right-aligned field.

## What's the @ in front of a string in C#?
1. It marks the string as a verbatim string literal - anything in the string that would normally be interpreted as an escape sequence is ignored. So `"C:\\Users\\Rich"` is the same as `@"C:\Users\Rich"`
2. Literals are how you hard-code strings into C# programs. There are two types of string literals in C# - regular string literals and verbatim string literals. Regular string literals are similar to those in many other languages such as Java and C - they start and end with ", and various characters (in particular, " itself, \, and carriage return (CR) and line feed (LF)) need to be "escaped" to be represented in the string. Verbatim string literals allow pretty much anything within them, and end at the first " which isn't doubled. Even carriage returns and line feeds can appear in the literal! To obtain a " within the string itself, you need to write "". Verbatim string literals are distinguished by having an @ before the opening quote.
3. An escape sequence is a series of characters used to change the state of computers and their attached peripheral devices. These are also known as control sequences, reflecting their use in device control. Some control sequences are special characters that always have the same meaning. Escape sequences use an escape character to change the meaning of the characters which follow it, meaning that the characters can be interpreted as a command to be executed rather than as data.

## What does $ mean before a string?
1. `$` is short-hand for `String.Format` and is used with string interpolations, which is a new feature of C# 6. As used in your case, it does nothing, just as `string.Format()` would do nothing.
2. There's also an alternative - less well known - form of string interpolation using `$@`  (the order of the two symbols is important). It allows the features of a `@""` string to be mixed with `$""` to support string interpolations without the need for `\\` throughout your string. 
3. It is *Interpolated Strings*. You can use an interpolated string anywhere you can use a string literal. When running your program would execute the code with the interpolated string literal, the code computes a new string literal by evaluating the interpolation expressions. This computation occurs each time the code with the interpolated string executes.
4. Interpolated Strings (C# Reference): Used to construct strings. An interpolated string looks like a template string that contains interpolated expressions. An interpolated string returns a string that replaces the interpolated expressions that it contains with their string representations.

## `=>` Operator, Lambda Expressions (C# Programming Guide)
1. The => token is called the lambda operator. It is used in lambda expressions to separate the input variables on the left side from the lambda body on the right side. Lambda expressions are inline expressions similar to anonymous methods but more flexible; they are used extensively in LINQ queries that are expressed in method syntax.
2. A lambda expression is an anonymous function that you can use to create delegates or expression tree types. By using lambda expressions, you can write local functions that can be passed as arguments or returned as the value of function calls. Lambda expressions are particularly helpful for writing LINQ query expressions.
3. To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator =>, and you put the expression(单句表达式) or statement(任意数量语句) block on the other side. For example, the lambda expression x => x * x specifies a parameter that’s named x and returns the value of x squared.
4. Lambdas are used in method-based LINQ queries as arguments to standard query operator methods such as Where.
5. When you use method-based syntax to call the Where method in the Enumerable class (as you do in LINQ to Objects and LINQ to XML) the parameter is a delegate type System.Func<T,TResult>. A lambda expression is the most convenient way to create that delegate. When you call the same method in, for example, the System.Linq.Queryable class (as you do in LINQ to SQL) then the parameter type is an System.Linq.Expressions.Expression where Func is any of the Func delegates with up to sixteen input parameters. Again, a lambda expression is just a very concise way to construct that expression tree. The lambdas allow the Where calls to look similar although in fact the type of object created from the lambda is different.
6. Lambdas are not allowed on the left side of the is or as operator.
7. Expression Lambdas
- A lambda expression with an expression on the right side of the => operator is called an expression lambda. Expression lambdas are used extensively in the construction of Expression Trees.
- The parentheses are optional only if the lambda has one input parameter; otherwise they are required. Two or more input parameters are separated by commas enclosed in parentheses.
- Specify zero input parameters with empty parentheses.
8. Statement Lambdas
- A statement lambda resembles an expression lambda except that the statement(s) is enclosed in braces.
- The body of a statement lambda can consist of any number of statements; however, in practice there are typically no more than two or three.
- Statement lambdas, like anonymous methods, cannot be used to create expression trees.
9. Async Lambdas
- You can easily create lambda expressions and statements that incorporate asynchronous processing by using the async and await keywords. 
10. Lambdas with the Standard Query Operators
- Many Standard query operators have an input parameter whose type is one of the Func<T,TResult> family of generic delegates. These delegates use type parameters to define the number and types of input parameters, and the return type of the delegate. Func delegates are very useful for encapsulating user-defined expressions that are applied to each element in a set of source data.

## Using Delegates
1. A delegate is a type that safely encapsulates a method, similar to a function pointer in C and C++. Unlike C function pointers, delegates are object-oriented, type safe, and secure. The type of a delegate is defined by the name of the delegate. 
2. A delegate object is normally constructed by providing the name of the method the delegate will wrap, or with an anonymous Method. Once a delegate is instantiated, a method call made to the delegate will be passed by the delegate to that method. The parameters passed to the delegate by the caller are passed to the method, and the return value, if any, from the method is returned to the caller by the delegate. This is known as invoking the delegate. 
3. Delegate types are derived from the Delegate class in the .NET Framework. Delegate types are sealed—they cannot be derived from— and it is not possible to derive custom classes from Delegate. Because the instantiated delegate is an object, it can be passed as a parameter, or assigned to a property. This allows a method to accept a delegate as a parameter, and call the delegate at some later time. This is known as an asynchronous callback, and is a common method of notifying a caller when a long process has completed. When a delegate is used in this fashion, the code using the delegate does not need any knowledge of the implementation of the method being used. The functionality is similar to the encapsulation interfaces provide.
4. When a delegate is constructed to wrap an instance method, the delegate references both the instance and the method. A delegate has no knowledge of the instance type aside from the method it wraps, so a delegate can refer to any type of object as long as there is a method on that object that matches the delegate signature. When a delegate is constructed to wrap a static method, it only references the method. 
5. A delegate can call more than one method when invoked. This is referred to as multicasting. To add an extra method to the delegate's list of methods—the invocation list—simply requires adding two delegates using the addition or addition assignment operators ('+' or '+='). 

## Func<​T,​TResult> Delegate
1. Encapsulates a method that has one parameter and returns a value of the type specified by the TResult parameter.
2. Assemblies: System.Runtime.dll, mscorlib.dll, netstandard.dll
3. `public delegate TResult Func<in T,out TResult>(T arg);`
4. Type Parameters
- T: The type of the parameter of the method that this delegate encapsulates.
- TResult: The type of the return value of the method that this delegate encapsulates.
- Inheritance: ObjectDelegateFunc<T,TResult>
5. You can use this delegate to represent a method that can be passed as a parameter without explicitly declaring a custom delegate. The encapsulated method must correspond to the method signature that is defined by this delegate. This means that the encapsulated method must have one parameter that is passed to it by value, and that it must return a value.

## out (C# Reference)
1. You can use the out contextual keyword in two contexts:
- As a parameter modifier, which lets pass an argument to a method by reference rather than by value.
- In generic type parameter declarations for interfaces and delegates, which specifies that a type parameter is covariant.

## What's the difference between the 'ref' and 'out' keywords?
1. ref tells the compiler that the object is initialized before entering the function, while  out tells the compiler that the object will be initialized inside the function.
2. So while ref is two-ways, out is out-only.

## Enumerable.Select<TSource, TResult>  Method (IEnumerable<TSource>, Func<TSource, TResult>)
1. Projects each element of a sequence into a new form.
2. Namespace: System.Linq; Assembly: System.Core (in System.Core.dll)
3. Syntax
````c#
public static IEnumerable<TResult> Select<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, TResult> selector
)
````
- Parameters
- source
> Type: System.Collections.Generic.IEnumerable<TSource>
> A sequence of values to invoke a transform function on.
- selector
> Type: System.Func<TSource, TResult>
> A transform function to apply to each element.
- Return Value
> Type: System.Collections.Generic.IEnumerable<TResult>
> An IEnumerable<T> whose elements are the result of invoking the transform function on each element of source.
4. [Remarks] This method is implemented by using deferred execution. The immediate return value is an object that stores all the information that is required to perform the action. The query represented by this method is not executed until the object is enumerated either by calling its GetEnumerator method directly or by using foreach in Visual C# or For Each in Visual Basic.
5. [Remarks] This projection method requires the transform function, selector, to produce one value for each value in the source sequence, source. If selector returns a value that is itself a collection, it is up to the consumer to traverse the subsequences manually. In such a situation, it might be better for your query to return a single coalesced sequence of values. To achieve this, use the SelectMany<TSource,TResult> method instead of Select<TSource,TResult>. Although SelectMany works similarly to Select, it differs in that the transform function returns a collection that is then expanded by SelectMany before it is returned.

## Dictionary<TKey, TValue> Class
1. Represents a collection of keys and values.
1. Namespace: System.Collections.Generic, Assembly:  mscorlib (in mscorlib.dll)

## HttpResponseMessage Class
1. Represents a HTTP response message.
1. Inheritance Hierarchy: System.Object > System.Net.Http.HttpResponseMessage

## ActionNameAttribute.Name Property
1. Gets or sets the name of the action.
1. Namespace: System.Web.Mvc, Assembly: System.Web.Mvc (in System.Web.Mvc.dll)

## ActionNameAttribute Class
1. Represents an attribute that is used for the name of an action.
1. Inheritance Hierarchy: System.Object > System.Attribute > System.Web.Mvc.ActionNameSelectorAttribute > System.Web.Mvc.ActionNameAttribute, Namespace:  System.Web.Mvc, Assembly:  System.Web.Mvc (in System.Web.Mvc.dll)

## ?? Operator (C# Reference)
1. The ?? operator is called the null-coalescing operator. It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand. 1
1. [Remarks] A nullable type can represent a value from the type’s domain, or the value can be undefined (in which case the value is null). You can use the ?? operator’s syntactic expressiveness to return an appropriate value (the right hand operand) when the left operand has a nullible type whose value is null. If you try to assign a nullable value type to a non-nullable value type without using the ?? operator, you will generate a compile-time error. If you use a cast, and the nullable value type is currently undefined, an InvalidOperationException exception will be thrown. For more information, see Nullable Types.
1. The result of a ?? operator is not considered to be a constant even if both its arguments are constants.

## ConcurrentDictionary<TKey, TValue> Class
1. Represents a thread-safe collection of key/value pairs that can be accessed by multiple threads concurrently.
1. Namespace: System.Collections.Concurrent, Assembly: mscorlib (in mscorlib.dll)
1. [Thread Safety] All public and protected members of ConcurrentDictionary<TKey, TValue> are thread-safe and may be used concurrently from multiple threads. However, members accessed through one of the interfaces the ConcurrentDictionary<TKey, TValue> implements, including extension methods, are not guaranteed to be thread safe and may need to be synchronized by the caller.

## String.Trim Method ()
> - Removes all leading and trailing white-space characters from the current String object.
> - Return Value
Type: System.String
The string that remains after all white-space characters are removed from the start and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.
> - Examples
````c#
String str = " C# ";
Console.WriteLine("Hello{0}World!", str);
string trStr = str.Trim();
Console.WriteLine("Hello{0}World!", trStr );
````
## Do I need to check the Count() of an Enumerable before foreach?
> No, the opposite can be true. If it's not a collection (like a List or Array) but a deferred executed query it must be executed completely which can be very expensive, just to determine the count. In your example it's actually a List, Enumerable.Count is clever enough to try to cast it to a ICollection<T>/ICollection first . If that succeeds the Count property is used.
> So just use the foreach. It doesn't hurt if the sequence is empty, the loop will be exited immediately.
> For the same reason it's better to use Enumerable.Any instead of Count() > 0 if you just want to check if a sequence contains at least one element. The intention is also more clear.

## How do I identify if a string is a number?
> - int.TryParse
````c#
int n;
bool isNumeric = int.TryParse("123", out n);
// Update As of C# 7:
var isNumeric = int.TryParse("123", out var n);
// Though, I would use double.TryParse, since we want to know if it represents a number at all.
// One caveat: TryParse could overflow if you have a very long string. If that's a possibility, regular expressions might be a better option
````
> - Regex.IsMatch
````c#
Regex.IsMatch(input, @"^\d+$");
Regex.IsMatch(input, @"\d")
````

## Inconsistent accessibility: base class 'A' is less accessible than class 'B'
> either change class A to public or class B to internal.
> you need to have your base classes of which you inherit to be equally open or more open than your derived classes. I suggest you read through the documentation about the access [modifiers of C#](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/accessibility-levels).
