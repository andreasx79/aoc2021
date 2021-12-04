
function inputDataLinesIntegers(filename="input.txt") {
    return require('fs').readFileSync(filename).toString().trim().split("\n");
}
const part = process.env.part || "part1"


function getSolution() {
    let input = inputDataLinesIntegers();

    let numbers = [0,0,0,0,0,0,0,0,0,0,0,0];
    
    input.forEach((val, i) => val.split("").forEach((x, idc) => numbers[idc] += parseInt(x)));
    let gammastr = '';
    let epsStr = '';
    for(let i=0; i<12; i++) {
        if( numbers[i] > input.length/2) {
            gammastr += "1";
            epsStr += "0";
        } else {
            gammastr += "0";
            epsStr += "1";
        }
    }

    if(part === "part1")
        return parseInt(gammastr, 2) * parseInt(epsStr, 2);
    else {
        let gstr = estr = '';
        input = input.sort();

        for (let i = 0; i<12; i++) {
            if(input.filter(x => x.startsWith(gstr)).length === 1) break;
            if(input.filter(x => x.startsWith(gstr + '1')).length >= input.filter(x => x.startsWith(gstr + '0')).length) {
                gstr += '1';
            } else {
                gstr += '0';
            }
        }
        
        for (let i = 0; i<12; i++) {
            if(input.filter(x => x.startsWith(estr)).length === 1) break;
            if(input.filter(x => x.startsWith(estr + '0')).length <= input.filter(x => x.startsWith(estr + '1')).length) {
                estr += '0';
            } else {
                estr += '1';
            }
        }

        return parseInt(gstr, 2) * parseInt(estr, 2);
    }
}

console.log(getSolution());

module.exports = {
    getSolution, inputDataLinesIntegers
}