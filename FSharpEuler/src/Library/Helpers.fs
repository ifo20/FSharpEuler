namespace Library 

module Helpers = 
    open System.Xml.Schema

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
    
    let firstNPrimes n = 
        let firstPrime = 2
        let rec buildPrimes candidate startingPrimes = 
            if List.length startingPrimes = n then
                startingPrimes
            else
                let isNotPrime c = 
                    List.exists (fun p -> c % p = 0) startingPrimes
                if isNotPrime candidate then
                    buildPrimes (candidate + 2) startingPrimes
                else
                    buildPrimes (candidate + 2) (candidate::startingPrimes)

        buildPrimes (firstPrime + 1) [ firstPrime ]
        
    let nthPrime = firstNPrimes >> List.head