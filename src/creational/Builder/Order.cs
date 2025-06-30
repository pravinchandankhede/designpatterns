namespace Builder;

public class Order
{
    public List<(String ItemName, int Quantity)> Items { get; } = new List<(String, int)>();
    public String CustomerName { get; set; }
    public String DeliveryAddress { get; set; }

    public override string ToString()
    {
        return $"Order for {CustomerName} at {DeliveryAddress}: " +
               string.Join(", ", Items.Select(i => $"{i.Quantity}x {i.ItemName}"));
    }
}
