namespace SPbU_hometask

open System.Reflection
open Solutions


module Main =
    open Argu

    type CLIArguments =
        | Task1 of int
        | Task2 of int
        | Task3 of int * int
        | Task4 of int * int * int
        | Task5
        | Task6 of int * int * int
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Task1 _ -> "Calculating polynomial of x, stupid way, enter x" 
                | Task2 _ -> "Calculating polynomial of x, the fastest way, enter x"
                | Task3 _ -> "Returns array of indices, which elements are not greater than current x, enter length of array n and x"
                | Task4 _ -> "Returns array of indices, which elements are out of range [x; y], enter length of array n and x, y - borders of range"
                | Task5 _ -> "Swaps two elemets of array, length of array equals two" 
                | Task6 _ -> "Swaps two elements of array with indices i, j, length of array equals two, enter n, i, j" 

    [<EntryPoint>]
    let main (argv: string array) =
        try
            let parser = ArgumentParser.Create<CLIArguments>(programName = "SPbU_hometask")
            let results = parser.Parse(argv)
            if results.Contains(Task1) then
                 let arg = results.GetResult(Task1)
                 let result1 = SPbU_hometask.Solutions.sol1 arg
                 printf "%A" result1
            elif results.Contains(Task2) then
                let arg = results.GetResult(Task2)
                let result2 = SPbU_hometask.Solutions.sol1 arg
                printf "%A" result2
            elif results.Contains(Task3) then
                let n, x = results.GetResult(Task3)
                let array = generateArray n
                let result3 = SPbU_hometask.Solutions.sol3 array x
                printf "%A" result3
            elif results.Contains(Task4) then
                let n, x, y = results.GetResult(Task4)
                let array = generateArray n
                let result4  = SPbU_hometask.Solutions.sol4 array x y 
                printf "%A" result4
            elif results.Contains(Task5) then
                let array = generateArray 2
                let result5 = SPbU_hometask.Solutions.sol5 array
                printf "%A" result5
            elif results.Contains(Task6) then
                let n, i, j = results.GetResult(Task6)
                let array = generateArray n
                let result6 = SPbU_hometask.Solutions.sol6 array i j
                printf "%A" result6
            0
        with
        | :? ArguParseException as ex ->
            printfn "%s" ex.Message
            1
