namespace Library

[<SolutionModule>]
module Problem19 =
    open System

    let solution () =
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let ans = 
            seq { 1901 .. 2000 }
            |> Seq.map (fun y ->
                seq { 1 .. 12 }
                |> Seq.map (fun m ->
                    DateTime(y, m, 1)
                )
                |> Seq.filter (fun d -> d.DayOfWeek = DayOfWeek.Sunday)
            )
            |> Seq.collect id
            |> Seq.length
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(19)>]
    let problem () = {
        Title = "Counting Sundays"
        Description = "
You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?"
        Solution = solution }