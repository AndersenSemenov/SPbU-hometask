open System
open hw6Solutions

[<EntryPoint>]
let main (argv: string array) =
   let inputFilePath1 = Console.ReadLine()
   let inputFilePath2 = Console.ReadLine()
   let outputFilePath = Console.ReadLine()
   let matrix1 = readMatrix inputFilePath1
   let matrix2 = readMatrix inputFilePath2
   let res = listToArrayOfString (matrixMultiply matrix1 matrix2)
   System.IO.File.WriteAllLines ((outputFilePath), res)
   0 
