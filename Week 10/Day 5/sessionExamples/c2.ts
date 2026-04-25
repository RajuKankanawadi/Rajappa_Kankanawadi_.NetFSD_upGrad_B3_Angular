
import * as myMath from './c1.js';
import greet from './c1.js';

console.log("PI  value : " + myMath.PI);
console.log("MAX  value : " + myMath.MAX);

let result  = myMath.add(10,20);
console.log("Add Result : " + result);

result = myMath.sub(25,10);
console.log("Subtract Result  : " + result);

console.log("Default Import method call : " +  greet());