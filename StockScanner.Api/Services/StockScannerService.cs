using StockScanner.Api.Models;
using StockScanner.Api.Strategies;

namespace StockScanner.Api.Services;

public class StockScannerService
{
    private readonly IEnumerable<IStrategy> _strategies;

    public StockScannerService(IEnumerable<IStrategy> strategies)
    {
        _strategies = strategies;
    }

    public async Task<List<StrategyResult>> ScanAsync(
        StockData stock,
        CancellationToken cancellationToken = default)
    {
        var results = new List<StrategyResult>();

        foreach (var strategy in _strategies)
        {
            var result = await strategy.AnalyzeAsync(
                stock,
                cancellationToken);

            results.Add(result);
        }

        return results;
    }
}