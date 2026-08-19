using StockScanner.Api.Configuration;
using StockScanner.Api.Services;
using StockScanner.Api.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<InteractiveBrokersOptions>(builder.Configuration.GetSection("InteractiveBrokers"));
builder.Services.AddSingleton<IInteractiveBrokersService,InteractiveBrokersService>();


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
