function sumFirstLast(arr){
    let sum = Number(arr.shift()) + Number(arr.pop());

    return sum;
}
sumFirstLast(['20', '30', '40']);
sumFirstLast(['5', '10']);