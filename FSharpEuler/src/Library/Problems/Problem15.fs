namespace Library

open Helpers

[<SolutionModule>]
module Problem15 =

    let solution () =
        printfn "Starting solver"
        let timer = System.Diagnostics.Stopwatch.StartNew()
        printfn "In an nxn grid we have to move Down (D) exactly n times and Right (R) exactly n times"
        printfn "Therefore there are a total of 2n moves to be made."
        printfn "There are '2n choose n' ways of putting n 'Downs' into an array of 2n positions."
        printfn "That is, (2n)! / (n! n!) i.e. (n + 1)(n + 2)...(n + n) / n! ways"
        printfn "In the 2x2 case this is 3 x 4 / 2! = 6"
        let ans = 
            (factorial 40) / ( (factorial 20) * (factorial 20) )
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(15)>]
    let problem () = {
        Title = "Lattice paths"
        Description = "
Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

RRDD    RDRD    RDDR

DRRD    DRDR    DDRR

How many such routes are there through a 20×20 grid?"
        Solution = solution }