// See https://aka.ms/new-console-template for more information
using Iced.Intel;
using static Iced.Intel.AssemblerRegisters;
using AsmToDelegate;

var add = new Assembler(bitness: 64);
add.mov(rax, rcx);
add.add(rax, rdx);
add.ret();



unsafe
{
    var a = new Assembler(64);
    a.mov(rax, rcx);
    a.add(rax, rdx);
    a.ret();
    var fun= a.ToFunctionPointerWinX64<long, long, long>();
    Console.WriteLine(fun(1, 5));
    var del = a.ToDelegate<long, long, long>();
    Console.WriteLine(del(1, 5));
}