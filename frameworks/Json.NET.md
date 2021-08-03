# Json.NET
> Json.NET is a popular high-performance JSON framework for .NET
> [documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm)

## Benefits and Features
> - Flexible JSON serializer for converting between .NET objects and JSON
> - LINQ to JSON for manually reading and writing JSON
> - High performance: faster than .NET's built-in JSON serializers
> - Write indented, easy-to-read JSON
> - Convert JSON to and from XML
> - Supports .NET 2, .NET 3.5, .NET 4, .NET 4.5, Silverlight, Windows Phone and Windows 8 Store
> The JSON serializer in Json.NET is a good choice when the JSON you are reading or writing maps closely to a .NET class.
> LINQ to JSON is good for situations where you are only interested in getting values from JSON, you don't have a class to serialize or deserialize to, or the JSON is radically different from your class and you need to manually read and write from your objects.

## JsonConvert.DeserializeObject Method
> - DeserializeObject(String, Type), Deserializes the JSON to the specified .NET type.
> Namespace: Newtonsoft.Json, Assembly: Newtonsoft.Json (in Newtonsoft.Json.dll) Version: 10.0.0.0 (10.0.2.20802)
> - Syntax
````C#
public static Object DeserializeObject(
	string value,
	Type type
)
````
> - Parameters
>> - value
>> Type: System.String
>> The JSON to deserialize.
>> - type
>> Type: System.Type
>> The Type of object being deserialized.
>> - Return Value
>> Type: Object
>> The deserialized object from the JSON string.

