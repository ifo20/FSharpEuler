namespace Library

open Helpers

[<SolutionModule>]
module Problem16 =

    let solution () =
        printfn "Starting solver"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        printfn "2^1000 ~ 1.07e+301 i.e. is a 302-digit number - so we use an array containing 302 ints"
        let arr = 
            Array.init 302 (fun i -> if i = 301 then 1 else 0)
        
        let arrayDoubler a i = 
            let n = Array.length a
            let rec doubleInner (a : int[]) col carryBit = 
                if col < 0 then
                    a
                else
                    if 2 * a.[col] > 9 then
                        Array.set a col (2 * a.[col] - 10 + carryBit) |> ignore
                        doubleInner a (col-1) 1
                    else
                        Array.set a col (2 * a.[col] + carryBit) |> ignore
                        doubleInner a (col-1) 0
            doubleInner a (n-1) 0


        let workings = 
            seq { 1..1000 }
            |> Seq.fold arrayDoubler arr
            |> Array.sum

        let ans = 
            workings
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(16)>]
    let problem () = {
        Title = "Power digit sum"
        Description = "
2\u2081\u2075 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

What is the sum of the digits of the number 2\u2081\u2070\u2070\u2070?"
        Solution = solution }