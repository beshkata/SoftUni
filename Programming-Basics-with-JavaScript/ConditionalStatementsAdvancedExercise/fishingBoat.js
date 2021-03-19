function fishingBoat(input) {
    let budget = Number(input[0]);
    let season = input[1];
    let peopleCount = Number(input[2]);
    let totalPrice = 0;

    switch (season) {
        case "Spring":
            totalPrice = 3000;
            break;
        case "Summer":
        case "Autumn":
            totalPrice = 4200;
            break;
        case "Winter":
            totalPrice = 2600;
            break;
        default:
            console.log("Invalid season!")
            break;
    }

    if (peopleCount <= 6) {
        totalPrice *= 0.9;
    } else if(peopleCount <= 11){
        totalPrice *= 0.85;
    } else {
        totalPrice *= 0.75; 
    }

    if (season !== "Autumn" && peopleCount % 2 === 0) {
        totalPrice *= 0.95
    }

    let difference = Math.abs(totalPrice - budget);

    if (totalPrice > budget) {
        console.log(`Not enough money! You need ${difference.toFixed(2)} leva.`);
    } else {
        console.log(`Yes! You have ${difference.toFixed(2)} leva left.`);
    }
}
fishingBoat(["2000",
"Winter",
"13"])



