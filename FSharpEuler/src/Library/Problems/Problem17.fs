namespace Library

[<SolutionModule>]
module Problem17 =

    let solution () =
        let timer = System.Diagnostics.Stopwatch.StartNew()
        let hundred = "hundred".Length
        let ``and`` = "and".Length
        let thousand = "onethousand".Length

        printfn "Let's break this down."
        let oneToNine = "onetwothreefourfivesixseveneightnine".Length
        printfn "Let oneToNine = 1-9 = %i letters" oneToNine
        let tenToNineteen = "teneleventwelvethirteenfourteenfifteensixteenseventeeneighteennineteen".Length
        printfn "Let tenToNineteen = 10-19 = %i letters" tenToNineteen
        let ties = "twentythirtyfortyfiftysixtyseventyeightyninety".Length
        printfn "20-99 will includes all the 8 '_ties' (20,30,40..90) ... together these have %i letters" ties
        printfn "as well as, for each '_ties', the numbers 1-9 .... e.g. 21-29, 31-39"
        printfn "That means another 9 (so 10) of each '_ty' + 8 of each oneToNine"
        let twentyToNinetyNine = ties * 10 + 8 * oneToNine
        printfn "Hence 20-99 has %i * 10 + %i * 8 = %i letters" ties oneToNine twentyToNinetyNine
        let oneToNinetyNine = oneToNine + tenToNineteen + twentyToNinetyNine
        printfn "Hence 1-99 has %i letters" oneToNinetyNine

        printfn "Then we have one hundred numbers starting with 'one hundred' then 'one hundred and ...' (1-99)"
        printfn "This occurs 9 times in total (100-199 ... 900-999)"
        let oneToNineHundredAndNinetyNine = 100 * oneToNine + 900 * hundred + (9*99*``and``) + oneToNinetyNine * 10 
        printfn "Then we have 10 lots of these (one for each group of 100) ... so %i letters" oneToNineHundredAndNinetyNine
        printfn "Finally we add 'one thousand' (%i letters)" thousand

        let ans = 
            oneToNineHundredAndNinetyNine + thousand
            |> string
            
        let elapsed = timer.ElapsedMilliseconds
        printfn "Answer: %s Elapsed : %i ms" ans elapsed 

        ans |> string

    [<Solution(17)>]
    let problem () = {
        Title = "Number letter counts"
        Description = "
If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of \"and\" when writing out numbers is in compliance with British usage."
        Solution = solution }