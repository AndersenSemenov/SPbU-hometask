module hw6Tests

open Expecto
open hw6Solutions

[<Tests>]
let testsForMatrixMultiply =
  testList "testing whether the function of bool matrix multiply works in a proper way" [
    testCase "multiply empty on empty" <| fun _ ->
      let matrix1 = new Matrix (0, 0, [])
      let matrix2 = new Matrix (0, 0, [])
      let res = (matrixMultiply matrix1 matrix2).list
      let expected = [] 
      Expect.equal res expected "Wrong, expected empty list"

    testCase "multiply not empty on empty" <| fun _ ->
        let matrix1 = new Matrix (3, 5, [Coordinates(1<_strMatrix>, 2<_columnMatrix>); Coordinates(2<_strMatrix>, 4<_columnMatrix>)])
        let matrix2 = new Matrix (5, 4, [])
        let res = (matrixMultiply matrix1 matrix2).list
        let expected = [] 
        Expect.equal res expected "Wrong, expected empty list"

    testCase "multiply single matrix on some matrix" <| fun _ ->
        let matrix1 = new Matrix (2, 2, [Coordinates(0<_strMatrix>, 0<_columnMatrix>); Coordinates(1<_strMatrix>, 1<_columnMatrix>)])
        let matrix2 = new Matrix (2, 2, [Coordinates(0<_strMatrix>, 0<_columnMatrix>); Coordinates(0<_strMatrix>, 1<_columnMatrix>)])
        let res = List.sort (matrixMultiply matrix1 matrix2).list
        let expected = [Coordinates(0<_strMatrix>, 0<_columnMatrix>); Coordinates(0<_strMatrix>, 1<_columnMatrix>)]
        Expect.equal res expected "Wrong, expected the same list as a list of matrix2"

    testCase "mutiply two random matrices" <| fun _ ->
        let matrix1 = new Matrix (2, 3, [Coordinates(0<_strMatrix>, 0<_columnMatrix>); Coordinates(0<_strMatrix>, 1<_columnMatrix>); Coordinates(1<_strMatrix>, 1<_columnMatrix>)])
        let matrix2 = new Matrix (3, 2, [Coordinates(0<_strMatrix>, 1<_columnMatrix>); Coordinates(1<_strMatrix>, 0<_columnMatrix>); Coordinates(2<_strMatrix>, 0<_columnMatrix>)])
        let res = List.sort (matrixMultiply matrix1 matrix2).list
        let expected = [Coordinates(0<_strMatrix>, 0<_columnMatrix>); Coordinates(0<_strMatrix>, 1<_columnMatrix>); Coordinates(1<_strMatrix>, 0<_columnMatrix>)]
        Expect.equal res expected "Wrong, expected another list of coordinates" 
  ]
