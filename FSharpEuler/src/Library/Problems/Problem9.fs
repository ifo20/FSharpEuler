namespace Library

open Helpers

[<SolutionModule>]
module Problem9 =

    let solution () =
        printfn "Starting solver"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let candidates = seq { 100 ..  999 }
        let ans = 
            [ for a in candidates do
                for b in candidates do
                    yield a * b ]
            |> List.filter isPalindrome
            |> List.max
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %i Elapsed : %i ms" ans elapsed 

        ans

    [<Solution(9)>]
    let problem () = {
        Title = "Special Pythagorean triplet"
        Description = "
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a2 + b2 = c2
For example, 32 + 42 = 9 + 16 = 25 = 52.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc."
        Solution = solution }