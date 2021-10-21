using Iced.Intel;
using static Iced.Intel.AssemblerRegisters;
using AsmToDelegate;
using NaiveNanoBench;

unsafe
{

    var fourInstructions = new Assembler(bitness: 64);
    for (int i = 0; i < 1000; i++)
    {
        fourInstructions.mov(rcx, 6);
        // fourInstructions.mov(r8, 10);
        // fourInstructions.add(eax, r8d);
        // fourInstructions.add(eax, ecx);
    }
    fourInstructions.ret();

    var compiled = fourInstructions.ToUnmanagedFunctionWinX64<ulong, ulong>();

    var dummy = new Assembler(bitness: 64);
    dummy.ret();

    var dummyCompiled = dummy.ToUnmanagedFunctionWinX64<ulong, ulong>();

    var bench = new NanoBench(userInvokationsPerCall: 1000);

    bench.Bench(compiled.Delegate);
    bench.ShowDistributionOfResults();

    // bench.Bench(dummyCompiled.Delegate);
    // bench.ShowDistributionOfResults();
}
