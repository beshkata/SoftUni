function roadRadar(speed, area){
    let currentSpeed = Number(speed);
    let allowedSpeed;
    
    switch (area) {
        case 'motorway':
            allowedSpeed = 130;
            break;
        case 'interstate':
            allowedSpeed = 90;
            break;
        case 'city':
            allowedSpeed = 50;
            break;
        case 'residential':
            allowedSpeed = 20;
            break;
    default:
            break;
    }

    
    let status;
    let difference = currentSpeed - allowedSpeed

    if (difference > 0 && difference <= 20) {
        status = 'speeding';
    } else if(difference <= 40){
        status = 'excessive speeding';
    } else{
        status = 'reckless driving';
    }

    if(difference <= 0){
        console.log(`Driving ${currentSpeed} km/h in a ${allowedSpeed} zone`)
    }else{
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`)
    }
}

roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, 'motorway');