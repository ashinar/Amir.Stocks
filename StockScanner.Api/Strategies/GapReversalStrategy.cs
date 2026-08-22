using IBApi;
using StockScanner.Api.Models;
using StockScanner.Api.Services.Interfaces;

namespace StockScanner.Api.Strategies;

public class GapReversalStrategy : IStrategy
{
    private readonly IInteractiveBrokersService _interactiveBrokersService;

    public GapReversalStrategy(
        IInteractiveBrokersService interactiveBrokersService)
    {
        _interactiveBrokersService = interactiveBrokersService;
    }

    public string Name => "GapReversal";

    public Task StartScannerAsync()
    {
        var subscription = new ScannerSubscription
        {
            Instrument = "STK",
            LocationCode = "STK.US.MAJOR",
            ScanCode = "TOP_PERC_GAIN",
            NumberOfRows = 20
        };

        _interactiveBrokersService.StartScanner(subscription);

        return Task.CompletedTask;
    }

    public Task<StrategyResult> AnalyzeAsync(
        StockData stock,
        CancellationToken cancellationToken = default)
    {
        var result = new StrategyResult
        {
            Symbol = stock.Symbol,
            Strategy = Name,
            IsMatch = false,
            Signal = "NONE"
        };

        return Task.FromResult(result);
    }
}