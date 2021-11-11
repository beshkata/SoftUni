function wordsUppercase(text){
    let pattern = /\w+/g;
    let arr = text.match(pattern);
    
    console.log(arr.join(', ').toUpperCase())
}

wordsUppercase('Hi, how are you?')