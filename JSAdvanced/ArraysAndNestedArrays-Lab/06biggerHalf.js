function biggerHalf(arr){
    let result = [];
    result = arr.sort((a, b) => a - b).slice(arr.length / 2);
    return result;
}

biggerHalf([4, 7, 2, 5]);
biggerHalf([3, 19, 14, 7, 2, 19, 6]);