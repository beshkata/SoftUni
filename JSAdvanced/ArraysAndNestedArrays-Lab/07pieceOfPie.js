function pieceOfPie(pieArr, startPie, endPie){
    let result = pieArr.slice(pieArr.indexOf(startPie), pieArr.indexOf(endPie)+1);
    return result;
}

pieceOfPie(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'
)