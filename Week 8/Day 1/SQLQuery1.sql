CREATE DATABASE ContactDB;

USE ContactDB;

CREATE TABLE Company (
    CompanyId INT IDENTITY PRIMARY KEY,
    CompanyName NVARCHAR(100)
);

CREATE TABLE Department (
    DepartmentId INT IDENTITY PRIMARY KEY,
    DepartmentName NVARCHAR(100)
);

CREATE TABLE ContactInfo (
    ContactId INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    EmailId NVARCHAR(100),
    MobileNo BIGINT,
    Designation NVARCHAR(50),
    CompanyId INT,
    DepartmentId INT,
    FOREIGN KEY (CompanyId) REFERENCES Company(CompanyId),
    FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);


INSERT INTO Company VALUES ('TCS'), ('Infosys');

INSERT INTO Department VALUES ('HR'), ('IT');

INSERT INTO ContactInfo
(FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES
('Rajappa', 'Kankanawadi', 'rajappa@gmail.com', 9876543210, 'Software Developer', 1, 2);

INSERT INTO ContactInfo
(FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES
('Amit', 'Sharma', 'amit@gmail.com', 9988776655, 'HR Executive', 2, 1);

INSERT INTO ContactInfo
(FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES
('Priya', 'Patil', 'priya@gmail.com', 9123456780, 'Team Lead', 1, 2);

INSERT INTO ContactInfo
(FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
VALUES
('Sneha', 'Joshi', 'sneha@gmail.com', 9012345678, 'Recruiter', 2, 1);

SELECT  * FROM Company;
SELECT * FROM Department;
SELECT * FROM ContactInfo;