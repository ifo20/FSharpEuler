namespace Library
open System
open Helpers

[<SolutionModule>]
module Problem13 =

    let solution () =
        printfn "Starting solver - this solution is yet to be written"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        
        let ans = 
            sieveOfEratosthenes 2000000
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(13)>]
    let problem () = {
        Title = "Longest Collatz sequence"
        Description = "
The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million."
        Solution = solution }