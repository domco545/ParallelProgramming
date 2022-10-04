using System.Collections.Concurrent;

namespace ParallelProgramming.Core;

public class Primes
{
    public List<long> GetPrimesSequential(long first, long last)
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
}