using Iced.Intel;
using System;
using System.IO;

namespace AsmToDelegate;

public unsafe struct UnmanagedUntypedFuncInfo
{
    public void* Pointer;
    public nuint Size;

    public void Free()
    {
        VirtualAllocHelpers.VirtualFree(Pointer, 0, VirtualAllocHelpers.FreeType.MEM_RELEASE);
    }
}

internal static unsafe class BuilderToMemory
{
    internal static UnmanagedUntypedFuncInfo CompileX64Windows(Assembler asm)
    {
        using var stream = new MemoryStream();
        var codeWriter = new StreamCodeWriter(stream);
        asm.Assemble(codeWriter, 0);
        ReadOnlySpan<byte> span = new(stream.GetBuffer(), 0, (int)stream.Length);

        void* alloc = AllocationHelpers.AllocateExecutable(span);

        return new() { Pointer = alloc, Size = (nuint)span.Length };
    }
}
