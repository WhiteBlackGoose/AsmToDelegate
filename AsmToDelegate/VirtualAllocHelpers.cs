using System;
using System.Runtime.InteropServices;

namespace AsmToDelegate;

internal static unsafe class VirtualAllocHelpers
{
    [Flags]
    public enum AllocationType : int
    {
        MEM_COMMIT = 0x00001000,
        MEM_RESERVE = 0x00002000,
        MEM_RESET = 0x00080000,
        MEM_RESET_UNDO = 0x1000000,
        MEM_LARGE_PAGES = 0x20000000,
        MEM_PHYSICAL = 0x00400000,
        MEM_TOP_DOWN = 0x00100000,
        MEM_WRITE_WATCH = 0x00200000
    }

    [Flags]
    public enum MemoryProtection : int
    {
        PAGE_EXECUTE = 0x10,
        PAGE_EXECUTE_READ = 0x20,
        PAGE_EXECUTE_READWRITE = 0x40,
        PAGE_EXECUTE_WRITECOPY = 0x80,
        PAGE_NOACCESS = 0x01,
        PAGE_READWRITE = 0x04,
        PAGE_WRITECOPY = 0x08,
        PAGE_TARGETS_INVALID = 0x40000000,
        PAGE_TARGETS_NO_UPDATE = 0x40000000,

        PAGE_GUARD = 0x100,
        PAGE_NOCACHE = 0x200,
        PAGE_WRITECOMBINE = 0x400
    }

    [Flags]
    public enum FreeType : int
    {
        MEM_DECOMMIT = 0x00004000,
        MEM_RELEASE = 0x00008000,
        MEM_COALESCE_PLACEHOLDERS = 0x00000001,
        MEM_PRESERVE_PLACEHOLDER = 0x00000002
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern void* VirtualAlloc(void* lpAddress, nuint dwSize, AllocationType lAllocationType, MemoryProtection flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern void* VirtualFree(void* lpAddress, nuint dwSize, FreeType freeType);


    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int VirtualProtect(void* lpAddress, nuint dwSize, MemoryProtection flNewProtect, out MemoryProtection lpflOldProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int FlushInstructionCache(nuint hProcess, void* lpBaseAddress, nuint dwSize);
}