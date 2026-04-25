"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getGrade = getGrade;
exports.getTopper = getTopper;
const constants_1 = require("./constants");
// Get Grade
function getGrade(marks) {
    if (marks >= 75)
        return "A";
    if (marks >= 60)
        return "B";
    if (marks >= constants_1.PASS_MARKS)
        return "C";
    return "Fail";
}
// Get Topper
function getTopper(students) {
    return students.reduce((topper, current) => current.marks > topper.marks ? current : topper);
}
