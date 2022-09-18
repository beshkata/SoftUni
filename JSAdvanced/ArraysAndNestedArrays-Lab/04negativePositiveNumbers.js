function negativePositiveNumbers(arr){
    let result = [];

    for (let num of arr){
        if(num < 0){
            result.unshift(num);
        }else{
            result.push(num);
        }
    }

    return result;
}
negativePositiveNumbers([7, -2, 8, 9])
negativePositiveNumbers([3, -2, 0, -1])