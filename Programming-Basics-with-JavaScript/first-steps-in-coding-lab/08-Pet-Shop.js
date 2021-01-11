function petShop([dogNumStr, animalNumStr]){
    let dogNum = Number(dogNumStr);
    let animalNum = Number(animalNumStr);
    console.log(dogNum*2.50 + animalNum*4.0);
}
petShop(["13", "9"]);