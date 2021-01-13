function vacantionBookList([arg1, arg2, arg3]){
    let pagesCount = Number(arg1);
    let pagesPerHour = Number(arg2);
    let daysCount = Number(arg3);

    let totalHours = pagesCount/pagesPerHour;
    let result = totalHours/daysCount;
    console.log(result);
}
vacantionBookList(["212",
"20",
"2"])//5.3
vacantionBookList(["432",
"15",
"4"])//7.2