using Microsoft.AspNetCore.RateLimiting;

using System.Threading.RateLimiting;

using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddSwaggerGen()
    .AddRateLimiter(options =>
    {
        options.AddFixedWindowLimiter("smallSmall", policy =>
        {
            policy.PermitLimit = 5;
            policy.Window = TimeSpan.FromSeconds(15);
            policy.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            policy.QueueLimit = 3;
        });
    })
    .AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization()
    .UseRateLimiter();

app.MapControllers();

app.Run();
