namespace Library

open Helpers

[<SolutionModule>]
module Problem5 =

    let solution () =
        printfn "Starting solver"
        printfn "The slow easy way is to keep trying numbers from 20 (counting upwards) until you find one that can be divided by 1-20"
        printfn "
However we quickly realise that our final answer must contain all prime factors that are used to build the numbers 1-20:
    2       (2)
    3       (3)
    2x2     (4)
    5       (5)
    ...
    3x3     (9)
    ...
    2x2x2x2 (16)
    ...
    2x2x5   (20)    
        
Hence we need 2x2x2x2 x 3x3 x 5 x 7 x 11 x 13 x 17 x 19 which is ... "
        let timer = System.Diagnostics.Stopwatch.StartNew()
        
        let ans = 
            2*2*2*2*3*3*5*7*11*13*17*19
        
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %i Elapsed : %i ms" ans elapsed 
       
        ans |> string

    [<Solution(5)>]
    let problem () = {
        Title = "Smallest multiple"
        Description = "
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?"
        Solution = solution }