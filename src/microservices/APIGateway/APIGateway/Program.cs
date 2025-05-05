namespace APIGateway;

using APIGateway.Client;

class Program
{
	static async Task Main()
	{
		var client = new ShoppingCartClient("http://localhost:5003");

		// Fetch products
		var products = await client.GetProductsAsync();
		Console.WriteLine("Products: " + products);

		// Fetch orders
		var orders = await client.GetOrdersAsync();
		Console.WriteLine("Orders: " + orders);

		// Add a new product
		//var newProduct = new { Name = "Sample Product", Category = "Electronics", Price = 99.99 };
		//var addProductResponse = await client.AddProductAsync(newProduct);
		//Console.WriteLine("Add Product Response: " + addProductResponse);

		// Add a new order
		//var newOrder = new { CustomerName = "John Doe", Items = new[] { new { ProductId = 1, Quantity = 2, Price = 99.99 } }, TotalAmount = 199.98 };
		//var addOrderResponse = await client.AddOrderAsync(newOrder);
		//Console.WriteLine("Add Order Response: " + addOrderResponse);

		// Fetch orders with products
		var ordersWithProducts = await client.GetOrdersWithProductsAsync();
		Console.WriteLine("Orders with Products: " + ordersWithProducts);
	}
}

