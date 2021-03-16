function invalidNumber([arg1]) {
    let number = Number(arg1);

    if ((number < 100 || number > 200) && number != 0) {
        console.log("invalid")
    } 
}
invalidNumber(["150"])