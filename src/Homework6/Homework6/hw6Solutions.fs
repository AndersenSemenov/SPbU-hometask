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
    val numberOfStr: int
    val numberOfCol: int
    val listOfOnesCoordinates: list<Coordinates>
    new(n, m, lst) = { numberOfStr = n; numberOfCol = m; listOfOnesCoordinates = lst }

let readMatrix filePath =
    let lines = File.ReadAllLines filePath
    let n = lines.Length
    let m = lines.[0].Length
    for str in lines do
        if str.Length <> m then failwith "Incorrect format of matrix"
    let res =
        [ let mutable i = 0
          for str in lines do
              let mutable j = 0
              for ch in str do
                  if ch = '1' then new Coordinates(i * 1<_strMatrix>, j * 1<_columnMatrix>)
                  j <- j + 1
              i <- i + 1 ]
    new Matrix(n, m, res)

let matrixMultiply (matrix1: Matrix) (matrix2: Matrix) =
    if matrix1.numberOfCol <> matrix2.numberOfStr then failwith "Wrong sizes, matrix can't be multiplied"
    let lst =
        [ for k in matrix1.listOfOnesCoordinates do
            for h in matrix2.listOfOnesCoordinates do
                if int k.J = int h.I then new Coordinates(k.I, h.J) ]
    new Matrix(matrix1.numberOfStr, matrix2.numberOfCol, lst |> List.distinct)

let listToArrayOfString (matrix: Matrix) =
    let charMatrix = [| for _ in 1 .. matrix.numberOfStr -> Array.replicate matrix.numberOfCol '0' |]
    for elem in matrix.listOfOnesCoordinates do
        let i = int (elem.I)
        let j = int (elem.J)
        charMatrix.[i].[j] <- '1'
    Array.map (fun (ca: char []) -> new string(ca)) charMatrix


let countMatrix inputFilePath1 inputFilePath2 =
    let matrix1 = readMatrix inputFilePath1
    let matrix2 = readMatrix inputFilePath2
    let res = listToArrayOfString (matrixMultiply matrix1 matrix2)
    res

let writeMatrix matrix outputFilePath = 
    System.IO.File.WriteAllLines ((outputFilePath), matrix)
