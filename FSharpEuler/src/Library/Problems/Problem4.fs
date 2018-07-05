namespace Library

open Helpers

[<SolutionModule>]
module Problem4 =

    let solution () =
        printfn "Starting solver"
        printfn "The product of two 3-digit numbers must be between 100 x 100 and 999 x 999 i.e. between 10,000 and 998,001 -> 5 or 6 digits"
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

    [<Solution(4)>]
    let problem () = {
        Title = "Largest palindrome product"
        Description = "A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers."
        Solution = solution }