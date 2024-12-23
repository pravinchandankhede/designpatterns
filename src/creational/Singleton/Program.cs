namespace Singleton;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("Sample demonstrating creational patterns!");

        var basicInstance = Basic.GetInstance();
        Console.WriteLine(basicInstance.GetMessage());

        basicInstance = Basic.GetInstance();
        Console.WriteLine(basicInstance.GetMessage());

        var eagerInstance = EagerSingleton.Instance;
        Console.WriteLine(eagerInstance.GetMessage());

        var lazyInstance = LazySingleton.Instance;
        Console.WriteLine(lazyInstance.GetMessage());

        var threadSafeInstance = ThreadSafeSingleton.Instance;
        Console.WriteLine(threadSafeInstance.GetMessage());

        var lazyOptimized = LazyOptimizedSingleton.Instance;
        Console.WriteLine(lazyOptimized.GetMessage());

    }
}
