namespace APIGateway.Client;

using System.Text;
using System.Text.Json;

public class ShoppingCartClient
{
	private readonly HttpClient _httpClient;
	private readonly string _baseUrl;

	public ShoppingCartClient(string baseUrl)
	{
		_httpClient = new HttpClient();
		_baseUrl = baseUrl.TrimEnd('/');
	}

	public async Task<string> GetProductsAsync()
	{
		var response = await _httpClient.GetAsync($"{_baseUrl}/api/Gateway/products");
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<string> GetOrdersAsync()
	{
		var response = await _httpClient.GetAsync($"{_baseUrl}/api/Gateway/orders");
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<string> AddProductAsync(object newProduct)
	{
		var content = new StringContent(JsonSerializer.Serialize(newProduct), Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync($"{_baseUrl}/api/Gateway/products", content);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<string> AddOrderAsync(object newOrder)
	{
		var content = new StringContent(JsonSerializer.Serialize(newOrder), Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync($"{_baseUrl}/api/Gateway/orders", content);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}

	public async Task<string> GetOrdersWithProductsAsync()
	{
		var response = await _httpClient.GetAsync($"{_baseUrl}/api/Gateway/orders-with-products");
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
	}
}

