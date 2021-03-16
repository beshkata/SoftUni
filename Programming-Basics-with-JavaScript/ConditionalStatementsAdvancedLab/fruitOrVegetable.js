function fruitOrVegetable([arg1]) {
    let product = arg1;

    switch (product) {
        case "banana":
        case "apple":
        case "kiwi":
        case "cherry":
        case "grapes":
        case "lemon":
            console.log("fruit");
            break;
        case "tomato":
        case "cucumber":
        case "pepper":
        case "carrot":
            console.log("vegetable");
            break;
        default:
            console.log("unknown");
            break;
    }
}
fruitOrVegetable(["banana"]);
fruitOrVegetable(["apple"]);
fruitOrVegetable(["tomato"]);
fruitOrVegetable(["water"]);