# What is\[Project Name].http
### Purpose and Functionality
- Enables direct testing of API endpoints within Visual Studio
- Provides immediate feedback through response display
- Supports various HTTP methods (GET, POST, PUT, DELETE, etc.)
- Allows definition of headers, query parameters, and request bodies
- Integrates with Visual Studio's debugging tools

This integrated testing feature significantly simplifies API development by allowing developers to test endpoints directly within their IDE, reducing the need for external tools while maintaining a clean and organized approach to API testing.

# OpenAPI 
The `AddOpenApi()` method registers services needed for OpenAPI document generation in ASP.NET Core applications [learn.microsoft.com](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/overview?view=aspnetcore-9.0)
When called in the service configuration phase, it enables automatic API documentation and Swagger UI integration.
The generated documentation will be available at `/openapi/v1.json` during development. The Swagger UI is automatically enabled in development environments.

# What is secrets.json in the local environment?

# How to add Caching to avoid unnecesary requests:
To add [[Caching]] to the HttpClient in the FakeRestAPIHttpClient class, you can use the IMemoryCache service provided by ASP.NET Core. This will allow you to cache the results of the HTTP requests and avoid making unnecessary calls to the external API.
Here are the steps to add caching:
1.	Register the IMemoryCache service in the Program.cs file.
2.	Inject the IMemoryCache service into the FakeRestAPIHttpClient class.
3.	Implement caching logic in the GetBoooks method.
Step 1: Register the IMemoryCache service
In your Program.cs file, add the AddMemoryCache service:
