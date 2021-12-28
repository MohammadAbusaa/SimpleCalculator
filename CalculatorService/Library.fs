namespace CalculatorService

open System

module Calculator =
    let mutable negatives = []
    let comparator (i : string) =
        let intVal = int(i)
        if intVal < 0 then
            negatives <- i :: negatives
            intVal
        else if intVal > 1000 then
            0
        else
            int(i)
    let reducer (d : string[]) (s : string) =
        let ints = s.Split(d, StringSplitOptions.TrimEntries) |> Array.map (comparator)
        if negatives.Length > 0 then
            raise (FormatException(("Negatives are not allowed! the negatives are:\n" + String.concat "," (negatives |> List.rev))))
        else ints |> Array.reduce (fun a b -> a + b)
    let add (str: string) : int =
        negatives <- List.empty
        if String.IsNullOrEmpty str then
            0
        else if str.StartsWith("//") then
            let nlIndex = str.IndexOf('\n')
            let firstLine = str.Substring(2, nlIndex - 2)
            if(firstLine.Contains('[') && firstLine.Contains(']')) then
                reducer (firstLine.Split([|'[';']'|])) str.[nlIndex + 1..]
            else
                reducer ([|str.Substring(2,1)|]) str.[4..]
        else if String.exists (fun c -> c = ',' || c = '\n') str then
            reducer [|","; "\n"|] str
        else
            int (str)
