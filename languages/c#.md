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
