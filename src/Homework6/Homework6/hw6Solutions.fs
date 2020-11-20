module hw6Solutions

open System.IO

[<Measure>] type _strMatrix
[<Measure>] type _columnMatrix

[<Struct>]
type Coordinates =
    val I: int<_strMatrix>
    val J: int<_columnMatrix>
    new(i, j) = { I = i; J = j }

[<Struct>]
type Matrix =
    val N: int
    val M: int
    val list: list<Coordinates>
    new(n, m, lst) = { N = n; M = m; list = lst }

let readMatrix filePath =
    let lines = File.ReadAllLines filePath
    let res =
        [ let mutable i = 0
          for str in lines do
              let mutable j = 0
              for ch in str do
                  if ch = '1' then new Coordinates(i * 1<_strMatrix>, j * 1<_columnMatrix>)
                  j <- j + 1
              i <- i + 1 ]
    let n = lines.Length
    let m = lines.[0].Length
    new Matrix(n, m, res)

let matrixMultiply (matrix1: Matrix) (matrix2: Matrix) =
    if matrix1.M <> matrix2.N then failwith "Wrong sizes, matrix can't be multiplied"
    let lst =
        [ for k in matrix1.list do
            for h in matrix2.list do
                if int (k.J) = int (h.I) then new Coordinates(k.I, h.J) ]
    new Matrix(matrix1.N, matrix2.M, lst)

let listToArrayOfString (matrix: Matrix) =
    let gen = [| for _ in 1 .. matrix.N -> Array.replicate matrix.M '0' |]
    for elem in matrix.list do
        let i = int (elem.I)
        let j = int (elem.J)
        gen.[i].[j] <- '1'
    Array.map (fun (ca: char []) -> new string(ca)) gen
