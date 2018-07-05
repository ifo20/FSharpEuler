namespace Library 

module Helpers = 
    let primeFactors n = 
        let rec breakdown n d fs = 
            if n = 1L then
                fs
            else if n % d = 0L then
                breakdown (n/d) d (d :: fs)
            else
                breakdown n (d+1L) fs

        breakdown n 2L []

    let sumOfOneTo n =
        n * (n + 1) / 2

    let toDigitsArray (n : int) =
        n.ToString().ToCharArray()
        |> Array.map int
    
    let isPalindrome n = 
        let ds = toDigitsArray n
        ds = Array.rev ds 
        