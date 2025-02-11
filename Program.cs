using WebApi4Boooks.Services;
using WebApi4Boooks.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IFakeRestAPIHttpClient, FakeRestAPIHttpClient>(client =>
{
    var baseUrl = builder.Configuration.GetValue<string>("BaseApiUrl")
        ?? "https://fakerestapi.azurewebsites.net/api/v1/";
    client.BaseAddress = new Uri(baseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
