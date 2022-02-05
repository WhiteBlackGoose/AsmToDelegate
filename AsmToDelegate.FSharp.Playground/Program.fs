open AsmToDelegate.FSharp
open type Iced.Intel.AssemblerRegisters
open System.Threading

let getCPUCycles = asm {
    rdtsc
    shl rdx 32uy
    add rax rdx
    ret
}

let cpuCount = getCPUCycles ()
printfn "%i" cpuCount

let ``10 * 30`` = asm {
    mov rdx 10L
    mov rax 30L
    imul rax rdx
    ret
}

printfn "%i" (``10 * 30`` ())