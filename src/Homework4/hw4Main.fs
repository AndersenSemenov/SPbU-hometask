namespace SPbU_hometask

open hw4Solutions
open System

module Main =
    open Argu

    type CLIArguments =
        | BubbleSortArray
        | BubbleSortList
        | QuickSortArray
        | QuickSortList
        | PacknUnpack32n64
        | PacknUnpack16n64
        | Terekhov'sexperience
        interface IArgParserTemplate with
            member s.Usage =
                match s with
                | BubbleSortArray _ -> "Bubble sort on array, input&output in files" 
                | BubbleSortList _ -> "Bubble sort on list, input&output in files"
                | QuickSortArray _ -> "Quick sort on array, input&output in files"
                | QuickSortList _ -> "Quick sort on list, input&output in files"
                | PacknUnpack32n64 -> "Enter two integers32, packing to integer64 & back"
                | PacknUnpack16n64 -> "Enter four integer16, packing to integers64 & back"
                | Terekhov'sexperience -> "Relax&study"
    [<EntryPoint>]
    let main (argv: string array) =
        try
            let parser = ArgumentParser.Create<CLIArguments>(programName = "SPbU_hometask")
            let results = parser.Parse(argv)
            let sorts someSortFunc inputFunc outputFunc =
                let input = Console.ReadLine() |> string 
                let output = Console.ReadLine() |> string
                let sortedArray = someSortFunc (inputFunc input)
                outputFunc output sortedArray

            if results.Contains BubbleSortArray then sorts bubbleSortArray readArray writeArray
            elif results.Contains BubbleSortList then sorts bubbleSortList readList writeList
            elif results.Contains QuickSortArray then sorts quickSortArray readArray writeArray
            elif results.Contains QuickSortList then sorts quickSortList readList writeList
            elif results.Contains PacknUnpack32n64
            then
                let a = Console.ReadLine() |> int32
                let b = Console.ReadLine() |> int32
                let result = int64ToInt32 (int32ToInt64 a b)
                printf "%A" result
            elif results.Contains PacknUnpack16n64
            then
                let a = Console.ReadLine() |> int16
                let b = Console.ReadLine() |> int16
                let c = Console.ReadLine() |> int16
                let d = Console.ReadLine() |> int16
                let result = int64ToInt16 (int16ToInt64 a b c d)
                printf "%A" result
            elif results.Contains Terekhov'sexperience
            then
                 printf "Ускорил я как-то программу в 1000 раз, а она стала работать не за 10^150, а за 10^147\n"
                 printf "А мораль... думайте сами"
            0
        with
        | :? ArguParseException as ex ->
            printfn "%s" ex.Message
            1
