function largestNumber(a, b, c){
    let largest;
    if(a > b){
        if(a > c){
            largest = a;
        }
        else{
            largest = c;
        }
    }
    else{
        if(b > c){
            largest = b;
        }
        else{
            largest = c;
        }
    }

    console.log(`The largest number is ${largest}.`)
}

largestNumber(5, -3, 16)
largestNumber(-3, -5, -22.5)