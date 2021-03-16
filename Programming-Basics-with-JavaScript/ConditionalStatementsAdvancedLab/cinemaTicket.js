function cinemaTicket([arg1]) {
    let dayOfWeek = arg1;

    switch (dayOfWeek) {
        case "Monday":
        case "Tuesday":
        case "Friday":
            console.log(12);
            break;
        case "Wednesday":
        case "Thursday":
            console.log(14);
            break;
        case "Saturday":
        case "Sunday":
            console.log(16);
            break;
        default:
            console.log("wrong day");
            break;
    }
}
cinemaTicket(["Friday"]);
cinemaTicket(["Thursday"]);
cinemaTicket(["Saturday"]);