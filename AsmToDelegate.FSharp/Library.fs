module AsmToDelegate.FSharp

open Iced.Intel
open AsmToDelegate

type AsmBuilder () =
    member _.Yield _ = []

    [<CustomOperation("rdtsc", MaintainsVariableSpace=true)>]
    member _.Rdtsc (list : (string * obj) list) =
        ("rdtsc", obj ()) :: list
    
    [<CustomOperation("shl", MaintainsVariableSpace=true)>]
    member _.Shl (list : (string * obj) list, a : 'a, b : 'b) =
        ("shl", (a, b) :> obj) :: list
    
    [<CustomOperation("add", MaintainsVariableSpace=true)>]
    member _.Add (list : (string * obj) list, a : 'a, b : 'b) =
        ("add", (a, b) :> obj) :: list
    
    [<CustomOperation("ret", MaintainsVariableSpace=true)>]
    member _.Ret (list : (string * obj) list) =
        ("ret", obj ()) :: list

    member _.Run list =
        let assembler = Assembler(64)
        for name, args in List.rev list do
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
