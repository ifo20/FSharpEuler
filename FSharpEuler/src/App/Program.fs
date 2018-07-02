// Learn more about F# at http://fsharp.org

open System
open Library

[<EntryPoint>]
let main argv =

    let exists pid = 
        (Map.containsKey pid Problem.Titles)
        && (Map.containsKey pid Problem.Descriptions)
        && (Map.containsKey pid Solution.solvers)

    let display problemId = 
        printfn "%A" Problem.Titles.[problemId]
        printfn "%A" Problem.Descriptions.[problemId]

    let solve problemId = 
        if exists problemId then
            display problemId |> ignore
            let solver = Solution.solvers.[problemId]
            solver()
        else
            printfn "Don't have that yet" |> ignore
            -1

    let rec requestInput () = 
        printfn "Hello World from F#! Enter the number of the problem you wish to solve."
        match Console.ReadLine() |> Int32.TryParse with
        | true, c -> 
            solve c |> ignore
            requestInput ()
        | false, _ -> 
            printfn "That wasn't an integer"
            requestInput ()

    requestInput() |> ignore
    
    0 // return an integer exit code
