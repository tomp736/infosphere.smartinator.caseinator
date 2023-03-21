
## Project Init

### Create Base Projects

``` bash
cd src
dotnet new classlib -n caseinator.core
dotnet new mstest -n caseinator.core.tests
dotnet new classlib -n caseinator.data
dotnet new mstest -n caseinator.data.tests
dotnet new webapi -n caseinator.webapi
dotnet new mstest -n caseinator.webapi.tests
```

### Add Project References

``` bash
cd caseinator.data
dotnet add reference ../caseinator.core
```

``` bash
cd caseinator.data.tests
dotnet add reference ../caseinator.core
dotnet add reference ../caseinator.data
```

``` bash
cd caseinator.webapi
dotnet add reference ../caseinator.data
dotnet add reference ../caseinator.core
```

### Add Test Projects

``` bash
cd src
dotnet new mstest -n caseinator.core.tests
dotnet new mstest -n caseinator.data.tests
dotnet new mstest -n caseinator.webapi.tests
```

### Add Project References

``` bash
cd caseinator.core.tests
dotnet add reference ../caseinator.core
```

``` bash
cd caseinator.data.tests
dotnet add reference ../caseinator.core
dotnet add reference ../caseinator.data
```

``` bash
cd caseinator.webapi.tests
dotnet add reference ../caseinator.core
dotnet add reference ../caseinator.data
dotnet add reference ../caseinator.webapi
```

## Docker Files