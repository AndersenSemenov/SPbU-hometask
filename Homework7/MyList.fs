module MyList

type MyList<'t> =
    | Head of 't
    | Cons of 't * MyList<'t>

let getLength lst =
    let rec _go acc lst =
        match lst with
        | Head x -> acc+1
        | Cons (head, tail) -> _go (acc+1) tail
    _go 0 lst

let rec iter f lst =
    match lst with
    | Head x -> f x
    | Cons (head, tail) ->
        f head
        iter f tail

let rec map f lst =
    match lst with
    | Head x -> Head(f x) 
    | Cons (head, tail) -> Cons((f head), (map f tail))

let rec concat lst1 lst2  =
    match lst1 with
    | Head x -> Cons(x, lst2)
    | Cons(head, tail) -> Cons(head, concat tail lst2)

let rec transform lst =
    match lst with
    | [] -> failwith "List can't be empty"
    | [x] -> Head x
    | head :: tail -> Cons(head, (transform tail))

let myListSort lst opComp =
    let rec _go lst =
        match lst with
        | Cons(head1, Cons(head2, tail)) ->
            if opComp head1 head2 then Cons(head2, _go (Cons(head1, tail)))
            else Cons(head1, _go (Cons(head2, tail)))
        | Cons(head1, Head head2) ->
            if opComp head1 head2 then Cons(head2, Head head1)
            else Cons (head1, Head head2)
        | Head x -> Head x
    let size = getLength lst
    let mutable answer = lst
    for i = 0 to size - 1 do
        answer <- _go answer
    answer

let rec fold f acc lst =
    match lst with
    | Head x -> f acc x
    | Cons (head, tail) -> fold f (f acc head) tail
