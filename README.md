[![NuGet Package](https://img.shields.io/nuget/v/AndreasDorfer.BaseTypes.svg)](https://www.nuget.org/packages/AndreasDorfer.BaseTypes/)
# AD.BaseTypes
Fight primitive obsession and create expressive domain models with source generators.
## NuGet Package
    PM> Install-Package AndreasDorfer.BaseTypes -Version 0.1.5
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
Your code still compiles. Hopefully, you've got some tests to catch that bug. But why not utilize the type system to prevent that bug in the first place? C# 9 records to the rescue:
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
Now, you get a compiler error when you accidentally use the employee's ID instead of the department's ID. Great! But there's more bugging me: both the employee's and the department's ID must not be empty. The records could reflect that constraint like this:
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
You get an `ArgumentException` whenever you try to create an empty ID. But that's a lot of boilerplate code. There sure is a solution to that:
## The Source Generator
With `AD.BaseTypes` you can write the records like this:
```csharp
[NonEmptyString] partial record EmployeeId;
[NonEmptyString] partial record DepartmentId;
```
**That's it!** All the boilerplate code is generated for you. Here's what the *generated* code for `EmployeeId` looks like:
```csharp
partial record EmployeeId : System.IComparable<EmployeeId>, System.IComparable, AD.BaseTypes.IValue<string>
{
    public EmployeeId(string value)
    {
        new AD.BaseTypes.NonEmptyStringAttribute().Validate(value);

        this.Value = value;
    }

    public string Value { get; }
    public override string ToString() => Value.ToString();
    public int CompareTo(object obj) => CompareTo(obj as EmployeeId);
    public int CompareTo(EmployeeId other) =>
        other is null ? 1 : System.Collections.Generic.Comparer<string>.Default.Compare(Value, other.Value);
    public static implicit operator string(EmployeeId item) => item.Value;
    public static EmployeeId Create(string value) => new(value);
}
```
## But there's more!
Let's say you need to model a name that's from 1 to 20 characters long:
```csharp
[MinMaxLength(MinLength, MaxLength)]
partial record Name
{
    public const int MinLength = 1, MaxLength = 20;
}
```
**That's it!** Here's what the *generated* code looks like:
```csharp
partial record Name : System.IComparable<Name>, System.IComparable, AD.BaseTypes.IValue<string>
{
    public Name(string value)
    {
        new AD.BaseTypes.MinMaxLengthAttribute(MinLength, MaxLength).Validate(value);

        this.Value = value;
    }

    public string Value { get; }
    public override string ToString() => Value.ToString();
    public int CompareTo(object obj) => CompareTo(obj as Name);
    public int CompareTo(Name other) =>
        other is null ? 1 : System.Collections.Generic.Comparer<string>.Default.Compare(Value, other.Value);
    public static implicit operator string(Name item) => item.Value;
    public static Name Create(string value) => new(value);
}
```
Or you need to model a serial number that must follow a certain pattern:
```csharp
[Regex(Pattern)]
partial record SerialNumber
{
    public const string Pattern = @"^\d\d-\w\w\w\w$";
}
```
## Included Attributes
The included attributes are:
- `IntAttribute`
- `DoubleAttribute`
- `DecimalAttribute`
- `StringAttribute`
- `GuidAttribute`
- `DateTimeAttribute`
- `IntMinAttribute`
- `IntMaxAttribute`
- `IntRangeAttribute`
- `PositiveDecimalAttribute`
- `NonEmptyStringAttribute`
- `MinLengthAttribute`
- `MaxLengthAttribute`
- `MinMaxLengthAttribute`
- `RegexAttribute`
- `NonEmptyGuidAttribute`
## Custom Attributes
You can create custom attributes. Let's say you need a `DateTime` only for weekends:
```csharp
[AttributeUsage(AttributeTargets.Class)]
class WeekendAttribute : Attribute, IValidatedBaseType<DateTime>
{
    public void Validate(DateTime value)
    {
        if (value.DayOfWeek != DayOfWeek.Saturday && value.DayOfWeek != DayOfWeek.Sunday)
            throw new ArgumentOutOfRangeException(nameof(value), value, "must be a Saturday or Sunday");
    }
}

[Weekend] partial record SomeWeekend;
```
## Multiple Attributes
You can apply multiple attributes:
```csharp
[AttributeUsage(AttributeTargets.Class)]
class The90sAttribute : Attribute, IValidatedBaseType<DateTime>
{
    public void Validate(DateTime value)
    {
        if (value.Year < 1990 || value.Year > 1999)
            throw new ArgumentOutOfRangeException(nameof(value), value, "must be in the 90s");
    }
}

[The90s, Weekend] partial record SomeWeekendInThe90s;
```
---
[![NuGet Package](https://img.shields.io/nuget/v/AndreasDorfer.BaseTypes.Arbitraries.svg)](https://www.nuget.org/packages/AndreasDorfer.BaseTypes.Arbitraries/)
## Arbitraries
Are you using [FsCheck](https://fscheck.github.io/FsCheck/)? Check out `AD.BaseTypes.Arbitraries`.
### NuGet Package
    PM> Install-Package AndreasDorfer.BaseTypes.Arbitraries -Version 0.1.2
### Example
```csharp
[IntRange(Min, Max)]
public partial record ZeroToTen
{
    public const int Min = 0, Max = 10;
}

const int MinProduct = ZeroToTen.Min * ZeroToTen.Min;
const int MaxProduct = ZeroToTen.Max * ZeroToTen.Max;

var arb = IntRangeArbitrary.Create(ZeroToTen.Min, ZeroToTen.Max, ZeroToTen.Create);

Prop.ForAll(arb, arb, (a, b) =>
{
    var product = a * b;
    return product >= MinProduct && product <= MaxProduct;
});
```
---
## Note
`AD.BaseTypes` is in an early stage.
