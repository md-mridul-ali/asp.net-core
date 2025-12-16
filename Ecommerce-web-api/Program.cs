var builder = WebApplication.CreateBuilder(args);

//add swagger service/register
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

//use swagger
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//make some endpoints

app.Map("/", () =>
{
    return "Hello from Root method";
});

// app.MapGet("/hello", () =>
// {
//     return "Hello i am from Get method";
// });

// app.MapPost("/hello", () =>
// {
//     return "Hello from Post method";
// });

// app.MapPut("/hello", () =>
// {
//     return "Hello from Put method";
// });

// app.MapDelete("/hello", () =>
// {
//     return "Hello from Delete method";
// });

//Types of API Response

app.MapGet("/json", () =>
{
    //JSON Response
    var response = new
    {
      message = "This is a json object",
      massage1 = "Learn effectively",
      success = true  
    };
    return Results.Ok(response);
});

app.MapGet("/html", () =>
{
    //HTML Response
    return Results.Content("<h1>Hello world</h1>", "text/html");
});

app.MapGet("/file", () =>
{
    //File Response
    return Results.File("");   
});

//Return list op products 

//List of products
var Products = new List<ProductDto>()
{
    new ProductDto("Samsung A36", 36500),
    new ProductDto("Samsung Z7", 192000),
    new ProductDto("Apple Iphone 17 Pro", 170000)
};

app.MapGet("/products", () =>
{
    return Results.Ok(Products);  
});



app.Run();

//product DTO
public record ProductDto(string Name, decimal Price);

