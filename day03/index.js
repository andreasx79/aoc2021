const { connect } = require('http2');

function inputDataLinesIntegers(filename="input.txt") {
    return require('fs').readFileSync(filename).toString().trim().split("\n");
}
const part = process.env.part || "part1"


function getSolution() {
    let input = inputDataLinesIntegers();

    if(part === "part11") {
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
            return parseInt(gammastr, 2) * parseInt(epsStr, 2);

    } else {
        let oxygen = CO2 = '';
        let inputdata = input;

        for (let i = 0; i<12; i++) {
            
            if(inputdata.length === 1) break;
            if(inputdata.filter(x => x.startsWith(oxygen + '1')).length >= inputdata.filter(x => x.startsWith(oxygen + '0')).length) {
                oxygen += '1';
            } else {
                oxygen += '0';
            }
            inputdata = inputdata.filter(x => x.startsWith(oxygen)).sort();
        }
        inputdata = input;
        for (let i = 0; i<12; i++) {
            
            if(inputdata.length === 1) break;
            if(inputdata.filter(x => x.startsWith(CO2 + '0')).length <= inputdata.filter(x => x.startsWith(CO2 + '1')).length) {
                CO2 += '0';
            } else {
                CO2 += '1';
            }
            inputdata = inputdata.filter(x => x.startsWith(CO2)).sort();
        }

        return parseInt(input.filter(x=>x.startsWith(oxygen))[0], 2) * parseInt(input.filter(x=>x.startsWith(CO2))[0], 2);
    }
}

console.log(getSolution());

module.exports = {
    getSolution, inputDataLinesIntegers
}