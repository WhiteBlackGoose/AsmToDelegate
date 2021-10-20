using Iced.Intel;
using System;
using System.IO;

namespace AsmToDelegate;

public unsafe static class Extensions
{
    public struct UnmanagedFunctionWinX64<TOut>
    {
        public delegate* unmanaged[Cdecl]<TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TOut> ToUnmanagedFunctionWinX64<TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TOut>((delegate* unmanaged[Cdecl]<TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TOut> ToFunctionPointerWinX64<TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TOut>)s.Pointer;
    }

    public struct UnmanagedFunctionWinX64<TIn1, TOut>
    {
        public delegate* unmanaged[Cdecl]<TIn1, TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TIn1, TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

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

    public struct UnmanagedFunctionWinX64<TIn1, TIn2, TOut>
    {
        public delegate* unmanaged[Cdecl]<TIn1, TIn2, TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TIn1, TIn2, TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TIn1, TIn2, TOut> ToUnmanagedFunctionWinX64<TIn1, TIn2, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TIn1, TIn2, TOut>((delegate* unmanaged[Cdecl]<TIn1, TIn2, TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TIn1, TIn2, TOut> ToFunctionPointerWinX64<TIn1, TIn2, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TIn1, TIn2, TOut>)s.Pointer;
    }

    public struct UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TOut>
    {
        public delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TOut> ToUnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TOut>((delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TOut> ToFunctionPointerWinX64<TIn1, TIn2, TIn3, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TOut>)s.Pointer;
    }

    public struct UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TOut>
    {
        public delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TOut> ToUnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TOut>((delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TOut> ToFunctionPointerWinX64<TIn1, TIn2, TIn3, TIn4, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TOut>)s.Pointer;
    }

    public struct UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>
    {
        public delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> ToUnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>((delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> ToFunctionPointerWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>)s.Pointer;
    }

    public struct UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>
    {
        public delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> ToUnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>((delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> ToFunctionPointerWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>)s.Pointer;
    }

    public struct UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>
    {
        public delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> Delegate { get; }

        public UnmanagedUntypedFuncInfo FuncInfo { get; }

        public UnmanagedFunctionWinX64(delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> fnptr, UnmanagedUntypedFuncInfo funcInfo)
        {
            Delegate = fnptr;
            FuncInfo = funcInfo;
        }

        public void Free() => FuncInfo.Free();
    }

    public static UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> ToUnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return new UnmanagedFunctionWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>((delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>)s.Pointer, s);
    }

    public static delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> ToFunctionPointerWinX64<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        return (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>)s.Pointer;
    }

 
} 