using StockScanner.Api.Configuration;
using StockScanner.Api.Services;
using StockScanner.Api.Services.Interfaces;
using StockScanner.Api.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Services.Configure<InteractiveBrokersOptions>(
    builder.Configuration.GetSection("InteractiveBrokers"));

// Interactive Brokers
// Singleton - יש חיבור אחד מתמשך ל-TWS
builder.Services.AddSingleton<
    IInteractiveBrokersService,
    InteractiveBrokersService>();

// Strategies
builder.Services.AddScoped<GapReversalStrategy>();

builder.Services.AddScoped<IStrategy>(sp =>
    sp.GetRequiredService<GapReversalStrategy>());

// Scanner service
builder.Services.AddScoped<StockScannerService>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();