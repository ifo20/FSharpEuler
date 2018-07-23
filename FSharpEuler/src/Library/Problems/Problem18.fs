namespace Library

open Helpers

[<SolutionModule>]
module Problem18 =
    open System

    let solution () =
        let timer = System.Diagnostics.Stopwatch.StartNew()
        
        printfn "We will start from the bottom of the triangle, go across each row, pretending momentarily that that element is the top of the triangle."
        printfn "We will then compute the maximum total from that element to the bottom of the triangle."
        printfn "To 'compute' this total we can simply add the 'top' element to the greater of the two elements below"

        let triangle = "
75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23"

        let numberTriangle = 
            triangle.Split([|"\r\n"|], StringSplitOptions.RemoveEmptyEntries)
            |> Array.map (fun a -> 
                a.Split(' ')
                |> Array.map Convert.ToInt32 )

        let workings = 
            numberTriangle
            |> Array.reduceBack (fun tops bottoms ->
                tops
                |> Array.mapi (fun i v ->
                    v + max bottoms.[i] bottoms.[i+1] ))

        let ans = 
            workings.[0]
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(18)>]
    let problem () = {
        Title = "Lattice paths"
        Description = "
By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

3
7 4
2 4 6
8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)"
        Solution = solution }