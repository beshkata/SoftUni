function sumOfNumbers(start, end){
    let from = Number(start);
    let to = Number(end)

    let result = 0;

    for (let index = from; index <= to; index++) {
        result += index
    }

    console.log(result)
}

sumOfNumbers('1', '5')
sumOfNumbers('-8', '20')