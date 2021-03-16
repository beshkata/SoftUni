function skiTrip([arg1, arg2, arg3]) {
    let nights = Number(arg1) - 1;
    let roomType = arg2;
    let grade = arg3;

    let pricePerNight = 0;
    let discount = 0;

    if (roomType === "apartment") {
        pricePerNight = 25;
        if (nights < 10) {
            discount = 0.3;
        } else if (nights <= 15) {
            discount = 0.35;
        } else {
            discount = 0.5;
        }
    } else if (roomType === "president apartment") {
        pricePerNight = 35;
        if (nights < 10) {
            discount = 0.1;
        } else if (nights <= 15) {
            discount = 0.15;
        } else {
            discount = 0.2;
        }
    } else {
        pricePerNight = 18;
    }

    let totalPrice = nights * pricePerNight * (1 - discount);

    if (grade === "positive") {
        totalPrice += totalPrice * 0.25;
    } else {
        totalPrice *= 0.9;
    }

    console.log(totalPrice.toFixed(2));
}
skiTrip(["2",
"apartment",
"positive"])


