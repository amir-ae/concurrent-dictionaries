using System.Collections.Concurrent;

namespace Library;

public class ConcurrentRateDictionary
{
    private readonly ConcurrentDictionary<string, Rate> _rates = new();

    public void UpdateRate(NativeRate newRate)
    {
        var rate = _rates.GetOrAdd(newRate.Symbol, new Rate { Symbol = newRate.Symbol });
        lock (rate)
        {
            rate.Time = newRate.Time;
            rate.Bid = newRate.Bid;
            rate.Ask = newRate.Ask;
        }
    }

    public Rate? GetRate(string symbol)
    {
        _rates.TryGetValue(symbol, out var rate);
        return rate;
    }
}