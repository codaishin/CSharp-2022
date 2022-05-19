# Unit Tests
- what are unit tests
- how can we use unit tests with c# and vscode
- build small example program with unit tests
  - make all functions `public static` for unit tests to work


# How it is done

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
