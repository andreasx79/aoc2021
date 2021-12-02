function getSolutionPart1() {
    var res = [0, 0];
    require('fs').readFileSync('input.txt').toString().trim().split("\n").forEach(x => { let dir = x.split(' ')[0]; let val = parseInt(x.split(' ')[1]); if(dir === 'forward' ) { res[0] += val; } else if (dir === 'down') {res[1] += val;} else {res[1] -= val;}});
    return res[0] * res[1];
}

function getSolutionPart2() {
    var res = [0, 0, 0];
    require('fs').readFileSync('input.txt').toString().trim().split("\n").forEach(x => {let dir = x.split(' ')[0]; let val = parseInt(x.split(' ')[1]);if(dir === 'forward' ) {res[0] += val; res[1] += val * res[2];} else if (dir === 'down') {res[2] += val;} else {res[2] -= val;}});
    return res[0] * res[1];
}

if (process.env.part || "part1" === "part1") {console.log(getSolutionPart1())} else {console.log(getSolutionPart2())}