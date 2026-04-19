using BookStore.Application.Services;
using BookStore.Domain.Policies;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

/// --------------------
/// Controllers + Swagger
/// --------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// --------------------
/// Dependency Injection
/// --------------------

// Domain
builder.Services.AddSingleton<PromotionPolicy>();

// Application
builder.Services.AddScoped<PromotionAppService>();

// Infrastructure (IMPORTANT)
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();
builder.Services.AddScoped<IBookRepository, FakeBookRepository>();

var app = builder.Build();

/// --------------------
/// Middleware pipeline
/// --------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }
