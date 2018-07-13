namespace Library

open Helpers

[<SolutionModule>]
module Problem9 =
    
    let solution () =
        printfn "Starting solver"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let ans = 
            printfn "a could be anywhere between 1 and 998. Since a and b are interchangeable, we will take a to be greater than b, to reduce our trial set."
            seq { 1 .. 998 }
            |> Seq.choose (fun a ->
                let candidates = 
                    seq { 1 .. a }
                    |> Seq.choose (fun b ->
                        let c = 1000 - (a + b)
                        if a*a + b*b = c*c then
                            printfn "Found pythag triple with a + b + c = 1,000"
                            printfn "a: %d" a 
                            printfn "b: %d" b
                            printfn "c: %d" c
                            let product = a * b * c
                            printfn "a*b*c = %d" product
                            Some (product)
                        else
                            None
                    )
                    |> List.ofSeq

                match candidates with 
                | [] -> None
                | [rs] -> Some rs
            )
            |> List.ofSeq
            |> List.head

        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %i Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(9)>]
    let problem () = {
        Title = "Special Pythagorean triplet"
        Description = "
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

a\u00B2 + b\u00B2 = c\u00B2
For example, 3\u00B2 + 4\u00B2 = 9 + 16 = 25 = 5\u00B2.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc."
        Solution = solution }