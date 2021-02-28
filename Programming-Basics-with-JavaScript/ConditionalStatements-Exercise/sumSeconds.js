function sumSeconds([arg1, arg2, arg3]){
    let sumSeconds = Number(arg1) + Number(arg2) + Number(arg3);
    let min = parseInt(sumSeconds / 60);
    let sec = sumSeconds % 60;

    if (sec < 10) {
        console.log(`${min}:0${sec}`);
    } else {
        console.log(`${min}:${sec}`);
    }
}

sumSeconds(["50", "50", 
"49"])

