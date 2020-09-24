// Learn more about F# at http://fsharp.org
module ExpectToTemplate
open Expecto
[<EntryPount>]
let main argv =
//Tests.runTestsInAssembly defaultconfig argv - тесты
/*[<Tests>]
let powtest =
    testlist "...."
    [
        testCase ""
        <| fun _ -> Expect.equal pow (0, 0) 1 "CompilerMessageAttribute"
    ]*/

open System

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code


module Main =
    open argu
    type .. =
        | Base of int
        | Pow of int
