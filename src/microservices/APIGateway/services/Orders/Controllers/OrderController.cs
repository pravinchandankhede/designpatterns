namespace Orders.Controllers;

using Microsoft.AspNetCore.Mvc;
using Orders.Models;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
	private const string DataFilePath = "Data/orders.json";

	// GET: api/Order
	[HttpGet]
	public IActionResult GetOrders()
	{
		if (!System.IO.File.Exists(DataFilePath))
		{
			return NotFound("Data file not found.");
		}

		var jsonData = System.IO.File.ReadAllText(DataFilePath);
		var orders = JsonSerializer.Deserialize<List<Order>>(jsonData);

		return Ok(orders);
	}

	// POST: api/Order
	[HttpPost]
	public IActionResult AddOrder([FromBody] Order newOrder)
	{
		if (newOrder == null)
		{
			return BadRequest("Invalid order data.");
		}

		List<Order> orders;

		if (System.IO.File.Exists(DataFilePath))
		{
			var jsonData = System.IO.File.ReadAllText(DataFilePath);
			orders = JsonSerializer.Deserialize<List<Order>>(jsonData) ?? new List<Order>();
		}
		else
		{
			orders = new List<Order>();
		}

		orders.Add(newOrder);

		var updatedJsonData = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
		System.IO.File.WriteAllText(DataFilePath, updatedJsonData);

		return CreatedAtAction(nameof(GetOrders), new { id = newOrder.Id }, newOrder);
	}
}