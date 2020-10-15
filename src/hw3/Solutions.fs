namespace SPbU_hometask

module Solutions =

    let buildingMatrixOne n =
        let result = Array2D.zeroCreate n n
        for i = 0 to n - 1 do
            result.[i, i] <- 1
        result

    let matrixMultiply matrix1 matrix2 =
        let n = Array2D.length1 matrix1
        let m1 = Array2D.length2 matrix1
        let m2 = Array2D.length1 matrix2
        let k = Array2D.length2 matrix2
        if m1 <> m2
        then failwith "Matrices can't be multiplied, size mistake"
            
        let result = Array2D.zeroCreate n k
        for i = 0 to n - 1 do
            for j = 0 to k - 1 do
                for h = 0 to m1 - 1 do
                    result.[i, j] <- result.[i, j] + matrix1.[i, h] * matrix2.[h, j]
        result

    let rec binPow matrix n =
        if n = 0 then buildingMatrixOne 2
        else
            if n % 2 = 0
            then
                let temp = binPow matrix (n / 2)
                matrixMultiply temp temp
            else
                let temp = binPow matrix (n - 1)
                matrixMultiply temp matrix        

    let rec fib1 n =
        if n < 0 
        then failwith "Mistake, N must be positive" 

        match n with
        | 0 -> 0
        | 1 -> 1
        | n -> fib1(n - 1) + fib1(n - 2)

    let fib2 n =
        if n < 0 
        then failwith "Mistake, N must be positive"
            
        let mutable cnt1 = 0
        let mutable cnt2 = 1
        if n = 0 then 0
        elif n = 1 then 1
        else
            for i = 2 to n do
                let temp1 = cnt1
                cnt1 <- cnt2
                cnt2 <- temp1 + cnt2
            cnt2

    let fibTail3 n =

        let rec _go n acc1 acc2 =
            if n = 1 
            then acc2
            else _go (n - 1) (acc2) (acc1 + acc2)

        if n < 0 
        then failwith "Mistake, N must be positive"
        elif n = 0
        then 0
        else _go n 0 1 

    let fib4 n =
        if n < 0
        then failwith "Mistake, N must be positive"
            
        if n = 0 then 0
        elif n = 1 then 1
        else
            let mutable matrix = array2D [ [0; 1]; [1; 1] ]
            let fibMatrix = array2D [ [0; 1]; [1; 1] ]
            for i = 2 to n do
                matrix <- matrixMultiply matrix fibMatrix
            matrix.[0, 1]

    let fib5 n =
        if n < 0
        then failwith "Mistake, N must be positive"
            
        if n = 0 then 0
        else
            let mutable matrix = array2D [ [0; 1]; [1; 1] ]
            let result = binPow matrix n
            result.[0, 1]          
            
    let fib6 n =
        if n < 0 
        then failwith "Mistake, N must be positive"
            
        let ans = Array.zeroCreate (n + 1)
        if n = 0 
        then ans
        elif n = 1
        then
            ans.[1] <- 1
            ans
        else
            ans.[1] <- 1
            for i = 2 to n do
                ans.[i] <- ans.[i - 1] + ans.[i - 2]
            ans

    

