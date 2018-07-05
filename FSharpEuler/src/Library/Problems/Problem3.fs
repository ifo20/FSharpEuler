namespace Library

open Helpers

[<SolutionModule>]
module Problem3 =

    let solution () =
        printfn "Starting solver"
        printfn "Finding all prime factors of 600,851,475,143 then taking the largest:"
        let timer = System.Diagnostics.Stopwatch.StartNew()

        let x = 600851475143L
        let ans = 
            primeFactors x
            |> (List.head >> int)

        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %d Elapsed : %i ms" ans elapsed 

        ans

    [<Solution(3)>]
    let problem () = {
        Title = "Largest prime factor"
        Description = "
The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?"
        Solution = solution }