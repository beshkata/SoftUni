function summerOutfit(input) {
    let temperature = Number(input[0]);
    let timeOfDay = input[1];

    let outFit = "";
    let shoes = "";

    switch (timeOfDay) {
        case "Morning":
            if (temperature <= 18) {
                outFit = "Sweatshirt";
                shoes = "Sneakers";
            } else if (temperature <= 24) {
                outFit = "Shirt";
                shoes = "Moccasins";
            } else {
                outFit = "T-Shirt";
                shoes = "Sandals";
            }
            break;
        case "Afternoon":
            if (temperature <= 18) {
                outFit = "Shirt";
                shoes = "Moccasins";
            } else if (temperature <= 24) {
                outFit = "T-Shirt";
                shoes = "Sandals";
            } else {
                outFit = "Swim Suit";
                shoes = "Barefoot";
            }
            break;

        case "Evening":
            outFit = "Shirt";
            shoes = "Moccasins";
            break;
        default:
            console.log("Inavalid time of the day")
            break;
    }

    console.log(`It's ${temperature} degrees, get your ${outFit} and ${shoes}.`);
}

summerOutfit(["22",
"Afternoon"])

