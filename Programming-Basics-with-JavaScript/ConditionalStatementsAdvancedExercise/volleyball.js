function volleyball(input){
    let yearType = input[0];
    let holydaysCount = Number(input[1]);
    let weekendsAtHome = Number(input[2]);

    let totalGames = 0;

    totalGames += (48 - weekendsAtHome) * (3 / 4);
    totalGames += weekendsAtHome;
    totalGames +=  holydaysCount * (2 / 3);

    if (yearType === "leap") {
        totalGames *= 1.15;
    }

    totalGames = Math.floor(totalGames);
    console.log(totalGames);
}
volleyball(["normal",
"6",
"13"])


