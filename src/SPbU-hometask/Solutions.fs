namespace SPbU_hometask

module Solutions =
    let generateArray n =
        let a = Array.zeroCreate n
        let random = System.Random()
        let mutable i = 0
        while i < n do
            a.[i] <- random.Next()
            i <- i + 1
        a
    
    let sol1 x = x * x * x * x + x * x * x + x * x + x + 1
    
    let sol2 x =
        let t = x * x
        (t + 1) * (t + x) + 1
    
    let sol3 (a:array<int>) x =
        let n = a.Length
        let mutable i = 0
        let  mutable size = 0
        while i < n do
            if a.[i] <= x then
               size <- size + 1
            i <- i + 1
        i <- 0
        let ans = Array.zeroCreate size
        let mutable j = 0
        while i < n do
            if a.[i] < x then
                ans.[j] <- i
                j <- j + 1
            i <- i + 1
        ans
    
    let sol4 (a:array<int>) x y =
        if x > y then
            failwith "Wrong range"
        let n = a.Length
        let mutable size = 0
        let mutable i = 0
        while i < n do
            if a.[i] < x || a.[i] > y then
                size <- size + 1
            i <- i + 1
        i <- 0
        let ans = Array.zeroCreate size
        let mutable j = 0
        while i < n do
            if a.[i] < x || a.[i] > y then
                ans.[j] <- i
                j <- j + 1
            i <- i + 1
        ans
    
    
    let sol5 (a:array<int>) =
        a.[0] <- a.[0] + a.[1]
        a.[1] <- a.[1] - a.[0]
        a.[0] <- a.[0] + a.[1]
        a.[1] <- -1 * a.[1]
        a

    let sol6 (a:array<int>) i j =
        if i < 0 || j < 0 || i >= a.Length || j >= a.Length then
            printf "Your indices are out of range, array can't be changed%A"
            a
        else
            a.[i] <- a.[i] + a.[j]
            a.[j] <- a.[j] - a.[i]
            a.[i] <- a.[i] + a.[j]
            a.[j] <- -1 * a.[j]
            printf "Array was successfully changed%A"
            a
