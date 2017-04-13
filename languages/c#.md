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
