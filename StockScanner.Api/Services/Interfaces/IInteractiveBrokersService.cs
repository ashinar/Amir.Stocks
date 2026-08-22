using IBApi;

namespace StockScanner.Api.Services.Interfaces
{
    public interface IInteractiveBrokersService
    {
        void StartScanner(ScannerSubscription subscription);

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
