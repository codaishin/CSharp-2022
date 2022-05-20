# How to add unit tests

Example is shown with `NUnit` test library

## Simple setup for small projects

### New project

```console
dotnet new nunit
```

If NUnit packages are not yet installed got to [Add NUnit packages to exisiting project](#add-nunit-packages-to-exisiting-project)

### Add NUnit packages to exisiting project

to enable general test running
```console
$ dotnet add package Microsoft.NET.Test.Sdk
```

the specific test library we want to use
```console
$ dotnet add package NUnit
```

adapter to make NUnit work with `dotnet test` discovery
```console
$ dotnet add package Nunit3TestAdapter
```

### Prevent NUnit from generating `Main()`

set `GenerateProgramFile` in the `.csproj` file to false to prevent the test
library from generating its own `Main()` method
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    ...
    <GenerateProgramFile>false</GenerateProgramFile>
  </PropertyGroup>

  ...

</Project>
```

## Write tests

see `Program.Test.cs` for simple test examples.
