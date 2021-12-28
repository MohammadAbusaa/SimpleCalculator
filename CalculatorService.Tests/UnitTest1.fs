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
    expected <- -16
    actual <- Calculator.add "-16"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- -255
    actual <- Calculator.add "-255"
    Assert.That(actual, Is.EqualTo(expected))


[<Test>]
let ``Test two number string to return the integer value of their summation`` () =
    let mutable expected = 13
    let mutable actual = Calculator.add("7,6")
    Assert.That(actual, Is.EqualTo(expected))
    expected <- -10
    actual <- Calculator.add "0,-10"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 20
    actual <- Calculator.add "9,11"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 0
    actual <- Calculator.add "100,-100"
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test more than two numbers to return the integer value of their summation`` () =
    let mutable expected = 90
    let mutable actual = Calculator.add "10,20,30,40,50,-60"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- -300
    actual <- Calculator.add "-10,-20,-70,-100,-200,100"
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test newline as another separator`` () =
    let mutable expected = 66
    let mutable actual = Calculator.add "1
    2
    500,-400
    -37"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- -10
    actual <- Calculator.add "5,-10
    -1
    -2
    -3
    1"
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``Test different delimiters to be supported`` () =
    let mutable expected = 15
    let mutable actual = Calculator.add "//;
    1;2;3;4;5"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- -20
    actual <- Calculator.add "//d
    -2d-4d-6d-8"
    Assert.That(actual, Is.EqualTo(expected))
    expected <- 0
    actual <- Calculator.add "1,3
    5
    7
    9,-25"
    Assert.That(actual, Is.EqualTo(expected))