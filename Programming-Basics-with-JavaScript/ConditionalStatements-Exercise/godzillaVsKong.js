function godzillVsKong([arg1, arg2, arg3]){
    let movieBudget = Number(arg1);
    let statistsCount = Number(arg2);
    let clothsPricePerStatist = Number(arg3);

    let decor = movieBudget * 0.1;
    let totalClothsPrice = clothsPricePerStatist * statistsCount;

    if (statistsCount > 150) {
        totalClothsPrice -= totalClothsPrice * 0.1;
    }

    let totalMoviePrice = decor + totalClothsPrice;
    let diff = Math.abs(totalMoviePrice - movieBudget)

    if (totalMoviePrice > movieBudget) {
        console.log("Not enough money!");
        console.log(`Wingard needs ${diff.toFixed(2)} leva more.`)
    }else{
        console.log("Action!");
        console.log(`Wingard starts filming with ${diff.toFixed(2)} leva left.`)
    }
}
godzillVsKong(["9587.88",
"222",
"55.68"])


