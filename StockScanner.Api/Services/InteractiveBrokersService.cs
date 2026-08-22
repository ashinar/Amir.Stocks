using IBApi;
using Microsoft.Extensions.Options;
using StockScanner.Api.Configuration;
using StockScanner.Api.Models;
using StockScanner.Api.Services.Interfaces;
using System.Net.Sockets;

namespace StockScanner.Api.Services;

public class InteractiveBrokersService : IInteractiveBrokersService
{
    private Thread? _readerThread;
    private readonly InteractiveBrokersOptions _options;
    private readonly InteractiveBrokersWrapper _wrapper;

    private readonly EClientSocket _client;
    private readonly EReaderMonitorSignal _signal;

    private EReader? _reader;
    private Task? _readerTask;

    private TaskCompletionSource<List<StockData>>? _scannerTcs;
    private List<StockData> _scannerStocks = new();

    public InteractiveBrokersService(IOptions<InteractiveBrokersOptions> options)
    {
        _options = options.Value;

        _wrapper = new InteractiveBrokersWrapper();

        _wrapper.ScannerStockReceived += OnScannerStockReceived;
        _wrapper.ScannerCompleted += OnScannerCompleted;

        _signal = new EReaderMonitorSignal();

        _client = new EClientSocket(
            _wrapper,
            _signal);
    }

    public async Task<bool> ConnectAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("BEFORE CONNECT");

        if (_client.IsConnected())
        {
            Console.WriteLine("ALREADY CONNECTED");
            return false;
        }


        Console.WriteLine(
            $"Connecting to {_options.Host}:{_options.Port}, ClientId={_options.ClientId}");

        _client.SetConnectOptions("");

        try
        {
            Console.WriteLine("1. Before eConnect");

            _client.eConnect(
                _options.Host,
                _options.Port,
                _options.ClientId);

            Console.WriteLine("AFTER ECONNECT");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ECONNECT EXCEPTION:");
            Console.WriteLine(ex.ToString());
            return false;
        }
        Console.WriteLine($"2. After eConnect. IsConnected={_client.IsConnected()}");



      
        _reader = new EReader(_client, _signal);
        Console.WriteLine("3. EReader created");
        _reader.Start();
        Console.WriteLine("4. EReader started");

        Console.WriteLine("READER STARTED");

        _readerThread = new Thread(() =>
        {
            Console.WriteLine("5. Reader thread started");

            while (_client.IsConnected())
            {
                Console.WriteLine("6. Waiting for signal");
                _signal.waitForSignal();

                Console.WriteLine("7. Signal received");
                try
                {
                    _reader.processMsgs();
                    Console.WriteLine("8. processMsgs completed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"IB Reader error: {ex.GetType().FullName}");

                    Console.WriteLine(ex);                   
                }
            }

            Console.WriteLine("9. Reader thread ended");
        })
        {
            IsBackground = true
        };

        _readerThread.Start();

        Console.WriteLine("WAITING FOR NEXT VALID ID");


        try
        {
            await _wrapper.ConnectionTask.WaitAsync(
            TimeSpan.FromSeconds(10),
            cancellationToken);
        }
        catch (TimeoutException)
        {
            Console.WriteLine("IBKR connection timeout.");
            return false;
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"IBKR socket error: {ex.Message}");
            return false;
        }


        Console.WriteLine("IB CONNECTION COMPLETED");
        return true;
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

    public async Task<List<StockData>> StartScannerAsync(
        ScannerSubscription subscription,
        CancellationToken cancellationToken = default)
    {
        _scannerStocks = new List<StockData>();

        _scannerTcs = new TaskCompletionSource<List<StockData>>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        _client.reqScannerSubscription(
            1001,
            subscription,
            new List<TagValue>(),
            new List<TagValue>());

        return await _scannerTcs.Task.WaitAsync(
            TimeSpan.FromSeconds(10),
            cancellationToken);
    }

    public void StartScanner(ScannerSubscription subscription)
    {
        _client.reqScannerSubscription(
        1001,
        subscription,
        new List<TagValue>(),
        new List<TagValue>());
    }

    private void OnScannerStockReceived(IBApi.ContractDetails contractDetails)
    {
        var symbol = contractDetails.Contract.Symbol;

        Console.WriteLine($"SERVICE RECEIVED: {symbol}");

        _scannerStocks.Add(new StockData
        {
            Symbol = symbol
        });
    }

    private void OnScannerCompleted()
    {
        Console.WriteLine("SERVICE: Scanner completed");
        _scannerTcs.TrySetResult(_scannerStocks);
    }
}