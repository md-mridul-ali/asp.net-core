using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;

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

//make categories
List<Category> categories = new List<Category>();

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

// app.MapGet("/json", () =>
// {
//     //JSON Response
//     var response = new
//     {
//       message = "This is a json object",
//       massage1 = "Learn effectively",
//       success = true  
//     };
//     return Results.Ok(response);
// });

// app.MapGet("/html", () =>
// {
//     //HTML Response
//     return Results.Content("<h1>Hello world</h1>", "text/html");
// });

// app.MapGet("/file", () =>
// {
//     //File Response
//     return Results.File("");   
// });

//Return list op products 

//List of products
// var Products = new List<ProductDto>()
// {
//     new ProductDto("Samsung A36", 36500),
//     new ProductDto("Samsung Z7", 192000),
//     new ProductDto("Apple Iphone 17 Pro", 170000)
// };

// app.MapGet("/products", () =>
// {
//     return Results.Ok(Products);  
// });

//CRUD Operation

//Read categories
app.MapGet("/api/categories", () =>
{
    return Results.Ok(categories);
});

//Create categories
app.MapPost("/api/categories", () =>
{
   var NewCategory = new Category
   {
      Id = Guid.Parse("78cba759-c928-45aa-a199-9131c75e7485"),
      Name = "Electronics",
      Description = "Devices and gadgets including Phones, Laptops and other electronics equipment",
      dateTime = DateTime.UtcNow 
   };
   categories.Add(NewCategory);
   return Results.Created($"/api/categories/{NewCategory.Id}", NewCategory);
});

//Delete categories
app.MapDelete("/api/categories", () =>
{
   var FindCategory = categories.FirstOrDefault( Category => Category.Id == Guid.Parse("78cba759-c928-45aa-a199-9131c75e7485"));
   if(FindCategory == null)
    {
        return Results.NotFound("Category not found");
    } 
    categories.Remove(FindCategory);
    return Results.NoContent();
});

//Update category
app.MapPut("/api/categories", () =>
{
    var UpdateCategory = categories.FirstOrDefault( Category => Category.Id == Guid.Parse("78cba759-c928-45aa-a199-9131c75e7485"));
    if(UpdateCategory == null)
    {
        return Results.NotFound("Category not found");
    }
    UpdateCategory.Name = "Smart Phone";
    UpdateCategory.Description = "Smart phone is nice category";
    return Results.NoContent();
});

app.Run();

//product DTO(Types of Response)
// public record ProductDto(string Name, decimal Price);


//CRUD Operation
public record Category
{
    public Guid Id{get; set;}
    public String? Name{get; set;}
    public string? Description{get; set;}
    public DateTime dateTime{get; set;}
};
//CRUD
//Create => Create a category => POST : /api/categories
//Read => Read a category => GET : /api/categories
//Update => Update a category => PUT : /api/categories
//Delete => Delete a category => DELETE : /api/categories

