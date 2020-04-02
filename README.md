Identifiers
===========
[![Build Status](https://ci.appveyor.com/api/projects/status/github/HenkKin/Identifiers?branch=master&svg=true)](https://ci.appveyor.com/project/HenkKin/Identifiers) 
[![NuGet](https://img.shields.io/nuget/dt/Identifiers.svg)](https://www.nuget.org/packages/Identifiers) 
[![NuGet](https://img.shields.io/nuget/vpre/Identifiers.svg)](https://www.nuget.org/packages/Identifiers)
[![BCH compliance](https://bettercodehub.com/edge/badge/HenkKin/Identifiers?branch=master)](https://bettercodehub.com/)

### Summary

The Identifiers library solves the problem of using int or guid as a Id. An Id should be represented by a special type. This library gives you the Identifier type.

Before creating this type I was reading some great articles which helped me a lot.

https://andrewlock.net/using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-1/
<br/>https://www.martinfowler.com/bliki/ValueObject.html/
<br/>https://lostechies.com/jimmybogard/2007/12/03/dealing-with-primitive-obsession/

This library is Cross-platform, supporting `netstandard2.1`.

### Installing Identifiers

You should install [Identifiers with NuGet](https://www.nuget.org/packages/Identifiers):

    Install-Package Identifiers

Or via the .NET Core command line interface:

    dotnet add package Identifiers

Either commands, from Package Manager Console or .NET Core CLI, will download and install Identifiers. Identifiers has no dependencies. 

### Usage
Install via NuGet first:
`Install-Package Identifiers`

To use it:

```csharp
using Identifiers;

public class YourEntity
{
    public Identifier Id { get; set; }
    ...
```

### ASP.NET Core

If you're using ASP.NET Core and you want to use this Identifier type in your models, then you can use [Identifiers.AspNetCore](https://github.com/HenkKin/Identifiers.AspNetCore/) package which includes a `IServiceCollection.AddIdentifiers<[InternalClrType:short|int|long|Guid]>()` extension method, allowing you to register all needed RouteConstraints, ModelBinders and JsonConverters.

### EntityFrameworkCore.SqlServer

If you're using EntityFrameworkCore.SqlServer and you want to use this Identifier type in your entities, then you can use [Identifiers.EntityFrameworkCore.SqlServer](https://github.com/HenkKin/Identifiers.EntityFrameworkCore.SqlServer/) package which includes a `DbContextOptionsBuilder.UseIdentifiers<[InternalClrType:short|int|long|Guid]>()` extension method, allowing you to register all needed IValueConverterSelectors and IMigrationsAnnotationProviders. 
It also includes a `PropertyBuilder<Identifier>.IdentifierValueGeneratedOnAdd()` extension method, allowing you to register all needed configuration to use SqlServerValueGenerationStrategy.IdentityColumn. 

### Newtonsoft.Json

If you're using Newtonsoft.Json and you are not using [Identifiers.AspNetCore](https://github.com/HenkKin/Identifiers.AspNetCore/) then the [Identifiers.Extensions.Newtonsoft.Json](https://github.com/HenkKin/Identifiers.Extensions.Newtonsoft.Json/) package gives you JsonConverters to instruct Newtonsoft.Json how to serialize and deserialize the Identifier type.

### Debugging

If you want to debug the source code, thats possible. [SourceLink](https://github.com/dotnet/sourcelink) is enabled. To use it, you  have to change Visual Studio Debugging options:

Debug => Options => Debugging => General

Set the following settings:

[&nbsp;&nbsp;] Enable Just My Code

[X] Enable source server support

[X] Enable source link support


Now you can use 'step into' (F11).
