namespace Builder;

public class OrderBuilder : IOrderBuilder
{
    private readonly Order _order = new Order();
    public IOrderBuilder AddItem(string itemName, int quantity)
    {
        if (string.IsNullOrWhiteSpace(itemName))
        {
            throw new ArgumentException("Item name cannot be null or empty.", nameof(itemName));
        }
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        }

        _order.Items.Add((itemName, quantity));

        return this;
    }

    public Order Build()
    {
        if (string.IsNullOrWhiteSpace(_order.CustomerName))
        {
            throw new InvalidOperationException("Customer name must be set before building the order.");
        }
        if (string.IsNullOrWhiteSpace(_order.DeliveryAddress))
        {
            throw new InvalidOperationException("Delivery address must be set before building the order.");
        }

        return _order;
    }

    public IOrderBuilder SetCustomerName(string customerName)
    {
        if (string.IsNullOrWhiteSpace(customerName))
        {
            throw new ArgumentException("Customer name cannot be null or empty.", nameof(customerName));
        }
        _order.CustomerName = customerName;

        return this;
    }

    public IOrderBuilder SetDeliveryAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            throw new ArgumentException("Delivery address cannot be null or empty.", nameof(address));
        }
        _order.DeliveryAddress = address;

        return this;
    }
}
