function projectsCreation([name, projectsNum]){
    let projNum = Number(projectsNum);
    console.log(`The architect ${name} will need ${projNum * 3} hours to complete ${projNum} project/s.`);
}
projectsCreation(['Ivan', '5']);