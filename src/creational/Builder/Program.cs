namespace Builder;

public class Program
{
    public static void Main(string[] args)
    {
        IOrderBuilder orderBuilder = new OrderBuilder();
        Order order = orderBuilder
            .SetCustomerName("John Doe")
            .SetDeliveryAddress("123 Main St")
            .AddItem("Desert", 2)
            .AddItem("Icecream", 1)
            .Build();

        Console.WriteLine(order);
    }
}