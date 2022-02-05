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

