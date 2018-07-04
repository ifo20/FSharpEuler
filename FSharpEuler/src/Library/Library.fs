namespace Library

open System
open System.Reflection

type Problem = {
    Title : string
    Description : string
    Solution : unit -> int }

[<AllowNullLiteral>]
type SolutionModuleAttribute () =
    inherit Attribute()

[<AllowNullLiteral>]
type SolutionAttribute (problemId : int) = 
    inherit Attribute()
    member __.ProblemId = problemId
  
module Solutions = 
    
    let find () =
        Assembly.GetExecutingAssembly().GetTypes()
        |> Array.filter (fun t -> t.GetCustomAttribute<SolutionModuleAttribute>() |> isNull |> not)
        |> Array.collect (fun t -> t.GetMethods())
        |> Array.choose (fun m ->
            match m.GetCustomAttribute<SolutionAttribute>() with
            | null -> None
            | attribute -> Some (attribute.ProblemId, fun () -> m.Invoke(null, [||]) |> unbox<Problem>))
        |> Map.ofArray

    let print = 
        let slns = find ()
        fun problemId ->
            match slns |> Map.tryFind problemId with
            | Some func ->
                let problem = func ()
                printfn "\nProblem #%d: %s\n" problemId problem.Title
                printfn "%s\n" problem.Description
                let ans = problem.Solution()
                printfn "%d\n" ans
            | None ->
                printfn "Solution for problem %d not found" problemId
