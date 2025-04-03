CREATE DATABASE StudentInfoDB;

Use StudentInfoDB;

CREATE TABLE CourseTB (
	courseId int,
    courseName varchar(250),
    Primary Key(courseId)
);

Create Table YearTB(
     yearId  int,
     yearLvl int,
     Primary Key(yearId)
);

INSERT INTO CourseTB (courseId, courseName)
VALUES (1, "IT"), (2, "BSBA"), (3, "ABEL"), (4, "BPA");

INSERT INTO YearTB (yearId, yearLvl)
VALUES (1, 1), (2, 2), (3, 3), (4, 4);

CREATE TABLE StudentRecordTB(
	studentId int,
    firstName varchar(250),
    lastName varchar(250),
    middleName varchar(250),
    houseNo int,
    brgyName varchar(250),
    municipality varchar(250),
    province varchar(250),
    region varchar(250),
    country varchar(250),
    birthdate varchar(250),
    age int,
    studContactNo varchar(250),
    emailAddress varchar(250),
    guardianFirstName varchar(250),
    guardianLastName varchar(250),
    hobbies varchar(250),
    nickname varchar(250),
    courseId int, 
    yearId int,
    Primary Key (studentId),
    foreign key (courseId) References CourseTB(courseId),
	foreign key (yearId) References YearTB(yearId)
);