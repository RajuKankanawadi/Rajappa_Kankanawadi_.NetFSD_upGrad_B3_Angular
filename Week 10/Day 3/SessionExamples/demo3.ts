// Create TypeScript program to demonstrate Functional parameter types

// 1. Optional parameters
function showDetails(sname: string, course: string, age?: number): void {
    console.log("Name:", sname);
    console.log("Course:", course);

    if (age !== undefined) {
        console.log("Age:", age);
    }
    console.log("------------------");
}


// 2. Default parameter
function getTotal(price: number, qty: number = 1): void {
    let total: number = price * qty;

    let str: string = `Unit Price: ${price}, Quantity: ${qty}, Total Amount: ${total}`;
    console.log(str);
    console.log("------------------");
}


// 3. Rest parameter
function sum2(...ar: number[]): void {
    let sum: number = 0;

    for (let value of ar) {   
        sum += value;
    }

    console.log("Sum Result:", sum);
    console.log("------------------");
}


// Function Calls
console.log("Program Started\n");

showDetails("Scott", "Angular", 20);
showDetails("Smitha", "NodeJS");

getTotal(2500, 3);
getTotal(2500);

sum2(10);
sum2(10, 20, 70);
sum2(10, 20, 40, 50, 60, 70);
sum2(10, 20);
sum2(10, 20, 30, 40, 50, 60, 70, 80, 90);