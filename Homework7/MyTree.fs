module MyTree

open MyList

type MyTree<'tValue> =
    | Leaf of 'tValue
    | Node of 'tValue * MyList<MyTree<'tValue>>

let getMax tree =
    let rec _go acc (tree: MyTree<int>) =
        match tree with
        | Leaf value -> max acc value
        | Node (value, tail) ->
            let funcForSubtrees =
                fun innerAcc subTree ->
                    subTree |> _go (max innerAcc acc)
            tail |> fold funcForSubtrees value
    tree |> _go 0

let getAverage tree =
    let rec _go (mainAcc: int * int) (tree: MyTree<int>) =
        let sum, quantity = mainAcc
        match tree with
        | Leaf x -> (sum + x), (quantity+1)
        | Node (x, tail) ->
            let func =
                fun innerAcc subTree ->
                    let currSum, currQuantity = innerAcc
                    subTree |> _go (currSum, currQuantity)
            tail |> fold func ((sum+x), (quantity+1))
    let s, q = _go (0, 0) tree
    (s |> float) / (q |> float)
