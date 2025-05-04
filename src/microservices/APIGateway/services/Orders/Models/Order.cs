namespace Orders.Models;

public class Order
{
	public int Id { get; set; }
	public string CustomerName { get; set; }
	public DateTime OrderDate { get; set; }
	public List<OrderItem> Items { get; set; }
	public decimal TotalAmount { get; set; }
}

public class OrderItem
{
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
}
