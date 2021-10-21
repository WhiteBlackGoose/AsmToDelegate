using Iced.Intel;
using static Iced.Intel.AssemblerRegisters;
using AsmToDelegate;
using System.Diagnostics;
using NaiveNanoBench;

unsafe
{

    var fourInstructions = new Assembler(bitness: 64);
    for (int i = 0; i < 1000; i++)
    {
        fourInstructions.mov(rcx, 6);
        fourInstructions.mov(r8, 10);
        fourInstructions.add(eax, r8d);
        fourInstructions.add(eax, ecx);
    }
    fourInstructions.ret();

    var compiled = fourInstructions.ToUnmanagedFunctionWinX64<ulong, ulong>();

    var dummy = new Assembler(bitness: 64);
    dummy.ret();

    var dummyCompiled = dummy.ToUnmanagedFunctionWinX64<ulong, ulong>();

    var bench = new NanoBench(10, 100, 1.0);

    bench.Bench(compiled);
    bench.ShowDistributionOfResults();

    bench.Bench(dummyCompiled);
    bench.ShowDistributionOfResults();
}
