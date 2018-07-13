namespace Library

open Helpers

[<SolutionModule>]
module Problem10 =

    let solution () =
        printfn "Starting solver"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let ans = 
            sieveOfEratosthenes 2000000
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(10)>]
    let problem () = {
        Title = "Summation of primes"
        Description = "
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million."
        Solution = solution }