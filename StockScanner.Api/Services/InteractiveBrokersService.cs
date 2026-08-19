using IBApi;
using Microsoft.Extensions.Options;
using StockScanner.Api.Configuration;
using StockScanner.Api.Services.Interfaces;

namespace StockScanner.Api.Services;

public class InteractiveBrokersService : IInteractiveBrokersService
{
    private Thread? _readerThread;
    private readonly InteractiveBrokersOptions _options;
    private readonly InteractiveBrokersWrapper _wrapper;
    private readonly EClientSocket _client;

    private EReader? _reader;
    private EReaderMonitorSignal? _signal;
    private Task? _readerTask;

    public InteractiveBrokersService(
        IOptions<InteractiveBrokersOptions> options)
    {
        _options = options.Value;

        _wrapper = new InteractiveBrokersWrapper();

        _client = new EClientSocket(
            _wrapper,
            null);
    }

    public async Task ConnectAsync(
        CancellationToken cancellationToken = default)
    {
        if (_client.IsConnected())
            return;

        _signal = new EReaderMonitorSignal();

        _client.eConnect(
            _options.Host,
            _options.Port,
            _options.ClientId);

        if (!_client.IsConnected())
        {
            throw new InvalidOperationException(
                $"Failed to connect to Interactive Brokers at {_options.Host}:{_options.Port}");
        }

        _reader = new EReader(_client, _signal);
        _reader.Start();

        _readerThread = new Thread(() =>
        {
            while (_client.IsConnected())
            {
                _signal.waitForSignal();

                try
                {
                    _reader.processMsgs();
                }
                catch
                {
                    break;
                }
            }
        });

        _readerThread.IsBackground = true;
        _readerThread.Start();

        await Task.CompletedTask;
    }

    public Task DisconnectAsync()
    {
        if (_client.IsConnected())
        {
            _client.eDisconnect();
        }

        return Task.CompletedTask;
    }

    public Task<bool> IsConnectedAsync()
    {
        return Task.FromResult(
            _client.IsConnected());
    }

    public Task<decimal?> GetMarketPriceAsync(
        string symbol,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<string>> GetAccountPositionsAsync(
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}