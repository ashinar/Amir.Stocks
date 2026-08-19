namespace StockScanner.Api.Configuration
{
    public class InteractiveBrokersOptions
    {
        public string Host { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 7497;
        public int ClientId { get; set; } = 1;
    }
}
