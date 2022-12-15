namespace TestApp;

[AttributeUsage(AttributeTargets.Struct)]
public class ByteArrayAttribute : Attribute, IBaseTypeDefinition<byte[]>
{ }

[ByteArray] public readonly partial record struct MyArray;
