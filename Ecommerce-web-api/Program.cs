var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();



app.UseHttpsRedirection();

//make some endpoints

app.Map("/", () =>
{
    return "Hello from Root method";
});

app.MapGet("/hello", () =>
{
    return "Hello from Get method";
});

app.MapPost("/hello", () =>
{
    return "Hello from Post method";
});

app.MapPut("/hello", () =>
{
    return "Hello from Get method";
});

app.MapDelete("/hello", () =>
{
    return "Hello from Get method";
});

app.Run();

