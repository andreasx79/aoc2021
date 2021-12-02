const { Console } = require('console');
const fs = require('fs')
function inputDataLinesIntegers(filename="input.txt") {
    let input = fs.readFileSync(filename).toString().trim().split("\n").map((x)=> x);
    var res = [0, 0, 0];

    console.debug(input);

    input.forEach(x => {
        let dir = x.split(' ')[0];
        let val = parseInt(x.split(' ')[1]);
        res[dir === 'forward' ? 0 : dir === 'down' ? 1 : 2] += val;
        console.debug(res);
    }
        
        );

    console.debug(res);
    return res;
}

function getSolutionPart1() {
    let input = inputDataLinesIntegers();    
    return input[0] * (input[1] - input[2]);
}

function getSolutionPart2() {
    
}
const part = process.env.part || "part1"

if (part === "part1")
    console.log(getSolutionPart1())
else
    console.log(getSolutionPart2())

module.exports = {
    getSolutionPart1, getSolutionPart2, inputDataLinesIntegers
}