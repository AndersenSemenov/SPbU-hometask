module hw4Solutions

open System.IO

let readArray filePath =
    let a = File.ReadAllLines filePath
    let intArr = [|for i in a -> int (i.Trim())|]
    intArr

let readList filePath =
    let a = File.ReadAllLines filePath
    let intList = [for i in a -> int (i.Trim())]
    intList

let write filePath output =
    File.WriteAllText (filePath, output)
    
let writeArray filePath (arr:array<int>) =
    let mutable stringOfArray = ""
    for i = 0 to arr.Length - 1 do 
        stringOfArray <- stringOfArray + string arr.[i] + "\n"
    write filePath stringOfArray

let writeList filepath (lst:list<int>) =
    writeArray filepath (List.toArray lst)

let bubbleSortArray (arr:array<int>) =
    for i = 0 to arr.Length - 1 do
        for j = i + 1 to arr.Length - 1 do
            if arr.[i] > arr.[j]
            then
                let temp = arr.[i]
                arr.[i] <- arr.[j]
                arr.[j] <- temp
    arr

let bubbleSortList (lst:list<int>) =
    let rec _go lst =
        match lst with
        | firstHead :: secondHead :: tail ->
            if firstHead > secondHead
            then
                secondHead :: _go (firstHead :: tail)
            else
                firstHead :: _go (secondHead :: tail)
        | _ -> lst

    let mutable answer = lst
    for i = 0 to answer.Length - 1 do
        answer <- _go answer
    answer

let rec quickSortArray (arr:array<int>) =
    let rec _go (left, right) =
        let mutable i = left
        let mutable j = right
        let pivot = arr.[(i + j) / 2]
        while i < j do
            while arr.[i] < pivot do i <- i + 1
            while arr.[j] > pivot do j <- j - 1
            if i <= j
            then
                let temp = arr.[i]
                arr.[i] <- arr.[j]
                arr.[j] <- temp
                i <- i + 1
                j <- j - 1
        if i < right then _go (i, right)
        if left < j then _go (left, j)
    if arr.Length > 0 then _go (0, arr.Length - 1)
    arr

let quickSortList (lst:list<int>) =
    let rec _go lst =
        match lst with
        | pivot :: tail ->
            let left, right = List.partition (fun x -> x < pivot) tail
            _go left @ (pivot :: _go right)
        | _ -> lst
    _go lst

let int32ToInt64 a b =
    if b >= 0 then (int64 a <<< 32) + int64 b 
    else (int64 (a + 1) <<< 32) + int64 b

let int64ToInt32 (x:int64) =
    int32 (x >>> 32), int32 x

let int16ToInt32 (a:int16) (b:int16) =
    if b >= int16 0 then (int32 a <<< 16) + int32 b
    else (int32 (a + int16 1) <<< 16) + int32 b

let int32ToInt16 (x:int32) =
    int16 (x >>> 16), int16 x

let int16ToInt64 (a:int16) (b:int16) (c:int16) (d:int16) =
    let resab = int16ToInt32 a b
    let rescd = int16ToInt32 c d
    int32ToInt64 resab rescd

let int64ToInt16 (x:int64) =
    let first, second = int64ToInt32 x
    let a, b = int32ToInt16 first
    let c, d = int32ToInt16 second
    a, b, c, d
