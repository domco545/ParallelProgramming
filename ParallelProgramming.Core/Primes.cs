using System.Collections.Concurrent;
using System.Diagnostics;

namespace ParallelProgramming.Core;

public class Primes
{
    public Primes()
    {
        Console.WriteLine("Sequential implementation");
        MeasureTime(() => GetPrimesSequential(1, 1000000));

        Console.WriteLine("Parallel implementation");
        MeasureTime(() => GetPrimesParallel(1, 1000000));
    }
    public List<long> GetPrimesSequential(int first, int last)
    {
        List<long> primes = new List<long>();
        for (long i = first; i <= last; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes;
    }

    public List<long> GetPrimesParallel(long first, long last)
    {
        var result = new ConcurrentBag<long>();
        var range = last - first;
        Parallel.For(first, last, (i, state) =>
        {
            if (IsPrime(i))
            {
                result.Add(i);
            }
        });

        return result.OrderBy(x => x).ToList();
    }

    private bool IsPrime(long num)
    {
        if (num == 1) return false;
        if (num == 2) return true;

        var limit = Math.Ceiling(Math.Sqrt(num));

        for (int i = 2; i <= limit; ++i)  
            if (num % i == 0)  
                return false;
        return true;
    }
    private static void MeasureTime(Action ac)
    {
        Stopwatch sw = Stopwatch.StartNew();
        ac.Invoke();
        sw.Stop();
        Console.WriteLine("Time = " + sw.Elapsed.Milliseconds);
    }
}