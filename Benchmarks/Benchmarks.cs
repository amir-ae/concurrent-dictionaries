using BenchmarkDotNet.Attributes;
using Library;

namespace Benchmarks;

public class Benchmarks
{
    private readonly NativeRate _sampleRate = new() { Time = DateTime.Now, Symbol = "EURUSD", Bid = 1.1, Ask = 1.2 };
    private List<NativeRate> _initialValues = new();
    private ConcurrentRateDictionary _concurrentRateDictionary = new();
    private LockBasedRateDictionary _lockBasedRateDictionary = new();

    [Params(10, 100, 1000, 10000)] 
    public int ConcurrencyLevel;

    [GlobalSetup]
    public void Setup()
    {
        _concurrentRateDictionary = new ConcurrentRateDictionary();
        _lockBasedRateDictionary = new LockBasedRateDictionary();
        _initialValues = new() { _sampleRate };
        
        for (var i = 1; i < ConcurrencyLevel; i++)
        {
            _initialValues.Add(new NativeRate { Time = DateTime.Now, Symbol = Guid.NewGuid().ToString(), Bid = 1, Ask = 2 });
        }

        foreach (var nativeRate in _initialValues)
        {
            _concurrentRateDictionary.UpdateRate(nativeRate);
            _lockBasedRateDictionary.UpdateRate(nativeRate);
        }
    }
    
    [Benchmark]
    [BenchmarkCategory("UpdateRate")]
    public async Task UpdateRateConcurrent()
    {
        var tasks = new Task[ConcurrencyLevel];
        for (int i = 0; i < ConcurrencyLevel; i++)
        {
            tasks[i] = Task.Run(() => _concurrentRateDictionary.UpdateRate(_sampleRate));
        }
        await Task.WhenAll(tasks);
    }

    [Benchmark]
    [BenchmarkCategory("GetRate")]
    public async Task<Rate?> GetRateConcurrent()
    {
        var tasks = new Task<Rate?>[ConcurrencyLevel];
        for (int i = 0; i < ConcurrencyLevel; i++)
        {
            tasks[i] = Task.Run(() => _concurrentRateDictionary.GetRate(_sampleRate.Symbol));
        }
        var results = await Task.WhenAll(tasks);
        return results[0];
    }
    
    [Benchmark]
    [BenchmarkCategory("UpdateRate")]
    public async Task UpdateRateLock()
    {
        var tasks = new Task[ConcurrencyLevel];
        for (int i = 0; i < ConcurrencyLevel; i++)
        {
            tasks[i] = Task.Run(() => _lockBasedRateDictionary.UpdateRate(_sampleRate));
        }
        await Task.WhenAll(tasks);
    }

    [Benchmark]
    [BenchmarkCategory("GetRate")]
    public async Task<Rate?> GetRateLock()
    {
        var tasks = new Task<Rate?>[ConcurrencyLevel];
        for (int i = 0; i < ConcurrencyLevel; i++)
        {
            tasks[i] = Task.Run(() => _lockBasedRateDictionary.GetRate(_sampleRate.Symbol));
        }
        var results = await Task.WhenAll(tasks);
        return results[0];
    }
}