function yardGreening([yardSizeStr]){
    let yardSize = Number(yardSizeStr);
    let result = yardSize*7.61 - (yardSize*7.61*0.18);
    console.log(`Final price is: ${result} lv.`);
    console.log(`The discount is: ${yardSize*7.61*0.18} lv.`)
}
yardGreening(["150"]);
