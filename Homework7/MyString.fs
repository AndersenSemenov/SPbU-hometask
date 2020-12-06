module MyString
open MyList

type MyString = MyList<char>

let myStringConcat (str1: MyList<char>) (str2: MyList<char>) =
    concat str1 str2

let transformToMyString str =
    let size = String.length str
    if size = 0 then failwith "Incorrect format of string"
    let rec _go acc (str: string) =
        if acc = size - 1 then Head (char str.[acc])
        else Cons(str.[acc], (_go (acc+1) str))
    _go 0 str
