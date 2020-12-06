open System
open MyList
open MyString
open MyTree

[<EntryPoint>]
let main argv =
    let word1 = "Hello, " |> transformToMyString
    let word2 = "world!" |> transformToMyString
    myStringConcat word1 word2 |> printf"%A"
    0
