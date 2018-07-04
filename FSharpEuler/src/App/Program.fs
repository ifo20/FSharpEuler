// Learn more about F# at http://fsharp.org

open System
open Library

[<EntryPoint>]
let main argv =
    
    let rec requestInput () = 
        printfn "Hello World from F#! Enter the number of the problem you wish to solve."
        match Console.ReadLine() |> Int32.TryParse with
        | true, c -> 
            Solutions.print c |> ignore
            requestInput ()
        | false, _ -> 
            printfn "That wasn't an integer"
            requestInput ()

    requestInput() |> ignore
    
    0 // return an integer exit code
