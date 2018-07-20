namespace Library

open Helpers

[<SolutionModule>]
module Problem16 =

    let solution () =
        printfn "Starting solver - this solution is yet to be written"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        
        let ans = 
            sieveOfEratosthenes 2000000
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(16)>]
    let problem () = {
        Title = "Power digit sum"
        Description = "
2\u2081\u2075 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number \u2081\u2070\u2070\u2070?"
        Solution = solution }