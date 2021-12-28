module CalculatorService.Tests

open NUnit.Framework
open CalculatorService

[<Test>]
let ``Test empty strings to return 0`` () =
    let expected = 0
    let actual = Calculator.add("")
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test one number string to return the same integer value`` () =
    let mutable expected = 25
    let mutable actual = Calculator.add("25")
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 16
    actual <- Calculator.add "16"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 255
    actual <- Calculator.add "255"
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``Test two number string to return the integer value of their summation`` () =
    let mutable expected = 13
    let mutable actual = Calculator.add("7,6")
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 10
    actual <- Calculator.add "0,10"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 20
    actual <- Calculator.add "9,11"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 200
    actual <- Calculator.add "100,100"
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test more than two numbers to return the integer value of their summation`` () =
    let mutable expected = 210
    let mutable actual = Calculator.add "10,20,30,40,50,60"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 300
    actual <- Calculator.add "10,20,70,100,100"
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test newline as another separator`` () =
    let mutable expected = 940
    let mutable actual = Calculator.add "1\n2\n500,400\n37"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 22
    actual <- Calculator.add "5,10\n1\n2\n3\n1"
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test different delimiters to be supported`` () =
    let mutable expected = 15
    let mutable actual = Calculator.add "//;\n1;2;3;4;5"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 20
    actual <- Calculator.add "//d\n2d4d6d8"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 50
    actual <- Calculator.add "1,3\n5\n7\n9,25"
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test throwing an exception when sending negative numbers`` () =
    Assert.Throws<System.FormatException>((fun _ -> Calculator.add "1,2,-3,-4,-5,-6" |> ignore), "Negatives are not allowed! the negatives are:\n-3,-4,-5,-6") |> ignore
    Assert.Throws<System.FormatException>((fun _ -> Calculator.add "//$\n1$2$-39$-40$-53$-26" |> ignore), "Negatives are not allowed! the negatives are:\n-39,-40,-53,-26") |> ignore

[<Test>]
let ``Test numbers bigger than 1000 to be ignored`` () =
    let mutable expected = 2
    let mutable actual = Calculator.add "2,1001"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 1001
    actual <- Calculator.add "1001,2000,3000,500,500,1"
    Assert.That(actual, Is.EqualTo(expected))