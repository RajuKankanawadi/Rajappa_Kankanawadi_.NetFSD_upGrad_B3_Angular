
using WebApplication13.Repository;
using WebApplication13.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddMemoryCache();

// Dependency Injection
builder.Services.AddSingleton<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

app.MapControllers();

app.Run();