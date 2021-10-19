function aggregateElements(arr){
    let array = Array.from(arr);
    let sum = 0;
    let invSum = 0;
    let str = '';
    for (let i = 0; i < array.length; i++) {
        sum += array[i];
        invSum +=1/array[i];
        str += array[i].toString();
    }
    console.log(sum);
    console.log(invSum);
    console.log(str);
}

aggregateElements([1, 2, 3])
aggregateElements([2, 4, 8, 16])
