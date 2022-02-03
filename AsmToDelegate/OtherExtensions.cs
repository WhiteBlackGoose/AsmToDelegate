using Iced.Intel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace AsmToDelegate;
public static class OtherExtensions
{
    internal delegate byte Out1();
    internal delegate short Out2();
    internal delegate int Out4();
    internal delegate long Out8();

    internal static TOut Let<TIn, TOut>(this TIn @this, Func<TIn, TOut> f)
        => f(@this);

    internal static TTo ChangeType<TFrom, TTo>(this TFrom former)
    {
        var r = Unsafe.As<TFrom, TTo>(ref former);
        return r;
    }

    public static unsafe Func<TOut> ToDelegateUnsafe<TOut>(this Assembler asm) where TOut : unmanaged
    {
        var s = BuilderToMemory.CompileX64Windows(asm);
        var func = sizeof(TOut) switch
        {
            1 => Marshal.GetDelegateForFunctionPointer<Out1>((IntPtr)s.Pointer).Let(del => () => del().ChangeType<byte, TOut>()),
            2 => Marshal.GetDelegateForFunctionPointer<Out2>((IntPtr)s.Pointer).Let(del => () => del().ChangeType<short, TOut>()),
            4 => Marshal.GetDelegateForFunctionPointer<Out4>((IntPtr)s.Pointer).Let(del => () => del().ChangeType<int, TOut>()),
            8 => Marshal.GetDelegateForFunctionPointer<Out8>((IntPtr)s.Pointer).Let(del => () => del().ChangeType<long, TOut>()),
            _ => throw new($"Size {sizeof(TOut)} is not supported")
        };
        return func;
    }
}
