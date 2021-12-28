namespace CalculatorService

open System

module Calculator =
    let add (str: string) : int =
        if String.IsNullOrEmpty str then
            0
        else if String.exists (fun char -> char = ',') str then
            str.Split(',') |> Array.map (fun c -> int(c)) |> Array.reduce (fun a b -> a + b)
        else
            int (str)
