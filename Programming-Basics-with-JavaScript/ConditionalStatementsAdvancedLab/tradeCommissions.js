function tradeCommisions([arg1, arg2]) {
    let sity = arg1;
    let profit = Number(arg2);
    let commision = 0;
    let isValidSity = true;

    if (profit < 0) {
        console.log("error");
        return;
    }

    switch (sity) {
        case "Sofia":
            if (profit <= 500) {
                commision = profit * 0.05;
            } else if (profit <= 1000) {
                commision = profit * 0.07;
            } else if (profit <= 10000) {
                commision = profit * 0.08;
            } else {
                commision = profit * 0.12;
            }
            break;
        case "Varna":
            if (profit <= 500) {
                commision = profit * 0.045;
            } else if (profit <= 1000) {
                commision = profit * 0.075;
            } else if (profit <= 10000) {
                commision = profit * 0.1;
            } else {
                commision = profit * 0.13;
            }
            break;
        case "Plovdiv":
            if (profit <= 500) {
                commision =profit *  0.055;
            } else if (profit <= 1000) {
                commision =profit *  0.08;
            } else if (profit <= 10000) {
                commision =profit * 0.12;
            } else {
                commision =profit *  0.145;
            }
            break;
        default:
            console.log("error");
            isValidSity = false;
            break;
    }

    if (isValidSity) {
        console.log(commision.toFixed(2));
    }
}
tradeCommisions(["Kaspichan",
"-50"])


