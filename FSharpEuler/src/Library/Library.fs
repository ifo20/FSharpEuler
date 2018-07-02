namespace Library

module Problem =
    let Titles = 
        Map.empty
            .Add(1, "Title")
            .Add(2, "Title2")

    let Descriptions = 
        Map.empty
            .Add(1, "Desc1")
            .Add(2, "Desc2")

      
module Solution = 
    let solution1 () = 
        printfn "Starting solver"
        let xx = [ 1 ; 2 ; 3 ] |> List.map (fun x -> x * x)
        let y = List.reduce (fun a b -> a + b ) xx
        printfn "%i" y
        123

    let solvers = 
        Map.empty
            .Add(1, solution1)

module Helpers = 
    let isPrime n = 
        n = 2