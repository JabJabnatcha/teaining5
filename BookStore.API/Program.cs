using BookStore.Application.Services;
using BookStore.Domain.Policies;
using BookStore.API;

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

// Domain / Business rule (stateless)
builder.Services.AddSingleton<PromotionPolicy>();

// Application layer (use case)
builder.Services.AddScoped<PromotionAppService>();

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