namespace CalculatorService

open System

module Calculator =
    let add (str: string) : int =
        if String.IsNullOrEmpty str then
            0
        else if String.exists (fun char -> char = ',') str then
            let index = str.IndexOf ','
            let firstNumber = str.[0..index - 1]
            let secondNumber = str.[index + 1..]
            int (firstNumber) + int (secondNumber)
        else
            int (str)
