[![NuGet Package](https://img.shields.io/nuget/v/AndreasDorfer.BaseTypes.svg)](https://www.nuget.org/packages/AndreasDorfer.BaseTypes/)
# AD.BaseTypes
Fight primitive obsession and create expressive domain models with source generators.
## NuGet Package
    PM> Install-Package AndreasDorfer.BaseTypes -Version 0.1.1
## Motivation
Consider the following snippet:
```csharp
class Employee
{
    public string Id { get; }
    public string DepartmentId { get; }
    //more properties
    
    public Department GetDepartment() =>
        departmentRepository.Load(DepartmentId);
}

interface IDepartmentRepository
{
    Department Load(string id);
}
```
Both the employee's ID and the associated department's ID are modeled as strings ... although they are logically separate and must never be mixed. What if you accidentally use the wrong ID in `GetDepartment`?
```csharp
public Department GetDepartment() =>
    departmentRepository.Load(Id);
```
Your code still compiles. Hopefully, you've got some tests to catch that error. But why not utilize the type system to prevent that bug in the first place? C# 9 records to the rescue:
```csharp
record EmployeeId(string Value);
record DepartmentId(string Value);

class Employee
{
    public EmployeeId Id { get; }
    public DepartmentId DepartmentId { get; }
    //more properties
    
    public Department GetDepartment() =>
        departmentRepository.Load(DepartmentId);
}

interface IDepartmentRepository
{
    Department Load(DepartmentId id);
}
```
Now, you get a compiler error when you accidentially use the employee's ID instead of the department's ID. Great! But there's more bugging me: both the employee's and the department's ID must not be empty. The records could reflect that constraint like this:
```csharp
record EmployeeId
{
    public EmployeeId(string value)
    {
        if(string.IsNullOrEmpty(value)) throw new ArgumentException("must not be empty");
        Value = value;
    }
    public string Value { get; }
}
record DepartmentId
{
    public DepartmentId(string value)
    {
        if(string.IsNullOrEmpty(value)) throw new ArgumentException("must not be empty");
        Value = value;
    }
    public string Value { get; }
}
```
Now you get an `ArgumentException` whenever you try to create an empty ID. But that's a lot of boilerplate code. There sure is a solution to that:
## The Source Generator
With `AD.BaseTypes` you can write the records like this:
```csharp
[NonEmptyString] partial record EmployeeId;
[NonEmptyString] partial record DepartmentId;
```
**That's it!** All the boilerpalte code is generated for you. Here's what the *generated* code for `EmployeeId` looks like:
```csharp
partial record EmployeeId
{
    public EmployeeId(string value)
    {
        new AD.BaseTypes.NonEmptyStringAttribute().Validate(value);

        this.Value = value;
    }

    public string Value { get; }
    public override string ToString() => Value.ToString();
    public static implicit operator string(EmployeeId x) => x.Value;
}
```
## But there's more!
Let's say you need to model a name that's from 1 to 20 characters long:
```csharp
[MinMaxLength(1, 20)] partial record Name;
```
**That's it!** Here's what the *generated* code looks like:
```csharp
partial record Name
{
    public Name(string value)
    {
        new AD.BaseTypes.MinMaxLengthAttribute(1, 20).Validate(value);

        this.Value = value;
    }

    public string Value { get; }
    public override string ToString() => Value.ToString();
    public static implicit operator string(Name x) => x.Value;
}
```
Or you need to model a serial number that must follow a certain pattern:
```csharp
[Regex(@"^\d\d-\w\w\w\w$")] partial record SerialNumber;
```
## Included Attributes
The included attributes are:
- `IntAttribute`
- `StringAttribute`
- `GuidAttribute`
- `DecimalAttribute`
- `NonEmptyGuidAttribute`
- `NonEmptyStringAttribute`
- `MinLengthAttribute`
- `MaxLengthAttribute`
- `MinMaxLengthAttribute`
- `RegexAttribute`
- `PositiveDecimalAttribute`
