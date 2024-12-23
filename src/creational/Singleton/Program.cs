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
    }
}
