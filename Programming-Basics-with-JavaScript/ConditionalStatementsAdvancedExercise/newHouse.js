function newHouse(input){
    let flowerType = input[0];
    let flowerCount = Number(input[1]);
    let budget = Number(input[2]);
    let totalPrice = 0;

    if (flowerType === "Roses") {
        totalPrice = flowerCount * 5;
        
        if (flowerCount > 80) {
            totalPrice *= 0.90;
        }

    } else if (flowerType === "Dahlias"){
        totalPrice = flowerCount * 3.8;
        
        if (flowerCount > 90) {
            totalPrice *= 0.85;
        }

    } else if (flowerType === "Tulips") {
        totalPrice = flowerCount * 2.80;

        if (flowerCount > 80) {
            totalPrice *= 0.85;
        }

    } else if (flowerType === "Narcissus") {
        totalPrice = flowerCount * 3;

        if (flowerCount < 120) {
            totalPrice *= 1.15;
        }

    } else if (flowerType === "Gladiolus") {
        totalPrice = flowerCount * 2.50;

        if (flowerCount < 80) {
            totalPrice *= 1.2;
        }
    }

    let difference = Math.abs(totalPrice - budget);

    if (totalPrice > budget) {
        console.log(`Not enough money, you need ${difference.toFixed(2)} leva more.`);
    } else {
        console.log(`Hey, you have a great garden with ${flowerCount} ${flowerType} and ${difference.toFixed(2)} leva left.`);
    }
}
newHouse(["Dahlias",
    "112",
    "460"])

