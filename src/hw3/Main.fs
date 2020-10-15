namespace SPbU_hometask

open System.Reflection
open Solutions


module Main =
    open Argu

    type CLIArguments =
        | Task1 of int
        | Task2 of int
        | Task3 of int
        | Task4 of int
        | Task5 of int
        | Task6 of int
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | Task1 _ -> "Calculating fibonacci n number by recursion, enter n" 
                | Task2 _ -> "Calculating fibonacci n number iteratively, enter n"
                | Task3 _ -> "Calculating fibonacci n number by tail recursion, enter n"
                | Task4 _ -> "Calculating fibonacci n number by matrices, asymptotic of algorithm O(n), enter n"
                | Task5 _ -> "Calculating fibonacci n number by matrices, asymptotic of algorithm O(log n), enter n" 
                | Task6 _ -> "Calculating fibonacci n number iteratively, saving all elements of sequence, enter n" 

    [<EntryPoint>]
    let main (argv: string array) =
        try
            let parser = ArgumentParser.Create<CLIArguments>(programName = "SPbU_hometask")
            let results = parser.Parse(argv)
            if results.Contains(Task1) then
                 let arg = results.GetResult(Task1)
                 let result1 = SPbU_hometask.Solutions.fib1 arg
                 printf "%A" result1
            elif results.Contains(Task2) then
                let arg = results.GetResult(Task2)
                let result2 = SPbU_hometask.Solutions.fib2 arg
                printf "%A" result2
            elif results.Contains(Task3) then
                let arg = results.GetResult(Task3)
                let result3 = SPbU_hometask.Solutions.fibTail3 arg
                printf "%A" result3
            elif results.Contains(Task4) then
                let arg = results.GetResult(Task4)
                let result4 = SPbU_hometask.Solutions.fib4 arg
                printf "%A" result4
            elif results.Contains(Task5) then
                let arg = results.GetResult(Task5)
                let result5 = SPbU_hometask.Solutions.fib5 arg
                printf "%A" result5
            elif results.Contains(Task6) then
                let arg = results.GetResult(Task6)
                let result6 = SPbU_hometask.Solutions.fib6 arg
                printf "%A" result6
            0
        with
        | :? ArguParseException as ex ->
            printfn "%s" ex.Message
            1
