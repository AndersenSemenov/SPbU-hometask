module MyTree

open MyList

type MyTree<'tValue> =
    | Leaf of 'tValue
    | Node of 'tValue * MyList<MyTree<'tValue>>

let rec _go acc func (tree: MyTree<int>) =
    match tree with
    | Leaf x -> func acc x
    | Node (x, tail) -> fold (fun acc1 subTree -> _go acc1 func subTree) (func acc x) tail

let getMax tree =
    _go System.Int32.MinValue (fun x y -> (max x y)) tree

let getAverage tree =  
    let s, q = _go (0, 0) (fun (sum, quantity) x -> (sum+x), (quantity+1)) tree
    (s |> float) / (q |> float)
