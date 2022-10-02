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

    public List<int> GetPrimesParallel(int first, int last)
    {
        var range = last - first;
        var r = from i in Enumerable.Range(first, range - 1).AsParallel()
            where Enumerable.Range(1, (int) Math.Sqrt(i)).All(j => j == 1 || i % j != 0)
            select i;
        return r.OrderBy(x => x).ToList();
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