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
                Expect.equal (List.length lst) (lst |> toMyList |> getLength) "My Length method has to work as system"
        testProperty "Comparing results of Sorts" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                Expect.equal (List.sort lst|> toMyList) (sort (lst |> toMyList) (fun x y -> x > y)) "My Sort has to work as system"
        testProperty "Comparing results of Map method" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                let a = List.map (fun x -> x + 1) lst |> toMyList
                let b = lst |> toMyList |> map (fun x -> x + 1)
                Expect.equal a b "My Map has to work as system"
        testProperty "Comparing results of Fold method" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                let a = List.fold (fun x y -> x - y) 1 lst
                let b = lst |> toMyList |> fold (fun x y -> x - y) 1
                Expect.equal a b "My Fold has to work as system"
        testProperty "Comparing results of Concat method" <| fun (lst1:list<int>, lst2:list<int>)->
            if List.length lst1 <> 0 && List.length lst2 <> 0
            then
                let h = [lst1; lst2] |> Seq.ofList
                let a = h |> List.concat |> toMyList
                let b = MyList.concat (lst1 |> toMyList) (lst2 |> toMyList)
                Expect.equal a b "My Concat has to work as system"
        testProperty "Comparing results of Iter method" <| fun (lst:list<int>) ->
            if List.length lst <> 0
            then
                let arr1 = Array.zeroCreate (List.length lst)
                let arr2 = Array.zeroCreate (List.length lst)
                let mutable i = 0
                List.iter(fun x ->
                    arr1.[i] <- x*10
                    i <- i + 1) lst
                i <- 0
                iter (fun x ->
                    arr2.[i] <- x*10
                    i <- i + 1) (lst |> toMyList)
                Expect.equal arr1 arr2 "My Iter has to work as system"
    ]

[<Tests>]
let testsForMyList =
    testList "testing methods of MyList" [
        testCase "test#1 toMyList method"  <| fun _ ->
            let lst = [1; 3; 4] |> toMyList
            let res = Cons(1, Cons(3, Singleton(4)))
            Expect.equal lst res "Smth went wrong, expected another list"
        testCase "test#2 toMyList method"  <| fun _ ->
            let lst = [0; 5; 2; 6; 19] |> toMyList
            let res = Cons(0, Cons(5, Cons(2, Cons(6, Singleton(19)))))
            Expect.equal lst res "Smth went wrong, expected another list"
    ]


[<Tests>]
let testsForMyString =
    testList "testing methods of MyString" [
        testCase "test toMyString method"  <| fun _ ->
            let str = "abc" |> toMyString
            let res = Cons('a', Cons('b', Singleton('c')))
            Expect.equal str res "Smth went wrong, expected another list"
        testCase "test MyString.concat method"  <| fun _ ->
            let str1 = "qwe" |> toMyString
            let str2 = "rty" |> toMyString
            let res = "qwerty" |> toMyString
            Expect.equal res (MyString.concat str1 str2) "Smth went wrong, expected another list"
    ]
 
[<Tests>]
let testsForMyTree =
    testList "testing methods of MyTree" [
        testCase "test#1 getMax method"  <| fun _ ->
            let chld = [Leaf(10); Leaf(11); Leaf(19)] |> toMyList
            let tree = Node(1, chld)
            Expect.equal (getMax tree) 19 "Wrong, expected 19"
        testCase "test#2 getMax method"  <| fun _ ->
            let chld1 = [Leaf(4); Leaf(5)] |> toMyList
            let chld2 = [Node(2, chld1); Leaf(3)] |> toMyList
            let tree = (Node(1, chld2))
            Expect.equal (getMax tree) 5 "Wrong, expected 5"
        testCase "test#1 getAverage method"  <| fun _ ->
            let chld = [Leaf(2); Leaf(18)] |> toMyList
            let tree = Node(1, chld)
            Expect.equal (getAverage tree) 7.0 "Wrong, expected 7.0"
        testCase "test#2 getAverage method"  <| fun _ ->
            let chld1 = [Leaf(4); Leaf(5)] |> toMyList
            let chld2 = [Node(2, chld1); Leaf(3)] |> toMyList
            let tree = (Node(1, chld2))
            Expect.equal (getAverage tree) 3.0 "Wrong, expected 3.0"
    ]
