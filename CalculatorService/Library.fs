namespace CalculatorService

open System

module Calculator =
    let reducer (d : char[]) (s : string) =
        s.Split(d) |> Array.map (fun c -> int(c)) |> Array.reduce (fun a b -> a + b)
    let add (str: string) : int =
        if String.IsNullOrEmpty str then
            0
        else if str.StartsWith("//") then
            reducer [|str.[2]|] str.[3..]
        else if String.exists (fun c -> c = ',' || c = '\n') str then
            reducer [|','; '\n'|] str
        else
            int (str)
