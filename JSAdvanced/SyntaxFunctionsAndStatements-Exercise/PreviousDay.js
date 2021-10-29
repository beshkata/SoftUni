function previousDay(year, month, day){
    let today = new Date(year, month + 1, day)
    let date = new Date(today.valueOf() - 1000*60*60*24);
    //date.setDate(date.getDate() - 1);
    console.log(`${date.getFullYear()}-${date.getMonth() - 1}-${date.getDate()}`)
    //console.log(date)
}
previousDay(2016, 9, 30)
previousDay(2016, 10, 1)
