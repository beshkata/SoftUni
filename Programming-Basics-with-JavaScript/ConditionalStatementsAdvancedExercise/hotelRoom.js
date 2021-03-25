function hotelRoom(input) {
    let month = input[0];
    let nightsCount = Number(input[1]);
    let totalPriceApartment = 0;
    let totalPriceStudio = 0;

    switch (month) {
        case "May":
        case "October":
            totalPriceStudio = nightsCount * 50;
            totalPriceApartment = nightsCount * 65;

            if (nightsCount > 7 && nightsCount <= 14) {
                totalPriceStudio *= 0.95;
            } else if (nightsCount > 14) {
                totalPriceApartment *= 0.9;
                totalPriceStudio *= 0.7;
            } 
            break;
        case "June":
        case "September":
            totalPriceStudio = nightsCount * 75.20;
            totalPriceApartment = nightsCount * 68.70;

            if (nightsCount > 14) {
                totalPriceApartment *= 0.9;
                totalPriceStudio *= 0.8;
            }
            break;
        case "July":
        case "August":
            totalPriceStudio = nightsCount * 76;
            totalPriceApartment = nightsCount * 77;

            if (nightsCount > 14) {
                totalPriceApartment *= 0.9;
            }
            break;
        default:
            console.log(`Month ${month} is invalid!`)
            break;
    }

    console.log(`Apartment: ${totalPriceApartment.toFixed(2)} lv.`)
    console.log(`Studio: ${totalPriceStudio.toFixed(2)} lv.`)
}
hotelRoom(["June",
"14"])



