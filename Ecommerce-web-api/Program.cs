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

app.MapGet("/hello", () =>
{
    return "Hello i am from Get method";
});

app.MapPost("/hello", () =>
{
    return "Hello from Post method";
});

app.MapPut("/hello", () =>
{
    return "Hello from Put method";
});

app.MapDelete("/hello", () =>
{
    return "Hello from Delete method";
});

app.Run();

