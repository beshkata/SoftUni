function cookingByNumbers(number, operation1, operation2, operation3, operation4, operation5){
    let arr = new Array(operation1, operation2, operation3, operation4, operation5);
    let num = Number(number);

    for (let i = 0; i < arr.length; i++) {
        let operation = arr[i];

        switch (operation) {
            case 'chop':
                num = num / 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num++;
                break;
            case 'bake':
                num = num * 3;
                break;
            case 'fillet':
                num = num - (num / 5);
                break;
            default:
                break;
        }
        console.log(num);
    }
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop')
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet')