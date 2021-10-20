## AsmSharp

Compile asm code into C# functions on fly! For now supports only x86 Windows 64-bit.

### Examples


Adds two integers:
```cs
var asm = new Assembler(bitness: 64);
asm.mov(rax, rcx);
asm.add(rax, rdx);
asm.ret();
var add = asm.ToFunctionPointerWinX64<ulong, ulong, ulong>();
Assert.Equal(44ul, add(31, 13));
```

Finds `a * b + c * d`:
```cs
var asm = new Assembler(bitness: 64);

var a = rcx;
var b = rdx;
var c = r8;
var d = r9;

asm.mov(rax, a);
asm.imul(rax, b);
asm.mov(rbx, c);
asm.imul(rbx, d);
asm.add(rax, rbx);
asm.ret();
var add = asm.ToFunctionPointerWinX64<long, long, long, long, long>();
Assert.Equal(210L, add(5, 2, 10, 20));
```

... assuming the [conventions](https://docs.microsoft.com/en-us/cpp/build/x64-calling-convention?view=msvc-160).