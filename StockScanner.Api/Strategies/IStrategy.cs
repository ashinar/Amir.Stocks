using StockScanner.Api.Models;

namespace StockScanner.Api.Strategies;

public interface IStrategy
{
    string Name { get; }

    Task<StrategyResult> AnalyzeAsync(
        StockData stock,
        CancellationToken cancellationToken = default);
}