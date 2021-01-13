function usdToBgn ([arg]){
    let usdCount = Number(arg);
    let result = usdCount * 1.79549;
    
    console.log(result);
}

usdToBgn(["22"]);
usdToBgn(["100"]);
usdToBgn(["12.5"]);