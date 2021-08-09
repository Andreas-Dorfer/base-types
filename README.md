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
```
