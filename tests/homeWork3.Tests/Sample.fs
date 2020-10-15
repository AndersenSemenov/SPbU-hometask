module Tests

open SPbU_hometask.Solutions
open Expecto

[<Tests>]
let test1 =
  testList "testing Fib1" [
    testCase "function arg 0" <| fun _ ->
        Expect.equal (fib1 0) 0 "Wrong, for arg 0 expected answer is 0"
    testCase "function arg 1" <| fun _ ->
        Expect.equal (fib1 1) 1 "Wrong, for arg 1 expected answer is 1"
    testCase "function arg 11" <| fun _ ->
        Expect.equal (fib1 11) 89 "Wrong, for arg 11 expected answer is 89"
  ]

[<Tests>]
let test2 =
  testList "testing Fib2" [
    testCase "function arg 0" <| fun _ ->
        Expect.equal (fib2 0) 0 "Wrong, for arg 0 expected answer is 0"
    testCase "function arg 2" <| fun _ ->
        Expect.equal (fib2 2) 1 "Wrong, for arg 2 expected answer is 1"
    testCase "function arg 12" <| fun _ ->
        Expect.equal (fib2 12) 144 "Wrong, for arg 12 expected answer is 144"
  ]

[<Tests>]
let test3 =
  testList "testing FibTail3" [
    testCase "function arg 0" <| fun _ ->
        Expect.equal (fibTail3 0) 0 "Wrong, for arg 0 expected answer is 0"
    testCase "function arg 1" <| fun _ ->
        Expect.equal (fibTail3 1) 1 "Wrong, for arg 1 expected answer is 1"
    testCase "function arg 8" <| fun _ ->
        Expect.equal (fibTail3 8) 21 "Wrong, for arg 8 expected answer is 21"
  ]

[<Tests>]
let test4 =
  testList "testing Fib4" [
    testCase "function arg 0" <| fun _ ->
        Expect.equal (fib4 0) 0 "Wrong, for arg 0 expected answer is 0"
    testCase "function arg 4" <| fun _ ->
        Expect.equal (fib4 4) 3 "Wrong, for arg 4 expected answer is 3"
    testCase "function arg 22" <| fun _ ->
        Expect.equal (fib4 22) 17711 "Wrong, for arg 22 expected answer is 17711"
  ]

[<Tests>]
let test5 =
  testList "testing Fib5" [
    testCase "function arg 1" <| fun _ ->
        Expect.equal (fib5 1) 1 "Wrong, for arg 1 expected answer is 1"
    testCase "function arg 3" <| fun _ ->
        Expect.equal (fib5 3) 2 "Wrong, for arg 3 expected answer is 2"
    testCase "function arg 18" <| fun _ ->
        Expect.equal (fib5 18) 2584 "Wrong, for arg 18 expected answer is 2584"
  ]

[<Tests>]
let test6 =
  testList "testing Fib6" [
    testCase "function arg 0" <| fun _ ->
        Expect.equal (fib6 0) [|0|] "Wrong, for arg 0 expected answer is [|0|]"
    testCase "function arg 2" <| fun _ ->
        Expect.equal (fib6 2) [|0; 1; 1|] "Wrong, for arg 2 expected answer is [|0; 1; 1|]"
    testCase "function arg 7" <| fun _ ->
        Expect.equal (fib6 7) [|0; 1; 1; 2; 3; 5; 8; 13|] "Wrong, for arg 7 expected answer is [|0; 1; 1; 2; 3; 5; 8; 13|]"
  ]

[<Tests>]
let props =
    testList "properties, comparing results of functions which counts fib number n" [
        testProperty "Comparing results of fib1 and fib2 functions" <| fun (n:int) ->
            if abs n < 15 then Expect.equal (fib1 (abs n)) (fib2 (abs n)) "Expected equality of functions"
        testProperty "Comparing results of fib2 and fib3 functions" <| fun (n:int) ->
            if abs n < 40 then Expect.equal (fib2 (abs n)) (fibTail3 (abs n)) "Expected equality of functions"
        testProperty "Comparing results of fib4 and fib5 functions" <| fun (n:int) ->
            if abs n < 40 then Expect.equal (fib4 (abs n)) (fib5 (abs n)) "Expected equality of functions"
        testProperty "Comparing results of fib5 and fib6 functions" <| fun (n:int) ->
            if abs n < 40
            then
                let fib6Result = fib6 (abs n)
                Expect.equal (fib5 (abs n)) fib6Result.[(abs n)] "Expected equality of functions"
    ]
