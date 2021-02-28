function worldSwimmingRecord([arg1, arg2, arg3]){
    let recordInSec = Number(arg1);
    let distanceInMeters = Number(arg2);
    let speedInMetersPerSecond = Number(arg3);

    let totalTime = distanceInMeters * speedInMetersPerSecond;
    let delay = Math.floor(distanceInMeters / 15) * 12.5;

    totalTime += delay;

    let diff = Math.abs(recordInSec - totalTime);

    if (totalTime < recordInSec) {
        console.log(`Yes, he succeeded! The new world record is ${totalTime.toFixed(2)} seconds.`)
    }else{
        console.log(`No, he failed! He was ${diff.toFixed(2)} seconds slower.`)
    }
}
worldSwimmingRecord(["55555.67",
"3017",
"5.03"])

