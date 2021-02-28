function metricConverter([arg1, arg2, arg3]){
    let num = Number(arg1);
    let inputMetric = arg2;
    let outputMetric = arg3;
    let result = 0;

    if (inputMetric === "m") {
        if (outputMetric === "cm") {
            result = num * 100;
        }else if (outputMetric === "mm") {
            result = num * 1000;
        }else{
            result = num;
        }
    }else if (inputMetric === "cm") {
        if (outputMetric === "m") {
            result = num / 100;;
        }else if (outputMetric === "mm") {
            result = num * 10;
        }else {
            result = num;
        }
    }else{
        if (outputMetric === "m") {
            result = num / 1000;
        }else if (outputMetric === "cm") {
            result = num / 10;
        }else {
            result = num;
        }
    }
    console.log(result.toFixed(3));
}
metricConverter(["5.7896","m","mm"])