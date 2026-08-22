namespace StockScanner.Api.Models;

public class StockData
{
    public string Symbol { get; set; } = string.Empty;

    public List<Candle> Candles { get; set; } = new();
}