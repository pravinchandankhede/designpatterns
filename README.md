[![Unit Tests](https://github.com/pravinchandankhede/designpatterns/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pravinchandankhede/designpatterns/actions/workflows/dotnet.yml)

## Table of Contents

- [Design Patterns](#design-patterns)
  - [Creational Patterns](#creational-patterns)
    - [Singleton](#singleton)
    - [Factory](#factory)
      - [Traditional Factory](#traditonal-factory)
      - [Factory using Dependency Injection](#factory-using-dependency-injection)
      - [Factory using Reflection](#factory-using-reflection)
    - [Builder](#builder)
    - [Prototype](#prototype)
  - [Structural Patterns](#structural-patterns)
  - [Behavioral Patterns](#behavioral-patterns)
    - [Strategy Pattern](#strategy-pattern)
- [Microservices Design Patterns](#microservices-design-patterns)
  - [API Gateway Pattern](#api-gateway-pattern)
- [Installation](#installation)
- [Contributing](#contributing)
- [License](#license)

# Design Patterns

This repo contains the implementation of various design patterns implementation using C#. It also demonstrates posibilities to implement same pattern in different ways

Broadly there are 3 types of design patterns prevelant in use. these are based on famous [GOF](https://en.wikipedia.org/wiki/Design_Patterns)

## Creational Patterns

These patterns deal with creation of object instances. These are of different types depending on what you intend to do with them.

### [Singleton](https://en.wikipedia.org/wiki/Singleton_pattern)

This pattern ensure that only one instance of a class is created at any point of time. The sample code demonstrate different way of implementing singleton pattern.
Refer the entire implementation [here](https://github.com/pravinchandankhede/designpatterns/tree/main/src/creational/Singleton).

1. [Basic](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/Basic.cs) This class implements a very basic version of singleton using private constructor and factory method to instanciate the instance.
2. [Eager](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/EagerSingleton.cs) This class implements the eager initialization pattern fro creating singleton objects.
3. [Lazy](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/LazySingleton.cs) This class shows how to utilize the [Lazy<T>](https://learn.microsoft.com/en-us/dotnet/api/system.lazy-1?view=net-9.0) feature of C# to implement singleton pattern.
4. [Thread Safe](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/ThreadSafeSingleton.cs) This class implements a thread safe version of singleton using the static constructor method.
5. [Thread Lock](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/ThreadLockSingleton.cs) This class shows how to create a singleton class by using a lock to synchronize the creation of instance between multiple threads.

### [Factory](https://en.wikipedia.org/wiki/Factory_method_pattern)

This pattern is used to create objects without exposing the instantiation logic to the client. The sample code demonstrate different way of implementing factory pattern.

Refer the entire implementation [here](https://github.com/pravinchandankhede/designpatterns/tree/main/src/creational/FactoryMethod).

#### Traditonal Factory

This demonstrates the class [AccountFactory](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/AccountFactory/AccountFactory.cs) which creates instance of [SavingAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/SavingAccount.cs) or [CurrentAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/CurrentAccount.cs) and returns a [IAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/IAccount.cs) object. This uses the classic [new()](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/new-operator) operator to create instances. The caller can work with both the instances in exactly same way, abstracting thier internal details and implementation details.

#### Factory using Dependency Injection

The class [AccountFactoryServiceProvider](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/AccountFactory/AccountFactoryServiceProvider.cs) demonstrates how to use [IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/system.iserviceprovider?view=net-9.0) to create instances of [SavingAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/SavingAccount.cs) or [CurrentAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/CurrentAccount.cs) and return [IAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/IAccount.cs) object. This uses the [IServiceCollection](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection?view=dotnet-plat-ext-5.0) to create instances. The caller can work with both the instances in exactly same way, abstracting thier internal details and implementation details.

#### Factory using Reflection

The class [AccountFactoryReflection](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/AccountFactory/AccountFactoryReflection.cs) demonstrates how to use [Activator](https://learn.microsoft.com/en-us/dotnet/api/system.activator?view=net-9.0) to create instances of [SavingAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/SavingAccount.cs) or [CurrentAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/CurrentAccount.cs) and return [IAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/IAccount.cs) object. The caller can work with both the instances in exactly same way, abstracting thier internal details and implementation details.

It also shows how to leverage a base class [AccountBase](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/AccountFactory/AccountBase.cs) to provide common fields and functionality across all derived class. This enables us to create a common abstraction among all derived classes and still make use of Factory to create instance thereby ensuring common pattern id followed by each client.

### [Builder](https://en.wikipedia.org/wiki/Builder_pattern)

The Builder pattern is used to construct complex objects step by step. It separates the construction of a complex object from its representation, allowing the same construction process to create different representations.

This repository includes a sample [Builder project](src/creational/Builder/) that demonstrates how to use the Builder pattern to create a restaurant order in a flexible and readable way.

#### Example Usage

```csharp
IOrderBuilder orderBuilder = new OrderBuilder();
Order order = orderBuilder
    .SetCustomerName("John Doe")
    .SetDeliveryAddress("123 Main St")
    .AddItem("Desert", 2)
    .AddItem("Icecream", 1)
    .Build();

Console.WriteLine(order);
```

#### Key Classes

- `Order`: Represents the final order object.
- `IOrderBuilder`: Interface for the builder.
- `OrderBuilder`: Concrete builder implementing the step-by-step construction of an order.

This approach makes it easy to add or modify order details without creating complex constructors or exposing internal object structure.

### [Prototype](https://en.wikipedia.org/wiki/Prototype_pattern)

The Prototype pattern is used to create new objects by copying an existing object, known as the prototype. This is useful when the cost of creating a new instance of an object is more expensive than copying an existing one. This pattern allows for dynamic object creation without needing to know the exact class of the object being created.

This repository includes a sample [Prototype project](src/creational/Prototype/) that demonstrates how to use the Prototype pattern to clone objects.

#### Example Usage

```csharp
LegalDocument original = new LegalDocument("NDA", "Content");
LegalDocument clientA = original.Clone();
LegalDocument clientB = original.Clone();
Console.WriteLine($"Original: {original.Name}, Clone: {clone.Name}");
```

## Structural Patterns

These patterns deals with the structure of code and classes. It highlights how different classes interact to form a larger system of classes.

## Behavioral Patterns

These patterns deal with the interaction and behavioral responsibilities of classes involved in the overall design.

### [Strategy Pattern](https://en.wikipedia.org/wiki/Strategy_pattern)

The Strategy Pattern enables selecting an algorithm or behavior at runtime. In the oil refinery domain, it allows switching between different refining processes (Hydrocracking, FCC, Coking) based on crude oil properties and market needs.

This repository includes a sample [Strategy Pattern project](src/behavioral/StrategyPattern/) that demonstrates how to implement the Strategy Pattern in an oil refinery context.

**Key Classes:**

- `OilRefinery`: Context class that manages the refining process and strategy selection.
- `IRefiningStrategy`: Interface for refining strategies.
- `HydrocrackingStrategy`, `FluidCatalyticCrackingStrategy`, `CokingStrategy`: Concrete strategies implementing different refining algorithms.
- `CrudeOil`, `RefinedProducts`: Models for input and output.

**Usage Example:**

```csharp
var strategies = new List<IRefiningStrategy> {
    new HydrocrackingStrategy(),
    new FluidCatalyticCrackingStrategy(),
    new CokingStrategy()
};
var refinery = new OilRefinery("Gulf Coast Refinery");
var brentCrude = new CrudeOil("Brent Crude", 10000m, 38.3m, 0.37m);
refinery.OptimizeStrategyFor(brentCrude, strategies);
var results = refinery.ProcessCrudeOil(brentCrude);
results.DisplayResults();
```

**Output Example:**

```text
=== Refining Results ===
Gasoline: 4500.00 barrels (45.0%)
Jet Fuel: 2000.00 barrels (20.0%)
Diesel: 1800.00 barrels (18.0%)
Heating Oil: 800.00 barrels (8.0%)
Heavy Fuel Oil: 500.00 barrels (5.0%)
Petrochemical Feedstock: 400.00 barrels (4.0%)
Total Yield: 10000.00 barrels
Processing Cost: $155,000.00
```

**Benefits:**

- Flexible strategy selection
- Easy to extend with new processes
- Clear separation of concerns

## Microservices Design Patterns

### [API Gateway Pattern](https://en.wikipedia.org/wiki/API_gateway)

This project targets `.NET 8` and implements a microservices architecture using the **API Gateway Pattern**. The solution includes core services (`Order` and `Products`) exposed through an API Gateway (`Shopping Gateway`). The API Gateway is consumed by the `APIGatewayClient` project, which acts as the client application.

It provides two implementations of the API Gateway:

1. **Shopping Gateway**: This shows the implementation using the code approach. In this approach, the API Gateway is implemented as an explicit controller that routes requests to the `Order` and `Products` services.
2. **Ocelot Gateway**: This shows the implementation using the Ocelot library. In this approach, the API Gateway is implemented using Ocelot, which provides a more declarative way to configure routing and service discovery.

[Implementation](https://github.com/pravinchandankhede/designpatterns/tree/main/src/microservices/APIGateway)

## Installation

You can fork the repository at your local machine and run the code using Visual Studio or any other IDE of your choice.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the [MIT License](https://github.com/pravinchandankhede/designpatterns/blob/main/LICENSE). You are free to use, modify, and distribute this project in accordance with the terms of the license.