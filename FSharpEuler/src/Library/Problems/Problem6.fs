namespace Library

open Helpers

[<SolutionModule>]
module Problem6 =

    let solution () =
        printfn "Starting solver"
        printfn "Calculating using the Euler formula for sum of 1 to N = n * (n+1) / 2 :"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let squareOfSum = sumOfOneTo >> (fun x -> x * x)
        let sumOfSquares n = 
            { 1 .. n }
            |> Seq.map (fun x -> x * x)
            |> Seq.sum

        let a = sumOfSquares 100
        let b = squareOfSum 100
        
        printfn "Sum of Squares 1-100: %d" a
        printfn "Square of sum 1-100: %d" b
        
        let ans = b - a

        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %i Elapsed : %i ms" ans elapsed 

        printfn "Could have used the formula for sum of 1 squared to N squared : n * (n+1) * (2n + 1) / 6 :"
        let firstNSquares n = n * (n+1) * (2*n + 1) / 6
        let b2 = squareOfSum 100

        let a2 = firstNSquares 100
        printfn "First 100 squares : %d" a2
        let elapsed2 = timer.ElapsedMilliseconds - elapsed
        printfn "Answer: %i Elapsed : %i ms" ans elapsed2 

        ans

    [<Solution(6)>]
    let problem () = {
        Title = "Sum square difference"
        Description = "
The sum of the squares of the first ten natural numbers is,

1^2 + 2^2 + ... + 10^2 = 385
The square of the sum of the first ten natural numbers is,

(1 + 2 + ... + 10)^2 = 55^2 = 3025
Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum."
        Solution = solution }