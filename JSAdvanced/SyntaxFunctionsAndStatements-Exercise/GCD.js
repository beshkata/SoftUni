function gcd(a, b){
    let firstNum = Number(a);
    let secondNum = Number(b);

    while (firstNum % secondNum !== 0) {
        let temp = secondNum;
        secondNum = firstNum % secondNum;
        firstNum = temp;
    }
    console.log(secondNum)
}
gcd(15, 5)