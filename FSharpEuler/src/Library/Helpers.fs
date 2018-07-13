namespace Library 

module Helpers = 
    open System.Linq
    open System.Collections

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

    let primesUnderN n = 
        let firstPrime = 2
        let rec buildPrimes candidate startingPrimes =
            if candidate >= n then
                startingPrimes
            else
                let isNotPrime c = 
                    List.exists (fun p -> c % p = 0) startingPrimes
                if isNotPrime candidate then
                    buildPrimes (candidate + 2) startingPrimes
                else
                    buildPrimes (candidate + 2) (candidate::startingPrimes)

        buildPrimes (firstPrime + 1) [ firstPrime ]


    // Builds primes up to n
    let sieveOfEratosthenes (n : int) = 
        let bits = BitArray(n)
        bits.SetAll(true) |> ignore
        let rec buildComposites (bits : BitArray) nextPrime = 
            if nextPrime > n then
                bits
            else
                let limit = n / nextPrime
                seq { 2 .. limit }
                |> Seq.iter (fun m -> bits.Set(nextPrime * m - 1, false)) |> ignore
                buildComposites bits (nextPrime + 1)
                
        let compositeBits = buildComposites bits 2
        
        let slightlyIncorrectSum = 
            seq { 1 .. n } 
            |> Seq.sumBy(fun x -> 
                if compositeBits.Get(x - 1) then
                    bigint x
                else
                    bigint 0
            )
        slightlyIncorrectSum - bigint 1
                