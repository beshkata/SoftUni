function personalTitles([arg1, arg2]){
    let age = Number(arg1);
    let sex = arg2;

    if (age < 16) {
        if (sex === "m") {
            console.log("Master");
        } else {
            console.log("Miss");
        }
    } else {
        if (sex === "m") {
            console.log("Mr.")
        } else {
            console.log("Ms.")
        }
    }
}
personalTitles(["12", "f"]);
personalTitles(["17", "m"]);
personalTitles(["25", "f"]);
personalTitles(["13.5", "m"]);
