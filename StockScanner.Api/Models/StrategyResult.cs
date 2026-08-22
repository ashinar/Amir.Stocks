namespace StockScanner.Api.Models;

public class StrategyResult
{
    public bool IsMatch { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public string Strategy { get; set; } = string.Empty;

    public string Signal { get; set; } = string.Empty;

    public string? Reason { get; set; }
}