/*
=========================================
Created by: Ricardo Martinez
Summary: Execute all the script in order
to create the database, tables and 
records to the system. Even you can
execute the script many times is prepared
to be re run many times
=========================================
*/

--USing master db
USE master
GO

--DROP DATABASE IF EXISTS
DROP DATABASE IF EXISTS dbTest
GO

--CREATE NEW DATABASE
CREATE DATABASE dbTest
GO

--USING THE DATABASE DELETED
USE dbTest
GO

--CREATING STUDENT TABLE 
CREATE TABLE Students
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(50) NOT NULL,
    [Phone] CHAR(10) CHECK (Phone LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') NOT NULL,
    [ZipCode] CHAR(5) CHECK (ZipCode LIKE '[0-9][0-9][0-9][0-9][0-9]') NOT NULL
)
GO

--CREATING HOBBY TABLE
CREATE TABLE Hobbies
(
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [Active] BIT NOT NULL
)
GO

--CREATING STUDENTHobbies TABLE
CREATE TABLE StudentHobbies
(
    [StudentId] INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
    [HobbyId] INT FOREIGN KEY REFERENCES Hobbies(Id) NOT NULL,
    PRIMARY KEY([StudentId],[HobbyId])
)
GO

--Adding a Student
INSERT INTO Students([Name],[Email],[Phone],[ZipCode])
SELECT 'Ricardo Martinez', 'ricardom0490@gmail.com', '1234567890','07002'

--ADDING SOME HOBBIES
INSERT INTO Hobbies([Name],[Active])
SELECT 'Music', 1 UNION ALL
SELECT 'Swimming', 1 UNION ALL
SELECT 'Baseball', 1 UNION ALL
SELECT 'Soccer', 1 

--ADDING HOBBIES TO THE STUDENT
INSERT INTO StudentHobbies([StudentId],[HobbyId])
SELECT 1, 1 UNION ALL
SELECT 1, 2 

--SHOWING THE TABLES CREATED AND DATA INSERTED
SELECT * FROM Students
SELECT * from Hobbies
SELECT * FROM StudentHobbies
