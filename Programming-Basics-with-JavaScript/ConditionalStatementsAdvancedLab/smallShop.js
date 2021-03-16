function smallShop([arg1, arg2, arg3]) {
    let product = arg1;
    let sity = arg2;
    let quantity = Number(arg3);

    let productPrice = 0;

    switch (product) {
        case "coffee":
            if (sity === "Sofia") {
                productPrice = 0.50;
            } else if (sity === "Plovdiv") {
                productPrice = 0.40;
            } else {
                productPrice = 0.45;
            }
            break;
        case "water":
            if (sity === "Sofia") {
                productPrice = 0.80;
            } else {
                productPrice = 0.70;
            }
            break;
        case "beer":
            if (sity === "Sofia") {
                productPrice = 1.20;
            } else if (sity === "Plovdiv") {
                productPrice = 1.15;
            } else {
                productPrice = 1.10;
            }
            break;
        case "sweets":
            if (sity === "Sofia") {
                productPrice = 1.45;
            } else if (sity === "Plovdiv") {
                productPrice = 1.30;
            } else {
                productPrice = 1.35;
            }
            break;
        case "peanuts":
            if (sity === "Sofia") {
                productPrice = 1.60;
            } else if (sity === "Plovdiv") {
                productPrice = 1.50;
            } else {
                productPrice = 1.55;
            }
            break;
        default:
            console.log("invalid product")
            break;
    }

    let totalPrice = productPrice * quantity;
    console.log(totalPrice);
}
smallShop(["sweets",
"Sofia",
"2.23"])



