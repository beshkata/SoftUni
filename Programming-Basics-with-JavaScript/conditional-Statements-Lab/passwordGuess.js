function passwordGuess(input){
    let truePassword = "s3cr3t!P@ssw0rd";
    let inputPassword = input[0];

    if (truePassword === inputPassword) {
        console.log("Welcome");
    } else {
        console.log("Wrong password!");
    }
}
passwordGuess(["s3cr3t!p@ss"]);