open AsmToDelegate.FSharp
open type Iced.Intel.AssemblerRegisters
open System.Threading


let getCycles = asm {
    rdtsc
    shl rdx 32uy
    add rax rdx
    ret
}

printfn $"{getCycles ()}"
