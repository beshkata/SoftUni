function onTimeForExam(input) {
    let startHour = Number(input[0]);
    let startMinutes = Number(input[1]);
    let arivalHour = Number(input[2]);
    let arivalMinutes = Number(input[3]);

    let typeOfArival = "";

    let startInMin = startHour * 60 + startMinutes;
    let arivalInMin = arivalHour * 60 + arivalMinutes;

    let difference = arivalInMin - startInMin;

    if (difference < -30) {
        typeOfArival = "Early";
    } else if (difference >= -30 && difference <= 0) {
        typeOfArival = "On time";
    } else {
        typeOfArival = "Late";
    }

    let differenceInHours = "";
    difference = Math.abs(difference);
    if (Math.abs(difference) < 60) {
        differenceInHours = `${difference}`;
    } else {
        let h = `${Math.floor(difference / 60)}`;
        let m = `${difference % 60}`;
        if (difference % 60 < 9) {
            differenceInHours = `${h}:0${m}`
        } else {
            differenceInHours = `${h}:${m}`
        }
    }

    if (typeOfArival === "Early") {
        console.log(typeOfArival);
        if (difference > 59) {
            console.log(`${differenceInHours} hours before the start`)
        } else {
            console.log(`${differenceInHours} minutes before the start`)
        }
    } else if (typeOfArival === "On time") {
        console.log(typeOfArival);
        if (difference !== 0) {
            console.log(`${differenceInHours} minutes before the start`)
        }
    } else {
        console.log(typeOfArival);
        if (difference > 59) {
            console.log(`${differenceInHours} hours after the start`)
        } else {
            console.log(`${differenceInHours} minutes after the start`)
        }
    }
} 
onTimeForExam(["11",
"30",
"12",
"29"])






