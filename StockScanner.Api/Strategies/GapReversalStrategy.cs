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

    public async Task StartScannerAsync(
        CancellationToken cancellationToken = default)
    {


        var subscription = new ScannerSubscription
        {
            Instrument = "STK",
            LocationCode = "STK.US.MAJOR",
            ScanCode = "TOP_PERC_GAIN",
            NumberOfRows = 100,

            // Minimum stock price: $15
            AbovePrice = 15,
            AboveVolume = 100_000
        };
    



        var stocks = await _interactiveBrokersService.StartScannerAsync(
            subscription,
            new List<TagValue>(),
            new List<TagValue>(),
            cancellationToken);


        List<StockData> longGapStocks = new List<StockData>();
        foreach (var stock in stocks)
        {
            if (stock.Candles.Count == 0)
                continue;

            var previousClose = stock.Candles[^1].Close;
            var currentPrice = stock.Candles[^1].Open;

            var gapPercent =
                ((currentPrice - previousClose) / previousClose) * 100;

            if (gapPercent >= 4 && gapPercent <= 30)
            {
                longGapStocks.Add(stock);

                Console.WriteLine($"GAP STOCK: {stock.Symbol} | GAP: {gapPercent:F2}%");
            }
        }
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