"use strict";
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    getSalary() {
        return this.salary;
    }
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
    }
    displayDetails() {
        console.log(`Id: ${this.id}, Name: ${this.name}, Salary: ${this.salary}`);
    }
}
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }
    displayDetails() {
        console.log(`Id: ${this.id}, Name: ${this.name}, Salary: ${this.getSalary()}, Team Size: ${this.teamSize}`);
    }
}
let emp = new Employee(1, "Ramesh", 40000);
let mgr = new Manager(2, "Ravi", 50000, 6);
emp.displayDetails();
mgr.displayDetails();
