namespace Library

open Helpers

[<SolutionModule>]
module Problem7 =

    let solution () =
        printfn "Starting solver"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let ans = nthPrime 10001
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %i Elapsed : %i ms" ans elapsed 

        ans

    [<Solution(7)>]
    let problem () = {
        Title = "10001st prime"
        Description = "
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?"
        Solution = solution }