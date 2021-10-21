using System;
using System.Diagnostics;
using Plotly.NET;
using HonkPerf.NET.RefLinq;
using System.Collections.Generic;
#if NET6_0_OR_GREATER
using System.Runtime.InteropServices;
#endif

namespace NaiveNanoBench;

public sealed unsafe class NanoBench
{
    private readonly ulong warmupIterations;
    private ulong warmupInvokationsPerIteration;
    private readonly ulong actualIterations;
    private readonly double timePerIteration;
    private readonly Stopwatch sw = new();
    private readonly List<double> results = new();
    private readonly ulong userInvokationsPerCall;

    public NanoBench(ulong userInvokationsPerCall = 1, ulong warmupIterations = 20, ulong actualIterations = 100, double timePerIteration = 1.0, ulong defaultWarmupInvokationsPerIteration = 100_000)
    {
        this.userInvokationsPerCall = userInvokationsPerCall;
        this.warmupIterations = warmupIterations;
        this.actualIterations = actualIterations;
        this.timePerIteration = timePerIteration;
        this.warmupInvokationsPerIteration = defaultWarmupInvokationsPerIteration;
    }

    private const ulong LoopUnroll = 32;
    private (double Mean, double Total) MeasureMeanTime(
#if NET6_0_OR_GREATER
        delegate* unmanaged[Cdecl, SuppressGCTransition]<ulong, ulong> del,
#else
        delegate* unmanaged[Cdecl]<ulong, ulong> del,
#endif
        ulong invokations)
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

    
    public void Bench(delegate* unmanaged[Cdecl]<ulong, ulong> func)
    {
        results.Clear();

        var del = 
#if NET6_0_OR_GREATER
        (delegate* unmanaged[Cdecl, SuppressGCTransition]<ulong, ulong>)
#else
        (delegate* unmanaged[Cdecl]<ulong, ulong>)
#endif
        func;

        Console.WriteLine("Warm up...");

        var measuredSum = 0d;
        for (ulong i = 0; i < warmupIterations; i++)
        {
            var (mean, total) = MeasureMeanTime(del, warmupInvokationsPerIteration);
            if (total < 0.5)
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
            Console.WriteLine($"Warm up {i + 1} / {warmupIterations}: {FormatTimePerInvoke(mean / userInvokationsPerCall)} per invokation");
        }

        var avg = measuredSum / warmupIterations;
        Console.WriteLine($"Average warmup time: {FormatTimePerInvoke(avg / userInvokationsPerCall)}");

        var actualInvokationsPerIteration = (ulong)(timePerIteration / avg);
        Console.WriteLine($"Actual invokations per iteration: {actualInvokationsPerIteration}");

        Console.WriteLine("\nActual measuring...");

        for (ulong i = 0; i < actualIterations; i++)
        {
            var (mean, _) = MeasureMeanTime(del, actualInvokationsPerIteration);
            results.Add(mean);
            Console.WriteLine($"Actual {i + 1} / {actualIterations}: {FormatTimePerInvoke(mean / userInvokationsPerCall)} per invokation");
        }

        Console.WriteLine($"\nMean: {FormatTimePerInvoke(results.ToRefLinq().Average() / userInvokationsPerCall)}\n");
    }

    public IList<double> LastResults => results;

    public void ShowDistributionOfResults()
    {
        var histo = Chart2D.Chart.Histogram<double, double, double>(results);
        Chart.Show(histo);
    }
}