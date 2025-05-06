 
# Project Documentation  

## Overview  
This project targets `.NET 8` and implements a microservices architecture using the **API Gateway Pattern**. The solution includes core services (`Order` and `Products`) exposed through an API Gateway (`Shopping Gateway`). The API Gateway is consumed by the `APIGatewayClient` project, which acts as the client application.  

## Architecture  

### API Gateway Pattern  
The **API Gateway Pattern** is used to provide a single entry point for multiple microservices. It simplifies client interactions by aggregating and routing requests to the appropriate services.  

### Components  
1. **Order Service**  
   - Handles operations related to orders, such as creating, retrieving, and managing orders.  
2. **Products Service**  
   - Manages product-related operations, such as retrieving product details and inventory.  
3. **Shopping Gateway**  
   - Acts as the API Gateway, routing client requests to the appropriate services (`Order` and `Products`).  
4. **APIGatewayClient**  
   - A client application that interacts with the `Shopping Gateway` to consume the services.  

## Features  
- **Order Service**:  
  - Create, retrieve, and manage orders.  
- **Products Service**:  
  - Retrieve product details and inventory.  
- **API Gateway**:  
  - Centralized routing and aggregation of service requests.  
- **Client Application**:  
  - Simplified interaction with the microservices through the API Gateway.  

## Prerequisites  
- .NET 8 SDK installed  
- Visual Studio IDE  

## Getting Started  

### Clone the Repository  

 

```bash
git clone https://github.com/pravinchandankhede/designpatterns
cd designpatterns
```



### Build the Project  
1. Open the solution in Visual Studio.  
2. Restore NuGet packages.  
3. Build the solution.  

### Run the Application  
1. Set the `Shopping Gateway` project as the startup project.  
2. Press `F5` to run the application.  

## API Gateway Example  

### Sample API Gateway Configuration  
The `Shopping Gateway` routes requests to the `Order` and `Products` services. Below is an example of the configuration:  

 ```json
{
	"Routes": [
		{
			"Path": "/api/orders",
			"Service": "OrderService",
			"Upstream": "http://localhost:5001"
		},
		{
			"Path": "/api/products",
			"Service": "ProductsService",
			"Upstream": "http://localhost:5002"
		}
	]
}
```


### Sample API Endpoints  

#### Order Service  
- **GET** `/api/orders/{id}`  
  Retrieves order details by ID.  

  **Example Request:**  
```curl
GET http://localhost:5000/api/orders/123
```
  **Example Response:**  
```json
{
	"id": 123,
	"customer": "John Doe",
	"items": [
		{
			"productId": 1,
			"quantity": 2
		}
	],
	"total": 100.0
}
```


#### Products Service  
- **GET** `/api/products/{id}`  
  Retrieves product details by ID.  

  **Example Request:**  
 ```curl
 GET http://localhost:5000/api/products/456
 ```
  **Example Response:**
 ```json
{
	"id": 456,
	"name": "Laptop",
	"price": 1200.0,
	"stock": 10
}
```
## Testing  
- The project includes integrated unit tests.  
- To run tests:  
  1. Open the Test Explorer in Visual Studio.  
  2. Run all tests or specific tests as needed.  

## Contributing  
1. Fork the repository.  
2. Create a new branch for your feature or bug fix.  
3. Commit your changes and push the branch.  
4. Submit a pull request.  

## License  
MIT License. See the [LICENSE](https://github.com/pravinchandankhede/designpatterns/blob/main/LICENSE) file for details.

