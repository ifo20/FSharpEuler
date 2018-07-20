namespace Library

open Helpers

[<SolutionModule>]
module Problem14 =

    let solution () =
        printfn "Starting solver  - this solution is yet to be written"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        
        printfn "We gradually build an array of length n showing how many steps are required to step from a number n back to 1."
        printfn "The first two are trivial: 1 takes 0 steps, 2 takes 1 step."
        printfn "E.g. for n = 3, this sequence is 3 => 10 => 5 => 16 => 8 => 4 => 2 => 1"
        printfn "This means that 3 requires 7 steps. However, we didn't need to do the last step. We have already figured out that 2 is 1 step from completion"
        printfn "Therefore we say that n = 3 took 6 steps to reach 2, and we previously calculated n = 2 as 1 step, so 3 is 6 + 1 = 7 steps"
        printfn "We use this logic to save a lot of time re-calculating previous sequences"

        let thisN = 999999
        let stepCountArray = Array.init thisN (fun _ -> 1)

        let collatz n =
            if n % 2L = 0L then
                n / 2L
            else
                3L*n + 1L
        
        let countCollatzStep s =
            let rec innerCollatz initial current count = 
                if current = 1L then
                    count
                else
                    match collatz current with
                    | i when i < initial -> count + 1 + stepCountArray.[(int i)-1]
                    | j -> innerCollatz initial j (count + 1)
            innerCollatz s s 0

        let _ = 
            seq { 1 .. thisN }
            |> Seq.map (fun s -> 
                let b = int64 s
                let x = countCollatzStep b
                Array.set stepCountArray (s-1) x |> ignore
            )
            |> List.ofSeq
            

        let ans = 
            stepCountArray 
            |> Array.mapi (fun i x -> i + 1, x)
            |> Array.maxBy snd
            |> fst
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(14)>]
    let problem () = {
        Title = "Longest Collatz sequence"
        Description = "
The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million."
        Solution = solution }