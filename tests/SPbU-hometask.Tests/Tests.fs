namespace SPbU_hometask


module Tests =
    open Expecto
    open SPbU_hometask
    open Solutions
    
    [<Tests>]
    let test1 =
        testList "Task1" [
            testCase "0 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol1 0 
                 Expect.equal result 1 "Wrong answer, expected 1!"
            testCase "1 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol1 1 
                 Expect.equal result 5 "Wrong answer, expected 5!"
            testCase "10 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol1 10
                 Expect.equal result 11111 "Wrong answer, expected 11111!"
            testCase "-10 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol1 -10 
                 Expect.equal result 9091 "Wrong answer, expected 9091!"
        ]
    [<Tests>]
    let test2 =
        testList "Task2" [
            testCase "0 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol2 0 
                 Expect.equal result 1 "Wrong answer, expected 1!"
            testCase "1 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol2 1 
                 Expect.equal result 5 "Wrong answer, expected 5!"
            testCase "10 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol2 10
                 Expect.equal result 11111 "Wrong answer, expected 11111!"
            testCase "-10 check"  <| fun _ ->
                 let result = SPbU_hometask.Solutions.sol2 -10 
                 Expect.equal result 9091 "Wrong answer, expected 9091!"
        ]
    [<Tests>]
    let test3 =
        testList "Task3" [
            testCase "first test"  <| fun _ ->
                  let result = SPbU_hometask.Solutions.sol3 [|10; -3; 5; 7|] 1
                  Expect.equal result [|1|] "Wrong answer, expected [|1|]!"
            testCase "second test"  <| fun _ ->
                  let result = SPbU_hometask.Solutions.sol3 [|10; 12; 13|] -1
                  Expect.equal result [||] "Wrong answer, expected [||]!"
            testCase "third "  <| fun _ ->
                  let result = SPbU_hometask.Solutions.sol3 [|1; 2; 3; 4|] 19
                  Expect.equal result [|0; 1; 2; 3|] "Wrong answer, expected [|0; 1; 2; 3|]!"
        ]
    [<Tests>]
    let test4 =
        testList "Task4" [
            testCase "first test" <| fun _ ->
                let result = SPbU_hometask.Solutions.sol4 [|10; -3; 5; 7|] 2 6
                Expect.equal result [|0; 1; 3|] "Wrong answer, expected [|0; 1; 3|]!"
            testCase "second test" <| fun _ ->
                let result = SPbU_hometask.Solutions.sol4 [|2; 4; 6|] 2 6
                Expect.equal result [||] "Wrong answer, expected [||]!"
            testCase "third test" <| fun _ ->
                let result = SPbU_hometask.Solutions.sol4 [|10; 33|] 2 6
                Expect.equal result [|0; 1|] "Wrong answer, expected [|0; 1|]!"
        ]
    [<Tests>]
    let test5 =
        testList "Task5" [
            testCase "first test" <| fun _ ->
                let result = SPbU_hometask.Solutions.sol5 [|-7; 1|] 
                Expect.equal result [|1; -7|] "Wrong answer, expected [|1; -7|]!"
            testCase "second test" <| fun _ ->
                let result = SPbU_hometask.Solutions.sol5 [|2; 4; |]
                Expect.equal result [|4; 2|] "Wrong answer, expected [|4; 2|]!"
        ]
    [<Tests>]
    let test6 =
        testList "Task6" [
            testCase "first test" <| fun _ ->
                let result = SPbU_hometask.Solutions.sol6 [|10; 222; 31|] 1 2
                Expect.equal result [|10; 31; 222|] "Wrong answer, expected [|10; 31; 222|]!"
            testCase "second test" <| fun _ ->
                let result = SPbU_hometask.Solutions.sol6 [|2; 4; 6|] 10 15
                Expect.equal result [|2; 4; 6|] "Wrong answer, expected [|4; 2|]!"
        ]

