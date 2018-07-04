namespace Library

open Helpers

[<SolutionModule>]
module Problem4 =

    let solution () =
        printfn "Starting solver"
        printfn "Easy, slow way: check every number up to 1,000. Add to total if it is divisible by 3 or 5:"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let ans = 
            { 1 .. 999 } 
            |> Seq.filter (fun i -> i % 3 = 0 || i % 5 = 0)
            |> Seq.sum
        
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %i Elapsed : %i ms" ans elapsed 

        printfn "Quick, smart way: Use Euler's formula for sum of integers 1 to N (n(n+1)/2) ... "
        printfn "We want the first 333 multiples of 3 ... plus the first 199 multiples of 5 ... less the first 66 multiples of 15 (as we are double counting multiples of 15)"
        printfn "i.e. 3 times the sum of 1 to 333 ... plus 5 times the sum of 1 to 199 ... less 15 times the sum of 1 to 66"
        timer.Reset()
        let ans2 = 3 * (sumOfOneTo 333) + 5 * (sumOfOneTo 199) - 15 * (sumOfOneTo 66)
        let elapsed2 = timer.ElapsedMilliseconds
        printfn "Answer: %i Elapsed: %d ms" ans2 elapsed2

        ans

    [<Solution(2)>]
    let problem () = {
        Title = "Multiples of 3 and 5"
        Description = "If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
The sum of these multiples is 23.
Find the sum of all the multiples of 3 or 5 below 1000."
        Solution = solution }