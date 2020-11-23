open System
open hw6Solutions

[<EntryPoint>]
let main (argv: string array) =
   let inputFilePath1 = Console.ReadLine()
   let inputFilePath2 = Console.ReadLine()
   let outputFilePath = Console.ReadLine()
   let matrix = countMatrix inputFilePath1 inputFilePath2
   writeMatrix matrix outputFilePath
   0 
