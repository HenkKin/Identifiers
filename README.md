Identifiers
===========
[![NuGet](https://img.shields.io/nuget/dt/Identifiers.svg)](https://www.nuget.org/packages/Identifiers) 
[![NuGet](https://img.shields.io/nuget/vpre/Identifiers.svg)](https://www.nuget.org/packages/Identifiers)

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

### EntityFrameworkCore

If you're using EntityFrameworkCore and you want to use this Identifier type in your entities, then you can use [Identifiers.EntityFrameworkCore](https://github.com/HenkKin/Identifiers.EntityFrameworkCore/) package which includes a `DbContextOptionsBuilder.UseIdentifiers<[InternalClrType:short|int|long|Guid]>()` extension method, allowing you to register all needed IValueConverterSelectors and IMigrationsAnnotationProviders. 
It also includes a `PropertyBuilder<Identifier>.IdentifierValueGeneratedOnAdd()` extension method, allowing you to register all needed configuration to use SqlServerValueGenerationStrategy.IdentityColumn. 
