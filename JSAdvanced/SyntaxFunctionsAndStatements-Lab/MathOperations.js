function mathOperations(num1, num2, operator){
    let firstNum = Number(num1);
    let secondNum = Number(num2);
    let result;
    switch (operator) {
        case '+':
            result = firstNum + secondNum;
            break;
        case '-':
            result = firstNum - secondNum;
            break;
        case '*':
            result = firstNum * secondNum;
            break;
        case '/':
            result = firstNum / secondNum;
            break;
        case '%':
            result = firstNum % secondNum;
            break;
        case '**':
            result = firstNum ** secondNum;
        default:
            break;
    }

    console.log(result)
}

mathOperations(5, 6, '+')
mathOperations(3, 5.5, '*')