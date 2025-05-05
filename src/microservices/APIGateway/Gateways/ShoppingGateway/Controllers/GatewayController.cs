namespace ShoppingGateway.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShoppingGateway.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class GatewayController : ControllerBase
{
	private String _productServiceUrl = "http://localhost:5001/api/";
	private String _orderServiceUrl = "http://localhost:5000/api/";

	private readonly HttpClient _httpClient;

	public GatewayController(IHttpClientFactory httpClientFactory)
	{
		_httpClient = httpClientFactory.CreateClient();
	}

	// GET: api/Gateway/products
	[HttpGet("products")]
	public async Task<IActionResult> GetProducts()
	{
		var productServiceUrl = _productServiceUrl + "Product";
		var response = await _httpClient.GetAsync(productServiceUrl);

		if (!response.IsSuccessStatusCode)
		{
			return StatusCode((int)response.StatusCode, "Failed to fetch products.");
		}

		var products = await response.Content.ReadAsStringAsync();
		return Content(products, "application/json");
	}

	// GET: api/Gateway/orders
	[HttpGet("orders")]
	public async Task<IActionResult> GetOrders()
	{
		var orderServiceUrl = _orderServiceUrl + "Order";
		var response = await _httpClient.GetAsync(orderServiceUrl);

		if (!response.IsSuccessStatusCode)
		{
			return StatusCode((int)response.StatusCode, "Failed to fetch orders.");
		}

		var orders = await response.Content.ReadAsStringAsync();
		return Content(orders, "application/json");
	}

	// POST: api/Gateway/products
	[HttpPost("products")]
	public async Task<IActionResult> AddProduct([FromBody] object newProduct)
	{
		var productServiceUrl = _productServiceUrl + "Product";
		var content = new StringContent(JsonSerializer.Serialize(newProduct), System.Text.Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync(productServiceUrl, content);

		if (!response.IsSuccessStatusCode)
		{
			return StatusCode((int)response.StatusCode, "Failed to add product.");
		}

		var result = await response.Content.ReadAsStringAsync();
		return Content(result, "application/json");
	}

	// POST: api/Gateway/orders
	[HttpPost("orders")]
	public async Task<IActionResult> AddOrder([FromBody] object newOrder)
	{
		var orderServiceUrl = _orderServiceUrl + "Order";

		var content = new StringContent(JsonSerializer.Serialize(newOrder), System.Text.Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync(orderServiceUrl, content);

		if (!response.IsSuccessStatusCode)
		{
			return StatusCode((int)response.StatusCode, "Failed to add order.");
		}

		var result = await response.Content.ReadAsStringAsync();
		return Content(result, "application/json");
	}

	[HttpGet("orders-with-products")]
	public async Task<IActionResult> GetOrdersWithProducts()
	{
		var orderServiceUrl = _orderServiceUrl + "Order";

		//var orderServiceUrl = "http://localhost:5002/api/Order"; // Replace with actual Order service URL

		var productServiceUrl = _productServiceUrl + "Product";

		//var productServiceUrl = "http://localhost:5001/api/Product"; // Replace with actual Product service URL

		var options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};

		// Fetch orders
		var orderResponse = await _httpClient.GetAsync(orderServiceUrl);
		if (!orderResponse.IsSuccessStatusCode)
		{
			return StatusCode((int)orderResponse.StatusCode, "Failed to fetch orders.");
		}
		var orderData = await orderResponse.Content.ReadAsStringAsync();
		//var orders = JsonSerializer.Deserialize<List<Order>>(orderData);
		var orders = JsonSerializer.Deserialize<List<Order>>(orderData, options);

		// Fetch products
		var productResponse = await _httpClient.GetAsync(productServiceUrl);
		if (!productResponse.IsSuccessStatusCode)
		{
			return StatusCode((int)productResponse.StatusCode, "Failed to fetch products.");
		}
		var productData = await productResponse.Content.ReadAsStringAsync();
		var products = JsonSerializer.Deserialize<List<Product>>(productData, options);

		// Aggregate orders with product details
		var ordersWithProducts = orders.Select(order =>
		{
			var enrichedItems = order.Items.Select(item =>
			{
				var product = products.FirstOrDefault(p => p.Id == item.ProductId);
				return new
				{
					item.ProductId,
					ProductName = product?.Name,
					item.Quantity,
					item.Price,
					ProductCategory = product?.Category
				};
			}).ToList();

			return new
			{
				order.Id,
				order.CustomerName,
				order.OrderDate,
				Items = enrichedItems,
				order.TotalAmount
			};
		});

		return Ok(ordersWithProducts);
	}

}
