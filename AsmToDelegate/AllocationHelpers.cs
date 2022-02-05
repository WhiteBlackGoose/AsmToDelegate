
using System;
using static AsmToDelegate.VirtualAllocHelpers;

namespace AsmToDelegate;

public unsafe static class AllocationHelpers
{
    public static void* AllocateExecutable(ReadOnlySpan<byte> content)
    {
        var buffer = VirtualAlloc(null, (nuint)content.Length, 
            AllocationType.MEM_COMMIT | AllocationType.MEM_RESERVE, MemoryProtection.PAGE_READWRITE);

        if (buffer is null)
            Helpers.ThrowLastError();

        content.CopyTo(new Span<byte>(buffer, content.Length));

        if (VirtualProtect(buffer, (uint)content.Length, MemoryProtection.PAGE_EXECUTE_READ, out var _) is 0)
            Helpers.ThrowLastError();

        if (FlushInstructionCache(Helpers.GetCurrentProcess(), buffer, (uint)content.Length) is 0)
            Helpers.ThrowLastError();

        return buffer;
    }
}