function scholarship([arg1, arg2, arg3]){
    let income = Number(arg1);
    let averageGrade = Number(arg2);
    let minSalary = Number(arg3);

    let canGetSocialScholarship = false;
    let canGetExellentScholarship = false;
 
    if (averageGrade > 4.50 && income < minSalary) {
        canGetSocialScholarship = true;
    }
    if (averageGrade >= 5.5) {
        canGetExellentScholarship = true;
    }

    let socialScholarship = Math.floor(minSalary * 0.35);
    let exellentScholarship = Math.floor(averageGrade * 25);

    if (canGetSocialScholarship && canGetExellentScholarship) {
        if (socialScholarship > exellentScholarship) {
            canGetExellentScholarship = false;
        }else{
            canGetSocialScholarship = false;
        }
    }
    if (canGetSocialScholarship) {
        console.log(`You get a Social scholarship ${socialScholarship} BGN`);
    }else if (canGetExellentScholarship) {
        console.log(`You get a scholarship for excellent results ${exellentScholarship} BGN`);
    }else{
        console.log("You cannot get a scholarship!");
    }
}
scholarship(["300.00",
"5.65",
"420.00"])

