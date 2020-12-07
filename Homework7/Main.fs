open System
open MyList
open MyString
open MyTree

[<EntryPoint>]
let main argv =
    let word1 = "Hello, " |> toMyString
    let word2 = "world!" |> toMyString
    MyString.concat word1 word2 |> printf"%A"
    0
