namespace Builder;

public interface IOrderBuilder
{
    IOrderBuilder AddItem(string itemName, int quantity);
    IOrderBuilder SetCustomerName(string customerName);
    IOrderBuilder SetDeliveryAddress(string address);
    Order Build();
}
