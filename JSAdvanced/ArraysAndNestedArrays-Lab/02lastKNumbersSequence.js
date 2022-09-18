function lastKNumbersSequence(n, k){
    let result = [1];
    
    for(let i = 0; i < first - 1; i++){
        let sum = 0;
        for(let j = 0; j < second; j++){
            if(typeof result[i-j] !==  'undefined'){
                sum += result[i-j];
            }
        }
        result.push(sum);
    }

    return result;
}

lastKNumbersSequence(6, 3);
lastKNumbersSequence(8, 2);