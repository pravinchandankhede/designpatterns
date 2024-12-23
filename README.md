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
4. [Thread Safe](https://github.com/pravinchandankhede/designpatterns/blob/main/src/creational/Singleton/ThreadSafeSingleton.cs)

## Structural Patterns
These patterns deals with the structure of code and classes. It highlights how different classes interact to form a larger system of classes.

## Behavioral Patterns
These patterns deals with the interaction and behavioral responsibilities of classes involved in the overall design.

## Installation
You can fork the repository at your local machine and run the code using Visual Studio or any other IDE of your choice.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.