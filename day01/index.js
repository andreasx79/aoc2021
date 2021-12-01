const fs = require('fs')
function inputDataLinesIntegers(filename="input.txt") {
    return fs.readFileSync(filename).toString().trim().split("\n").map((x)=>parseInt(x))
}

function getSolutionPart1() {
    let input = inputDataLinesIntegers();
    let comp = input.slice();
    comp.unshift(input[0]);

    let val = input.map((val, i) => val > comp[i] ? 1 : 0).reduce((x,y) => x+y);
    
    return val;
}

function getSolutionPart2() {
    let input = inputDataLinesIntegers();
    

    let val = input.slice(0,input.length-3).map((val, i) => input.slice(i, i + 3).reduce((x,y)=>x+y) < input.slice(i + 1, i + 4).reduce((x,y)=>x+y) ? 1 : 0).reduce((x,y) => x+y);
    console.debug(val);
    return val;
}
const part = process.env.part || "part1"
if (part === "part1")
    console.log(getSolutionPart1())
else
    console.log(getSolutionPart2())

module.exports = {
    getSolutionPart1, getSolutionPart2, inputDataLinesIntegers
}