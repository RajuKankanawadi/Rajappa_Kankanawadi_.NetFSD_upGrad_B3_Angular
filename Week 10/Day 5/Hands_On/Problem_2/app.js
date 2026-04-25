"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const student_service_1 = require("./student.service");
const utils_1 = require("./utils");
// Sample Data
const students = [
    { id: 1, name: "raju", marks: 85 },
    { id: 2, name: "amit", marks: 72 },
    { id: 3, name: "sita", marks: 55 },
    { id: 4, name: "john", marks: 30 }
];
// Format Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log((0, utils_1.formatName)(s.name));
});
// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${(0, utils_1.formatName)(s.name)}: ${(0, student_service_1.getGrade)(s.marks)}`);
});
// Average Marks
console.log("\nAverage Marks:", (0, utils_1.calculateAverage)(students));
// Topper
const topper = (0, student_service_1.getTopper)(students);
console.log("\nTopper:", (0, utils_1.formatName)(topper.name), "-", topper.marks);
