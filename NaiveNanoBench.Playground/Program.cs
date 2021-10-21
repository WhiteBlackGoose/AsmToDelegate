using Iced.Intel;
using static Iced.Intel.AssemblerRegisters;
using AsmToDelegate;
using NaiveNanoBench;

unsafe
{
    // var movFunction = new Assembler(bitness: 64);
    // for (int i = 0; i < 1000; i++)
    // {
    //     movFunction.mov(rcx, 6);
    // }
    // movFunction.ret();

    var movFunction = new Assembler(bitness: 64);
    var label = movFunction.CreateLabel();


    var compiled = movFunction.ToUnmanagedFunctionWinX64<ulong, ulong>();

    var dummy = new Assembler(bitness: 64);
    dummy.ret();

    var dummyCompiled = dummy.ToUnmanagedFunctionWinX64<ulong, ulong>();

    var bench = new NanoBench(userInvokationsPerCall: 1000);

    bench.Bench(compiled.Delegate);
    // bench.ShowDistributionOfResults();

    // bench.Bench(dummyCompiled.Delegate);
    // bench.ShowDistributionOfResults();
}
