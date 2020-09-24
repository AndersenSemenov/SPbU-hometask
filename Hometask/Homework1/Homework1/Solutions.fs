module Solutions

let generateArray n =
    let a = Array.zeroCreate n
    let random = System.Random()
    let mutable i = 0
    while i < n do
        a.[i] <- random.Next()
        i <- i + 1
    a

let task1 x = x * x * x * x + x * x * x + x * x + x + 1

let task2 x =
    let t = x * x
    (t + 1) * (t + x) + 1

let task3 (a:array<int>) x =
    let n = a.Length
    let mutable i = 0
    while i < n do
        if a.[i] < x then
            printfn "%d" i
        i <- i + 1

let task4 (a:array<int>) x y =
    let mutable i = 0
    let n = a.Length
    while i < n do
        if a.[i] < x || a.[i] > y then
            printf "%d" i
        i <- i + 1


let task5 (a:array<int>) =
    a
