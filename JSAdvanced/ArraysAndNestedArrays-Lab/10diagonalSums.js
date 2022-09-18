function diagonalSums(arr){
    let firstSum = 0;
    let secondSum = 0;

    for(let i = 0; i < arr.length; i ++){
        firstSum += arr[i][i];
        secondSum += arr[i][arr.length-1-i];
    }

    console.log(`${firstSum} ${secondSum}`);
}

diagonalSums([
    [3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   );

diagonalSums([
    [20, 40],
    [10, 60]]
   )