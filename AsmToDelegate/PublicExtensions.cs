using Iced.Intel;
using System;
using System.IO;

namespace AsmToDelegate;

public unsafe static class Extensions
{
    public record struct UnmanagedFunctionWinX64<TIn1, TOut>(
        delegate* unmanaged[Cdecl]<TIn1, TOut> Delegate,
        UnmanagedUntypedFuncInfo FuncInfo)
    {
        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TIn1, TOut> ToUnmanagedFunctionWinX64<TIn1, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TIn1, TOut>((delegate* unmanaged[Cdecl]<TIn1, TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TIn1, TOut> ToFunctionPointerWinX64<TIn1, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TIn1, TOut>)s.Pointer;
    }
}