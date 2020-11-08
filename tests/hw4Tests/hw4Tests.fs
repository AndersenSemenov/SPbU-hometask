module hw4Tests

open Expecto
open hw4Solutions

[<Tests>]
let propertiesForSorts =
    testList "properties, comparing results of sort functions with each other & with system sorts" [

        let funcComparingSorts sort1 sort2 structure message = Expect.sequenceEqual (sort1 structure) (sort2 structure) message

        testProperty "Comparing results of bubble sort and quick sort on array"
        <| fun (arr:array<int>) ->  funcComparingSorts bubbleSortArray quickSortArray arr "Bubble sort and quick sort should work equally on array"

        testProperty "Comparing results of bubble sort and system Sort on array"
        <| fun (arr:array<int>) ->  funcComparingSorts bubbleSortArray Array.sort arr "Bubble sort and system sort should work equally on array"

        testProperty "Comparing results of quick sort and system Sort on array"
        <| fun (arr:array<int>) ->  funcComparingSorts quickSortArray Array.sort arr "Quick sort and system sort should work equally on array"

        testProperty "Comparing results of bubble sort and quick sort on list"
        <| fun (lst:list<int>) ->  funcComparingSorts bubbleSortList quickSortList lst "Bubble sort and quick sort should work equally on list"

        testProperty "Comparing results of bubble sort and system sort on list"
        <| fun (lst:list<int>) ->  funcComparingSorts bubbleSortList List.sort lst "Bubble sort and system sort should work equally on list"

        testProperty "Comparing results of quick sort and system sort on list"
        <| fun (lst:list<int>) ->  funcComparingSorts quickSortList List.sort lst "Quick sort and system sort should work equally on list"
    ]

[<Tests>]
let propertiesForPacknUnpack =
    testList "properties controlling whether function of packing & unpacking works correct" [
        testProperty "Testing function whick packs & unpacks 2 int32 to int64"
        <| fun (a, b) -> Expect.equal (a, b) (int64ToInt32 (int32ToInt64 a b)) "Smthng went wrong, check your function!"

        testProperty "Testing function whick packs & unpacks 4 int16 to int64"
        <| fun (a:int16, b:int16, c:int16, d:int16) -> Expect.equal (a, b, c, d) (int64ToInt16 (int16ToInt64 a b c d)) "Smthng went wrong, check your function!"
    ]
