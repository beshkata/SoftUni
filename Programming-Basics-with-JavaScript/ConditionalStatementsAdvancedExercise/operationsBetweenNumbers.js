function operationBetweenNumbers(input) {
    let firstNumber = Number(input[0]);
    let secondNumber = Number(input[1]);
    let operatorSign = input[2];
    let evenOrOdd = "";
    let result = 0;

    if (secondNumber === 0 && (operatorSign === "/" || operatorSign === "%")) {
        console.log(`Cannot divide ${firstNumber} by zero`);
        return;
    }

    switch (operatorSign) {
        case "+":
            result = firstNumber + secondNumber;

            if (result % 2 === 0) {
                evenOrOdd = "even";
            } else {
                evenOrOdd = "odd";
            }

            console.log(`${firstNumber} ${operatorSign} ${secondNumber} = ${result} - ${evenOrOdd}`)
            break;
        case "-":
            result = firstNumber - secondNumber;

            if (result % 2 === 0) {
                evenOrOdd = "even";
            } else {
                evenOrOdd = "odd";
            }

            console.log(`${firstNumber} ${operatorSign} ${secondNumber} = ${result} - ${evenOrOdd}`)
            break;
        case "*":
            result = firstNumber * secondNumber;

            if (result % 2 === 0) {
                evenOrOdd = "even";
            } else {
                evenOrOdd = "odd";
            }

            console.log(`${firstNumber} ${operatorSign} ${secondNumber} = ${result} - ${evenOrOdd}`);
            break;
        case "/":
            result = firstNumber / secondNumber;
            console.log(`${firstNumber} ${operatorSign} ${secondNumber} = ${result.toFixed(2)}`);
            break;
        case "%":
            result = firstNumber % secondNumber;
            console.log(`${firstNumber} ${operatorSign} ${secondNumber} = ${result}`);
            break;
        default:
            console.log(`Operator ${operatorSign} is invalid`);
            break;
    }
}
operationBetweenNumbers(["112",
"0",
"/"])





