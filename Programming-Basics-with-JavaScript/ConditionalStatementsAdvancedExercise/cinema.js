function cinema(input) {
    let typeMovie = input[0];
    let totalSeats = Number(input[1]) * Number(input[2]);
    let totalProfit = 0;

    if (typeMovie === "Premiere") {
        totalProfit = totalSeats * 12;
    } else if (typeMovie === "Normal"){
        totalProfit = totalSeats * 7.50;
    } else {
        totalProfit = totalSeats * 5;
    }

    console.log(`${totalProfit.toFixed(2)} leva`);
}
cinema(["Discount",
"12",
"30"])

