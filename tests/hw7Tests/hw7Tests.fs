module Tests

open Expecto
open MyList
open MyString
open MyTree

[<Tests>]
let testsPropsForLists =
    testList "expect MyList acts the same way as system" [
        testProperty "Comparing results of Length methods" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                Expect.equal (List.length lst) (lst |> transform |> getLength) "My Length method has to work as system"
        testProperty "Comparing results of Sorts" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                Expect.equal (List.sort lst|> transform) (myListSort (lst |> transform) (fun x y -> x>y)) "My Sort has to work as system"
        testProperty "Comparing results of Map method" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                let a = List.map (fun x -> x+1) lst |> transform
                let b = lst |> transform |> map (fun x -> x+1)
                Expect.equal a b "My Map has to work as system"
        testProperty "Comparing results of Fold method" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                let a = List.fold (fun x y -> x+y) 0 lst
                let b = lst |> transform |> fold (fun x y -> x+y) 0
                Expect.equal a b "My Fold has to work as system"
    ]

[<Tests>]
let testsForMyList =
    testList "testing methods of MyList" [
        testCase "test#1 transformToMyList method"  <| fun _ ->
            let lst = [1; 3; 4] |> transform
            let res = Cons(1, Cons(3, Head(4)))
            Expect.equal lst res "Smth went wrong, expected another list"
        testCase "test#2 transformToMyList method"  <| fun _ ->
            let lst = [0; 5; 2; 6; 19] |> transform
            let res = Cons(0, Cons(5, Cons(2, Cons(6, Head(19)))))
            Expect.equal lst res "Smth went wrong, expected another list"
        testCase "test#1 concat method"  <| fun _ ->
            let lst1 = [1; 3; 4] |> transform
            let lst2 = [2; 2; 2] |> transform
            let res = [1; 3; 4; 2; 2; 2] |> transform
            Expect.equal (concat lst1 lst2) res "Smth went wrong, expected another list"
        testCase "test#2 concat method"  <| fun _ ->
            let lst1 = [4] |> transform
            let lst2 = [3; 2; 1] |> transform
            let res = [4; 3; 2; 1] |> transform
            Expect.equal (concat lst1 lst2) res "Smth went wrong, expected another list"
    ]


[<Tests>]
let testsForMyString =
    testList "testing methods of MyList" [
        testCase "test transformToMyString method"  <| fun _ ->
            let str = "abc" |> transformToMyString
            let res = Cons('a', Cons('b', Head('c')))
            Expect.equal str res "Smth went wrong, expected another list"
        testCase "test myStringConcat method"  <| fun _ ->
            let str1 = "qwe" |> transformToMyString
            let str2 = "rty" |> transformToMyString
            let res = "qwerty" |> transformToMyString
            Expect.equal res (myStringConcat str1 str2) "Smth went wrong, expected another list"
    ]
 
[<Tests>]
let testsForMyTree =
    testList "testing methods of MyTree" [
        testCase "test#1 getMax method"  <| fun _ ->
            let chld = [Leaf(10); Leaf(11); Leaf(19)] |> transform
            let tree = Node(1, chld)
            Expect.equal (getMax tree) 19 "Wrong, expected 19"
        testCase "test#2 getMax method"  <| fun _ ->
            let chld1 = [Leaf(4); Leaf(5)] |> transform
            let chld2 = [Node(2, chld1); Leaf(3)] |> transform
            let tree = (Node(1, chld2))
            Expect.equal (getMax tree) 5 "Wrong, expected 5"
        testCase "test#1 getAverage method"  <| fun _ ->
            let chld = [Leaf(2); Leaf(18)] |> transform
            let tree = Node(1, chld)
            Expect.equal (getAverage tree) 7.0 "Wrong, expected 7.0"
        testCase "test#2 getAverage method"  <| fun _ ->
            let chld1 = [Leaf(4); Leaf(5)] |> transform
            let chld2 = [Node(2, chld1); Leaf(3)] |> transform
            let tree = (Node(1, chld2))
            Expect.equal (getAverage tree) 3.0 "Wrong, expected 3.0"
    ]
