using System.Runtime.InteropServices;

namespace Library;

public class LockBasedRateDictionary
{
    private readonly Dictionary<string, Rate> _rates = new();
    private readonly ReaderWriterLockSlim _lock = new();

    public void UpdateRate(NativeRate newRate)
    {
        _lock.EnterWriteLock();
        try
        {
            ref var rate = ref CollectionsMarshal.GetValueRefOrAddDefault(_rates, newRate.Symbol, out var exists);

            if (!exists)
            {
                rate = new Rate { Symbol = newRate.Symbol };
            }
            
            rate!.Time = newRate.Time;
            rate.Bid = newRate.Bid;
            rate.Ask = newRate.Ask;
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }

    public Rate? GetRate(string symbol)
    {
        _lock.EnterReadLock();
        try
        {
            _rates.TryGetValue(symbol, out var rate);
            return rate;
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }
}