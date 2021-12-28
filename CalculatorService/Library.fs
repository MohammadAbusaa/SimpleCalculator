namespace CalculatorService

open System

module Calculator =
    let mutable negatives = []
    let comparator (i : string) =
        if int(i) < 0 then
            negatives <- i :: negatives
        int(i)
    let reducer (d : char[]) (s : string) =
        let ints = s.Split(d) |> Array.map (comparator)
        if negatives.Length > 0 then
            raise (FormatException(("Negatives are not allowed! the negatives are:\n" + String.concat "," (negatives |> List.rev))))
        else ints |> Array.reduce (fun a b -> a + b)
    let add (str: string) : int =
        negatives <- List.empty
        if String.IsNullOrEmpty str then
            0
        else if str.StartsWith("//") then
            reducer [|str.[2]|] str.[4..]
        else if String.exists (fun c -> c = ',' || c = '\n') str then
            reducer [|','; '\n'|] str
        else
            int (str)
