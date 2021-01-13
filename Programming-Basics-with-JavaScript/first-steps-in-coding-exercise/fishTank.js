function fishTank([arg1, arg2, arg3, arg4]){
    let fishTankVolumeInLiters = (Number(arg1) * Number(arg2) * Number(arg3))*0.001;
    let result = fishTankVolumeInLiters*((100 - Number(arg4))/100);

    console.log(result);
}
fishTank(["85",
"75",
"47",
"17"])//248.68875
fishTank(["105",
"77",
"89",
"18.5"])//586.445475
