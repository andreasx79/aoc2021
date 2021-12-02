const { Console } = require('console');
const fs = require('fs')
function inputDataLinesIntegers(filename="input.txt") {
    let input = fs.readFileSync(filename).toString().trim().split("\n");
    
    return input;
}

function getSolutionPart1() {
    let input = inputDataLinesIntegers();    
    var res = [0, 0];

    input.forEach(x => {
        let dir = x.split(' ')[0];
        let val = parseInt(x.split(' ')[1]);
        if(dir === 'forward' ) {
            res[0] += val;
        } else if (dir === 'down') {
            res[1] += val;
        } else {
            res[1] -= val;
        }
    }
        );
    return res[0] * res[1];
}

function getSolutionPart2() {
    let input = inputDataLinesIntegers();    
    var res = [0, 0, 0];

    input.forEach(x => {
        let dir = x.split(' ')[0];
        let val = parseInt(x.split(' ')[1]);
        if(dir === 'forward' ) {
            res[0] += val;
            res[1] += val * res[2];
        } else if (dir === 'down') {
            res[2] += val;
        } else {
            res[2] -= val;
        }
        
    }
        
        );
    return res[0] * res[1];
}
const part = process.env.part || "part1"

if (part === "part1")
    console.log(getSolutionPart1())
else
    console.log(getSolutionPart2())

module.exports = {
    getSolutionPart1, getSolutionPart2, inputDataLinesIntegers
}