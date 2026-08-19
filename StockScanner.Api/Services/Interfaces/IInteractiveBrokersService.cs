namespace StockScanner.Api.Services.Interfaces
{
    public interface IInteractiveBrokersService
    {
        Task ConnectAsync(CancellationToken cancellationToken = default);

        Task DisconnectAsync();

        Task<bool> IsConnectedAsync();

        Task<decimal?> GetMarketPriceAsync(
            string symbol,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<string>> GetAccountPositionsAsync(
            CancellationToken cancellationToken = default);
    }
}
