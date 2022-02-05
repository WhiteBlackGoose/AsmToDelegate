module AsmToDelegate.FSharp

open Iced.Intel
open AsmToDelegate

type AsmBuilder () =
    member _.Yield _ = Assembler(bitness = 64)

    [<CustomOperation("rdtsc")>]
    member _.Rdtsc (asm : Assembler) =
        asm.rdtsc()
        asm
    
    [<CustomOperation("shl")>]
    member _.Shl (asm : Assembler, a : AssemblerRegister64, b : byte) =
        asm.shl(a, b)
        asm
    
    [<CustomOperation("mov")>]
    member _.Mov (asm : Assembler, a : AssemblerRegister64, b : int64) =
        asm.mov(a, b)
        asm

    [<CustomOperation("add")>]
    member _.Add (asm : Assembler, a : AssemblerRegister64, b : AssemblerRegister64) =
        asm.add(a, b)
        asm
    
    [<CustomOperation("imul")>]
    member _.Imul (asm : Assembler, a : AssemblerRegister64, b : AssemblerRegister64) =
        asm.imul(a, b)
        asm
    
    [<CustomOperation("ret")>]
    member _.Ret (asm : Assembler) =
        asm.ret()
        asm

    member _.Run (asm : Assembler) =
        let del = asm.ToDelegateUnsafe<int64>()
        del.Invoke
    
        
let asm = AsmBuilder ()
