using IBApi;
using StockScanner.Api.Models;

namespace StockScanner.Api.Services.Interfaces
{
    public interface IInteractiveBrokersService
    {
        Task<List<StockData>> StartScannerAsync(ScannerSubscription subscription,List<TagValue> scannerSubscriptionOptions, List<TagValue> scannerSubscriptionFilterOptions,CancellationToken cancellationToken = default);
        Task<bool> ConnectAsync(CancellationToken cancellationToken = default);

        Task DisconnectAsync();

        Task<bool> IsConnectedAsync();

        Task<decimal?> GetMarketPriceAsync(
            string symbol,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<string>> GetAccountPositionsAsync(
            CancellationToken cancellationToken = default);
    }
}
