function numberInRange([arg1]) {
    let number = Number(arg1);

    if (number != 0 && number <= 100 && number >= -100) {
        console.log("Yes");
    } else {
        console.log("No");
    }
}
numberInRange(["0"]);
numberInRange(["25"]);
numberInRange(["-25"]);
