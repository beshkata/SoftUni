function charityCampaign([arg1, arg2, arg3, arg4, arg5]){
    let campaignDays = Number(arg1);
    let confectionersCount = Number(arg2);
    let cakeMoneyPerDay = Number(arg3)*45;
    let wafflesMoneyPerDay = Number(arg4)*5.80;
    let pancakesMoneyPerDay = Number(arg5) * 3.20;

    let totalSum = (cakeMoneyPerDay+wafflesMoneyPerDay+pancakesMoneyPerDay)
    *confectionersCount * campaignDays;
    let result = totalSum - (totalSum/8);

    console.log(result);
}
charityCampaign(["23",
"8",
"14",
"30",
"16"])//137687.2
charityCampaign(["131",
"5",
"9",
"33",
"46"])//426175.75
