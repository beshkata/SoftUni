function sameNumbers(number){
    let num = Number(number);
    let sum = 0;
    let areSame = true; 
    
    while (num > 0) {
        let currentDigit = num % 10;
        num = parseInt(num / 10);
        sum += currentDigit;
        if(currentDigit !== num % 10 && num > 0){
            areSame = false;
        }
    }
    console.log(areSame);
    console.log(sum);    
}

sameNumbers(2222222)