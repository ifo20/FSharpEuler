namespace Library

open Helpers

[<SolutionModule>]
module Problem21 =

    let solution () =
        let timer = System.Diagnostics.Stopwatch.StartNew()
        
        let ans = 
            seq { 1 .. 10000 }
            |> Seq.sumBy (fun i -> if isAmicable i then i else 0)
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 
        ans

    [<Solution(21)>]
    let problem () = {
        Title = "Amicable numbers"
        Description = "
Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000."
        Solution = solution }