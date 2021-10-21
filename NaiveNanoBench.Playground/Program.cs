using Iced.Intel;
using static Iced.Intel.AssemblerRegisters;
using AsmToDelegate;
using NaiveNanoBench;

unsafe
{
    var factorial = new Assembler(bitness: 64);
    var label = factorial.CreateLabel();
    factorial.mov(rax, 0);
    factorial.mov(rcx, 1);
    factorial.Label(ref label);
    factorial.inc(rax);
    factorial.imul(rcx, rax);
    factorial.cmp(rax, 5);
    factorial.jl(label);
    factorial.mov(rax, rcx);
    factorial.ret();
    var compiled = factorial.ToUnmanagedFunctionWinX64<ulong, ulong>();
    var benchmark = new NanoBench();
    benchmark.Bench(compiled.Delegate);
    // benchmark.Bench(&Factorial);
    benchmark.ShowDistributionOfResults();


    // var movFunction = new Assembler(bitness: 64);
    // for (int i = 0; i < 1000; i++)
    // {
    //     movFunction.mov(rcx, 6);
    // }
    // movFunction.ret();

    // Console.WriteLine(compiled.Delegate(3));
    // 
    // return;

    // var dummy = new Assembler(bitness: 64);
    // dummy.ret();
    // 
    // var dummyCompiled = dummy.ToUnmanagedFunctionWinX64<ulong, ulong>();
    // 
    // var bench = new NanoBench(userInvokationsPerCall: 1000);
    // 
    // bench.Bench(compiled.Delegate);
    // bench.ShowDistributionOfResults();

    // bench.Bench(dummyCompiled.Delegate);
    // bench.ShowDistributionOfResults();
}

// static ulong Factorial(ulong _)
// {
//     var res = 1ul;
//     for (int i = 0; i < 5; i++)
//         res *= i;
//     return res;
// }