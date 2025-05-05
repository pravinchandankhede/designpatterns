namespace ShoppingGateway.Models;

using System;
using System.Collections.Generic;

public class Order
{
	public Order()
	{
		Items = new List<OrderItem>();
	}

	public int Id { get; set; }
	public string CustomerName { get; set; }
	public DateTime OrderDate { get; set; }
	public List<OrderItem> Items { get; set; }
	public decimal TotalAmount { get; set; }
}

public class OrderItem
{
	public OrderItem()
	{
		
	}
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
}

public class Product
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public string Category { get; set; }
}
