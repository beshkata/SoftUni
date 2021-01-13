function fruitMarket([arg1, arg2, arg3, arg4, arg5]){
    let strawberriesPrice = Number(arg1);
    let bananasVolume = Number(arg2);
    let orangesVolume = Number(arg3);
    let raspberriesVolume = Number(arg4);
    let strawberriesVolume = Number(arg5);

    let raspberriesPrice = strawberriesPrice/2;
    let orangesPrice = raspberriesPrice - (raspberriesPrice*0.40);
    let bananasPrice = raspberriesPrice - (raspberriesPrice*0.8);
    let totalSum = bananasVolume*bananasPrice + orangesVolume*orangesPrice + raspberriesVolume*raspberriesPrice +strawberriesVolume*strawberriesPrice;

    console.log(totalSum);
}
fruitMarket(["48",
"10",
"3.3",
"6.5",
"1.7"])//333.12
fruitMarket(["63.5",
"3.57",
"6.35",
"8.15",
"2.5"])//561.1495