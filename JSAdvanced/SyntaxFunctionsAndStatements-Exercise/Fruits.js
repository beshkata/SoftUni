function fruits(typeOfFruit, weightInGrams, pricePerKg){
    let weightInKg = Number(weightInGrams) / 1000;
    let totalPrice = weightInKg * Number(pricePerKg);

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${typeOfFruit}.`)
}

fruits('orange', 2500, 1.80)
fruits('apple', 1563, 2.35)