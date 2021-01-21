function toyShop(input){
    let tripPrice = Number(input[0]);
    let puzzelsCount = Number(input[1]);
    let dollsCount = Number(input[2]);
    let bearsCount = Number(input[3]);
    let minionsCount = Number(input[4]);
    let trucksCount = Number(input[5]);

    let totalToysCount = puzzelsCount + dollsCount + bearsCount + minionsCount + trucksCount;
    let totalProfit = (puzzelsCount * 2.60) + (dollsCount * 3) + (bearsCount * 4.10) + 
                    (minionsCount * 8.20) + (trucksCount * 2);
    
    if (totalToysCount >= 50) {
        totalProfit = totalProfit * 0.75;
    }
    totalProfit = totalProfit * 0.90;

    if (totalProfit >= tripPrice) {
        console.log(`Yes! ${(totalProfit - tripPrice).toFixed(2)} lv left.`);
    }else{
        console.log(`Not enough money! ${(tripPrice - totalProfit).toFixed(2)} lv needed.`);
    }

}
toyShop(["320", "8", "2", "5", "5", "1"]);