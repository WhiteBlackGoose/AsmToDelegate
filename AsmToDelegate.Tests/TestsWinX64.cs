using Xunit;
using Iced.Intel;
using static Iced.Intel.AssemblerRegisters;

namespace AsmToDelegate.Tests;

// Calling conv:
// https://docs.microsoft.com/en-us/cpp/build/x64-calling-convention?view=msvc-160

/*

func1(int a, int b, int c, int d, int e, int f);
// a in RCX, b in RDX, c in R8, d in R9, f then e pushed on stack


func2(float a, double b, float c, double d, float e, float f);
// a in XMM0, b in XMM1, c in XMM2, d in XMM3, f then e pushed on stack

*/

public unsafe class TestsWinX64
{
    [Fact]
    public void Test1()
    {
        var asm = new Assembler(bitness: 64);
        asm.mov(rax, rcx);
        asm.add(rax, rdx);
        asm.ret();
        var add = asm.ToFunctionPointerWinX64<ulong, ulong, ulong>();
        Assert.Equal(44ul, add(31, 13));
    }

    [Fact]
    public void Test2()
    {
        var asm = new Assembler(bitness: 64);
        asm.mov(rax, rcx);
        asm.imul(rax, rax);
        asm.ret();
        var sqr = asm.ToFunctionPointerWinX64<long, long>();
        Assert.Equal(25L, sqr(5));
    }

    [Fact]
    public void Test3()
    {
        var asm = new Assembler(bitness: 64);
        asm.mov(rax, rcx);
        asm.imul(rax, rax);
        asm.ret();
        var sqr = asm.ToFunctionPointerWinX64<long, long>();
        Assert.Equal(9L, sqr(-3));
    }
}