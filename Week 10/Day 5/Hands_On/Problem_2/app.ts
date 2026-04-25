import { Student } from "./student.model";
import { getGrade, getTopper } from "./student.service";
import { formatName, calculateAverage } from "./utils";

// Sample Data
const students: Student[] = [
    { id: 1, name: "raju", marks: 85 },
    { id: 2, name: "amit", marks: 72 },
    { id: 3, name: "sita", marks: 55 },
    { id: 4, name: "john", marks: 30 }
];

// Format Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log(formatName(s.name));
});

// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${formatName(s.name)}: ${getGrade(s.marks)}`);
});

// Average Marks
console.log("\nAverage Marks:", calculateAverage(students));

// Topper
const topper = getTopper(students);
console.log("\nTopper:", formatName(topper.name), "-", topper.marks);