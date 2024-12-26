# Design Patterns

This repo contains the implementation of various design patterns implementation using C#. It also demonstrates posibilities to implement same pattern in different ways

Broadly there are 3 types of design patterns prevelant in use. these are based on famous [GOF](https://en.wikipedia.org/wiki/Design_Patterns)

## Creational Patterns
These patterns deal with creation of object instances. These are of different types depending on what you intend to do with them. 

### [Singleton](https://en.wikipedia.org/wiki/Singleton_pattern)
This pattern ensure that only one instance of a class is created at any point of time. The sample code demonstrate different way of implementing singleton pattern.
Refer the entire implementation [here](https://github.com/pravinchandankhede/designpatterns/tree/main/src/creational/Singleton)

1. [Basic](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/Basic.cs) This class implements a very basic version of singleton using private constructor and factory method to instanciate the instance.
2. [Eager](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/EagerSingleton.cs) This class implements the eager initialization pattern fro creating singleton objects.
3. [Lazy](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/LazySingleton.cs) This class shows how to utilize the [Lazy<T>](https://learn.microsoft.com/en-us/dotnet/api/system.lazy-1?view=net-9.0) feature of C# to implement  singleton pattern.
4. [Thread Safe](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/ThreadSafeSingleton.cs) This class implements a thread safe version of singleton using the static constructor method.
5. [Thread Lock](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/ThreadLockSingleton.cs) This class shows how to create a singleton class by using a lock to synchronize the creation of instance between multiple threads.

### [Factory](https://en.wikipedia.org/wiki/Factory_method_pattern)
This pattern is used to create objects without exposing the instantiation logic to the client. The sample code demonstrate different way of implementing factory pattern.
Refer the entire implementation [here](https://github.com/pravinchandankhede/designpatterns/tree/main/src/creational/FactoryMethod)

This demonstrates the class [AccountFactory](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/AccountFactory/AccountFactory.cs) which creates instance of [SavingAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/SavingAccount.cs) or [CurrentAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/CurrentAccount.cs) and returns a [IAccount](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/FactoryMethod/Account/IAccount.cs) object. The caller can work with both the instances in exactly same way abstracting thier internal details and implementation details.

## Structural Patterns
These patterns deals with the structure of code and classes. It highlights how different classes interact to form a larger system of classes.

## Behavioral Patterns
These patterns deals with the interaction and behavioral responsibilities of classes involved in the overall design.

## Installation
You can fork the repository at your local machine and run the code using Visual Studio or any other IDE of your choice.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.