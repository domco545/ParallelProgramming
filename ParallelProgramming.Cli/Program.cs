using System.Diagnostics;
using ParallelProgramming.Core;

var primes = new Primes();

var st = new Stopwatch();
st.Start();

var a= primes.GetPrimesSequential(1, 10000000);
Console.WriteLine($"Sequential time: {st.Elapsed.TotalSeconds}");
Console.WriteLine(a.Last());

st.Restart();

var b = primes.GetPrimesParallel(1, 10000000);
Console.WriteLine($"Parallel time: {st.Elapsed.TotalSeconds}");
Console.WriteLine(b.Last());

st.Stop();

