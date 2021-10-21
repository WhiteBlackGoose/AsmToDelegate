module AsmToDelegate.FSharp.Syntax

open Iced.Intel
open type Iced.Intel.AssemblerRegisters

let inline mov (a : ^a0) (b : ^a1) (asm : ^a when ^a : (member mov : ^a0 * ^a1 -> unit)) =    
    ((^a) : (member mov : ^a0 * ^a1 -> unit) (asm, a, b))

let inline add (a : ^a0) (b : ^a1) (asm : ^a when ^a : (member add : ^a0 * ^a1 -> unit)) =    
    ((^a) : (member add : ^a0 * ^a1 -> unit) (asm, a, b))

let ret (asm : Assembler) =
    asm.ret ()

type AsmBuilder () =
    member private this.Assembler : Assembler = Assembler 64

    member inline this.Yield (m : ^a -> unit when ^a : (member mov : ^a0 * ^a1 -> unit)) =
        m (this.Assembler :> obj :?> ^a)

    member this.Delay(f) = f()

    member this.Zero () =
        ()

    member this.Combine (a, b) =
        this

let asm = AsmBuilder ()

asm {    
    yield (mov rax rcx)
    yield (add rax rdx)
    yield ret
} |> ignore