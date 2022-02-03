module AsmToDelegate.FSharp

open Iced.Intel
open AsmToDelegate

let rdtsc = ("rdtsc", obj ())

let shl a b = ("shl", (a, b) :> obj)

let ret = ("ret", obj ())

let mov a b = ("mov", (a, b) :> obj)

let add a b = ("add", (a, b) :> obj)

type AsmBuilder () =
    member _.Yield el = [ el ]

    member _.Delay f = f()

    member _.Combine (a, b) = List.append a b

    member _.Run list =
        let assembler = Assembler(64)
        for name, args in list do
            let requestedTypes, requestedValues =
                let argsType = args.GetType()
                argsType.GenericTypeArguments |> List.ofArray,
                argsType.GetProperties() |> Array.map (fun c -> c.GetValue(args))
            let mis =
                typeof<Assembler>.GetMethods()
                |> Seq.filter (fun mi -> mi.Name = name)
                |> Seq.filter (fun mi ->
                    let miParamTypes =
                        mi.GetParameters()
                        |> Seq.map (fun p -> p.ParameterType)
                        |> List.ofSeq
                    miParamTypes = requestedTypes)
                |> List.ofSeq
            match Seq.tryExactlyOne mis with
            | None -> raise (System.Exception $"Ohno! Found: {mis} for {name}")
            | Some mi -> mi.Invoke(assembler, requestedValues) |> ignore
        let del = assembler.ToDelegateUnsafe<int64>()
        del.Invoke
        
let asm = AsmBuilder ()
