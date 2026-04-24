
const userName: string = "John";
let age: number = 25; 
const email: string = "john@example.com";
const isSubscribed: boolean = true;


let city = "Bangalore";   
let loginCount = 5;      

let userProfileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;

console.log("User Profile Message:");
console.log(userProfileMessage);


age = age + 1;


let isEligibleForPremium: boolean = age > 18 && isSubscribed;

let isAdult: boolean = age >= 18;


console.log("\nUpdated Details:");
console.log(`Updated Age: ${age}`);
console.log(`City : ${city}`);
console.log(`Login Count : ${loginCount}`);
console.log(`Is Adult: ${isAdult}`);
console.log(`Is Subscribed: ${isSubscribed}`);
console.log(`Eligible for Premium Plan: ${isEligibleForPremium}`);