function areaOfFigures(input){
    let shape = input[0];

    if (shape === "square") {
        let side = Number(input[1]);
        console.log(`${(side * side).toFixed(3)}`);
    }else if (shape === "rectangle") {
        let sideA = Number(input[1]);
        let sideB = Number(input[2]);
        console.log(`${(sideA * sideB).toFixed(3)}`);
    }else if (shape === "circle") {
        let radius = Number(input[1]);
        console.log(`${(Math.PI * radius * radius).toFixed(3)}`);
    }else{
        let side = Number(input[1]);
        let height = Number(input[2]);
        console.log(`${((side * height)/2).toFixed(3)}`);
    }
}
areaOfFigures(["triangle","4.5","20"]);