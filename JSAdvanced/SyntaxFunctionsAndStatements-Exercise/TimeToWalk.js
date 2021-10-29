function timeToWalk(a, b, c){
    let numberOfSteps = Number(a);
    let stepLength = Number(b);
    let speedKmPerH = Number(c);

    let distanceInM = numberOfSteps * stepLength;

    let durationInMin = (distanceInM/1000) / speedKmPerH * 60;

    let rest = parseInt(distanceInM / 500);
    let totalDurationInSek = (durationInMin + rest) * 60;
    let hours = parseInt(totalDurationInSek / 3600);
    let min = parseInt((totalDurationInSek - (hours * 3600)) / 60);
    let sec = Math.ceil((totalDurationInSek - (hours * 3600)) % 60)

    sec = replaceZero(sec);
    min = replaceZero(min);
    hours = replaceZero(hours);
   
    function replaceZero(value){
        if(0 <= value && value <= 9){
            value = '0' + value;
        }
        return value;
    }
    console.log(`${hours}:${min}:${sec}`)
       
}

timeToWalk(4000, 0.60, 5)
timeToWalk(2564, 0.70, 5.5)
