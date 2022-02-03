using Iced.Intel;
using System;
using System.IO;
using System.Runtime.InteropServices;

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

    public static Func<TOut> ToDelegate<TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return (() => {
            var del = (delegate* unmanaged[Cdecl]<TOut>)ptr;
            return del();
        });
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

    public static Func<TIn1, TOut> ToDelegate<TIn1, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TIn1, TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return ((a1) => {
            var del = (delegate* unmanaged[Cdecl]<TIn1, TOut>)ptr;
            return del(a1);
        });
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

    public static Func<TIn1, TIn2, TOut> ToDelegate<TIn1, TIn2, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TIn1, TIn2, TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return ((a1, a2) => {
            var del = (delegate* unmanaged[Cdecl]<TIn1, TIn2, TOut>)ptr;
            return del(a1, a2);
        });
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

    public static Func<TIn1, TIn2, TIn3, TOut> ToDelegate<TIn1, TIn2, TIn3, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TIn1, TIn2, TIn3, TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return ((a1, a2, a3) => {
            var del = (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TOut>)ptr;
            return del(a1, a2, a3);
        });
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

    public static Func<TIn1, TIn2, TIn3, TIn4, TOut> ToDelegate<TIn1, TIn2, TIn3, TIn4, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TIn1, TIn2, TIn3, TIn4, TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return ((a1, a2, a3, a4) => {
            var del = (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TOut>)ptr;
            return del(a1, a2, a3, a4);
        });
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

    public static Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut> ToDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return ((a1, a2, a3, a4, a5) => {
            var del = (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>)ptr;
            return del(a1, a2, a3, a4, a5);
        });
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

    public static Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut> ToDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return ((a1, a2, a3, a4, a5, a6) => {
            var del = (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>)ptr;
            return del(a1, a2, a3, a4, a5, a6);
        });
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

    public static Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut> ToDelegate<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(this Assembler asm)
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        // return Marshal.GetDelegateForFunctionPointer<Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>>((IntPtr)s.Pointer);
        var ptr = (long)(IntPtr)s.Pointer;
        return ((a1, a2, a3, a4, a5, a6, a7) => {
            var del = (delegate* unmanaged[Cdecl]<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>)ptr;
            return del(a1, a2, a3, a4, a5, a6, a7);
        });
    }

 
} 