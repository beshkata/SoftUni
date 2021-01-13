function birthdayParty([arg]){
    let hallRent = Number(arg);
    let cakePrice = hallRent * 0.2;
    let drinksPrice = cakePrice * 0.55;
    let animatorPrice = hallRent / 3;

    let result = hallRent + cakePrice + drinksPrice + animatorPrice;

    console.log(result);
}
birthdayParty(["2250"]);//3697.5
birthdayParty(["3720"]);//6113.2