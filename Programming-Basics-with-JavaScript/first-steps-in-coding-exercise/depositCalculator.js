function depositCalculator([arg1, arg2, arg3]){
    let moneyCount = Number(arg1);
    let monthsCount = Number(arg2);
    let interest = Number(arg3);

    let interestPerMonth = (moneyCount * (interest/100))/12;
    let totalMoney = moneyCount + interestPerMonth*monthsCount;

    console.log(totalMoney);
}
depositCalculator(["200",
"3",
"5.7"]) //202.85
depositCalculator(["2350",
"6",
"7"])//2432.25

