using System;
using System.Runtime.InteropServices;

namespace AsmToDelegate;

internal static class Helpers
{
    [DllImport("kernel32.dll")]
    public static extern int GetLastError();

    [DllImport("kernel32.dll")]
    public static extern nuint GetCurrentProcess();

    public static void ThrowLastError()
    {
        throw new Exception($"Error! Last error: 0x{GetLastError():X}");
    }
}