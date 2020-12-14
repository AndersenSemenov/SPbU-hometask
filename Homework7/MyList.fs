module MyList

type MyList<'t> =
    | Singleton of 't
    | Cons of 't * MyList<'t>

let rec iter f lst =
    match lst with
    | Singleton x -> f x
    | Cons (head, tail) ->
        f head
        iter f tail

let rec map f lst =
    match lst with
    | Singleton x -> Singleton(f x) 
    | Cons (head, tail) -> Cons((f head), (map f tail))

let rec fold f acc lst =
    match lst with
    | Singleton x -> f acc x
    | Cons (head, tail) -> fold f (f acc head) tail

let getLength lst =
    fold (fun acc x -> acc+1) 0 lst

let rec concat lst1 lst2  =
    match lst1 with
    | Singleton x -> Cons(x, lst2)
    | Cons(head, tail) -> Cons(head, concat tail lst2)

let rec toMyList lst =
    match lst with
    | [] -> failwith "List can't be empty"
    | [x] -> Singleton x
    | head :: tail -> Cons(head, (toMyList tail))

let sort lst opComp =
    let rec _go lst =
        match lst with
        | Cons(head1, Cons(head2, tail)) ->
            if opComp head1 head2
            then
                Cons(head2, _go (Cons(head1, tail)))
            else
                Cons(head1, _go (Cons(head2, tail)))
        | Cons(head1, Singleton head2) ->
            if opComp head1 head2
            then
                Cons(head2, Singleton head1)
            else
                Cons (head1, Singleton head2)
        | Singleton x -> Singleton x
    let size = getLength lst
    let mutable answer = lst
    for i = 0 to size - 1 do
        answer <- _go answer
    answer
