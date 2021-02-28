function timePlus([arg1, arg2]){
    let hour = Number(arg1);
    let min = Number(arg2);

    min += 15;

    if (min >= 60) {
        min -= 60;
        hour ++;
    }

    if (hour === 24) {
        hour = 0;
    }

    if (min < 10) {
        console.log(`${hour}:0${min}`);
    }else{
        console.log(`${hour}:${min}`);
    }
}
timePlus(["12", "49"])