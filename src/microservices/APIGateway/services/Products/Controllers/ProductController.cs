namespace Products.Controllers;

using Microsoft.AspNetCore.Mvc;
using Products.Models;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private const string DataFilePath = "Data/products.json";

	// GET: api/Product
	[HttpGet]
	public IActionResult GetProducts()
	{
		if (!System.IO.File.Exists(DataFilePath))
		{
			return NotFound("Data file not found.");
		}

		var jsonData = System.IO.File.ReadAllText(DataFilePath);
		var products = JsonSerializer.Deserialize<List<Product>>(jsonData);

		return Ok(products);
	}

	// POST: api/Product
	[HttpPost]
	public IActionResult AddProduct([FromBody] Product newProduct)
	{
		if (newProduct == null)
		{
			return BadRequest("Invalid product data.");
		}

		List<Product> products;

		if (System.IO.File.Exists(DataFilePath))
		{
			var jsonData = System.IO.File.ReadAllText(DataFilePath);
			products = JsonSerializer.Deserialize<List<Product>>(jsonData) ?? new List<Product>();
		}
		else
		{
			products = new List<Product>();
		}

		products.Add(newProduct);

		var updatedJsonData = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
		System.IO.File.WriteAllText(DataFilePath, updatedJsonData);

		return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
	}
}
