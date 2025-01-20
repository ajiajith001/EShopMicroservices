var builder = WebApplication.CreateBuilder(args);

// Add service to the container
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LogginBehavior<,>));
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapCarter();

app.Run();
