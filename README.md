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
    public Guid Id { get; }
    public Guid DepartmentId { get; }
    //more properties
    
    public Department GetDepartment() =>
        departmentRepository.Load(DepartmentId);
}

interface IDepartmentRepository
{
    Department Load(Guid id);
}
```
Both the employee's ID and the associated department's ID are modeled as GUIDs ... although they are logically separate and must never be mixed. What if you accidentally use the wrong ID in `GetDepartment`?
```csharp
public Department GetDepartment() =>
    departmentRepository.Load(Id);
```
Your code still compiles. Hopefully, you've got some tests to catch that error. But why not utilize the type system to prevent that bug in the first place? C# 9 records to the rescue:
```csharp
record EmployeeId(Guid Value);
record DepartmentId(Guid Value);

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
Now, you get a compiler error when you accidentially use the employee's ID instead of the department's ID. Great!
