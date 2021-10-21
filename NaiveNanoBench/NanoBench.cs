using AsmToDelegate;
using System.Diagnostics;
using Plotly.NET;
using HonkPerf.NET.RefLinq;
using System.Runtime.InteropServices;

namespace NaiveNanoBench;

/// <summary>
/// Warm up automatically finds the correct number of invokations per iteration
/// 
/// 
/// </summary>
public sealed unsafe class NanoBench
{
    private readonly ulong warmupIterations;
    private ulong warmupInvokationsPerIteration;
    private readonly ulong actualIterations;
    private readonly double timePerIteration;
    private readonly Stopwatch sw = new();
    private readonly List<double> results = new();

    public NanoBench(ulong warmupIterations = 10, ulong actualIterations = 100, double timePerIteration = 1.0, ulong defaultWarmupInvokationsPerIteration = 100_000)
    {
        this.warmupIterations = warmupIterations;
        this.actualIterations = actualIterations;
        this.timePerIteration = timePerIteration;
        this.warmupInvokationsPerIteration = defaultWarmupInvokationsPerIteration;
    }

    private const ulong LoopUnroll = 32;
    private (double Mean, double Total) MeasureMeanTime(delegate* unmanaged[Cdecl, SuppressGCTransition]<ulong, ulong> del, ulong invokations)
    {
        sw.Reset();
        sw.Start();
        for (ulong i = 0; i < invokations / LoopUnroll; i++)
        {
            del(i); del(i); del(i); del(i);
            del(i); del(i); del(i); del(i);
            del(i); del(i); del(i); del(i);
            del(i); del(i); del(i); del(i);
            del(i); del(i); del(i); del(i);
            del(i); del(i); del(i); del(i);
            del(i); del(i); del(i); del(i);
            del(i); del(i); del(i); del(i);
        }
        sw.Stop();
        var total = (double)sw.ElapsedMilliseconds / 1000;
        var mean = total / (invokations / LoopUnroll * LoopUnroll);
        return (mean, total);
    }

    private static string FormatTimePerInvoke(double time)
    {
        if (time >= 0.1)
            return $"{time:0.###} s.";
        if (time >= 0.000_1)
            return $"{time * 1_000:0.###} ms.";
        if (time >= 0.000_000_1)
            return $"{time * 1_000_000:0.###} us.";
        return $"{time * 1_000_000_000:0.###} ns.";
    }

    [SuppressGCTransition]
    public void Bench(Extensions.UnmanagedFunctionWinX64<ulong, ulong> func)
    {
        results.Clear();
        var del = (delegate* unmanaged[Cdecl, SuppressGCTransition]<ulong, ulong>)func.Delegate;


        Console.WriteLine("Warm up...");

        var measuredSum = 0d;
        for (ulong i = 0; i < warmupIterations; i++)
        {
            var (mean, total) = MeasureMeanTime(del, warmupInvokationsPerIteration);
            if (total < 0.1)
            {
                warmupInvokationsPerIteration = 3 * warmupInvokationsPerIteration / 2;
                Console.WriteLine($"Skipping {i + 1}, as {FormatTimePerInvoke(total)} is too little");
                i--;
                continue;
            }
            if (total > 10)
            {
                warmupInvokationsPerIteration = 2 * warmupInvokationsPerIteration / 3;
                Console.WriteLine($"Skipping {i + 1}, as {FormatTimePerInvoke(total)} is too much");
                i--;
                continue;
            }
            measuredSum += mean;
            Console.WriteLine($"Warm up {i + 1} / {warmupIterations}: {FormatTimePerInvoke(mean)} per invokation");
        }

        var avg = measuredSum / warmupIterations;
        Console.WriteLine($"Average warmup time: {FormatTimePerInvoke(avg)}");

        var actualInvokationsPerIteration = (ulong)(timePerIteration / avg);
        Console.WriteLine($"Actual invokations per iteration: {actualInvokationsPerIteration}");

        Console.WriteLine("\nActual measuring...");

        for (ulong i = 0; i < actualIterations; i++)
        {
            var (mean, _) = MeasureMeanTime(del, actualInvokationsPerIteration);
            results.Add(mean);
            Console.WriteLine($"Actual {i + 1} / {actualIterations}: {FormatTimePerInvoke(mean)} per invokation");
        }

        Console.WriteLine($"\nMean: {FormatTimePerInvoke(results.ToRefLinq().Average())}\n");
    }

    public IList<double> LastResults => results;

    public void ShowDistributionOfResults()
    {
        var histo = Chart2D.Chart.Histogram<double, double, double>(results);
        Chart.Show(histo);
    }
}