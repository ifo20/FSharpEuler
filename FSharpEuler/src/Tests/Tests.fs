module Tests

open Xunit

open Library
open System.Collections
open System.Collections.Generic

[<AbstractClass>]
type BaseTestData() =
    abstract member data: seq<obj[]>
    interface IEnumerable<obj[]> with
        member this.GetEnumerator() : IEnumerator<obj[]> = this.data.GetEnumerator()
        member this.GetEnumerator() : IEnumerator = this.data.GetEnumerator() :> IEnumerator
 
type MyTestData() =
    inherit BaseTestData()
    override this.data = seq { 18 .. 20 } |> Seq.map (fun s -> [| box s |])


let problemMap = Solutions.find ()
let correctAnswerMap = 
    Map.empty
        .Add(1,"233168")
        .Add(2, "4613732")
        .Add(3, "6857")
        .Add(4, "906609") 
        .Add(5, "232792560")
        .Add(6, "25164150")
        .Add(7, "104743")
        .Add(8, "23514624000")
        .Add(9, "31875000")
        .Add(10, "142913828922")
        .Add(11, "70600674")
        .Add(12, "76576500")
        .Add(13, "5537376230")
        .Add(14, "837799")
        .Add(15, "137846528820")
        .Add(16, "1366")
        .Add(17, "21124")
        .Add(18, "1074")
        .Add(19, "171")
        .Add(20, "648")

let solutionWorks id problem = 
    let calculatedAnswer =
        problem () |> (fun p -> p.Solution ())

    let correctAnswer = 
        match correctAnswerMap.TryFind(id) with 
        | Some a -> a
        | None -> "No answer stored"

    calculatedAnswer = correctAnswer

let solutionSuccessMap = Map.map solutionWorks problemMap

[<Theory>]
[<ClassData(typeof<MyTestData>)>]
let ``Solution x works`` (x) =
    let problem = problemMap.TryFind(x)
    let success = 
        match problem with 
        | Some p -> 
            solutionWorks x (Option.get problem)
        | None -> 
            Assert.True(false, "Problem did not exist") |> ignore
            false
   
    Assert.True(success)

[<Fact (Skip = "Testing problems only individually as too slow otherwise")>]
let ``No failing solutions`` () =
    
    let solutionSuccessMap = Map.map solutionWorks problemMap
    let failingSolutions = Map.filter (fun _ v -> not v) solutionSuccessMap
    
    Assert.Empty(failingSolutions)

