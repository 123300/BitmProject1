CREATE DATABASE Project1DB
USE Project1DB

CREATE TABLE Category(
Code INT IDENTITY(1000,1) PRIMARY KEY ,
Name VARCHAR(255) UNIQUE NOT NULL
)

SELECT * FROM Category
DROP TABLE Category

CREATE TABLE Product(
Code INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
Name VARCHAR(255) UNIQUE NOT NULL,
Category VARCHAR(255) FOREIGN KEY REFERENCES Category(Name) NOT NULL,
ReorderLevel INT NOT NULL,
Description TEXT
)

SELECT * FROM Product

CREATE TABLE Customer(
Code INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
Name VARCHAR(255) NOT NULL,
Address VARCHAR(255) NOT NULL,
Email VARCHAR(255) UNIQUE NOT NULL,
Contact VARCHAR(11) UNIQUE NOT NULL,
LoyalityPoint INT
)

select * from Customer

CREATE TABLE Supplier(
Code INT IDENTITY(1000,1) PRIMARY KEY NOT NULL,
Name VARCHAR(255) NOT NULL,
Address VARCHAR(255) NOT NULL,
Email VARCHAR(255) UNIQUE NOT NULL,
Contact VARCHAR(11) UNIQUE NOT NULL,
ContactPerson VARCHAR(11) NOT NULL
)

SELECT * from Supplier

CREATE TABLE Sales(
Id INT PRIMARY KEY,
Date date,
CustomerCode VARCHAR(50) NOT NULL,
LoyalityPoint FLOAT NOT NULL,
)

INSERT INTO Sales (Id,Date,CustomerCode,LoyalityPoint) VALUES (1,'2018/1/15','012',120.50);
INSERT INTO Sales (Id,Date,CustomerCode,LoyalityPoint) VALUES (2,'2019/1/17','013',120.50);
INSERT INTO Sales (Id,Date,CustomerCode,LoyalityPoint) VALUES (3,'2018/5/20','014',120.50);
INSERT INTO Sales (Id,Date,CustomerCode,LoyalityPoint) VALUES (4,'2019/1/19','015',120.50);
INSERT INTO Sales (Id,Date,CustomerCode,LoyalityPoint) VALUES (5,'2018/12/31','016',120.50);
INSERT INTO Sales (Id,Date,CustomerCode,LoyalityPoint) VALUES (6,'2018/12/30','017',120.50);

DROP TABLE Sales
SELECT * From Sales
SELECT * From Sales where Date between '2018/01/10' and '2018/12/30';

CREATE TABLE SalesDetails(
Id INT IDENTITY(1,1),
Category VARCHAR(255) NOT NULL,
ProductCode VARCHAR(255) NOT NULL,
AvailableQuantity VARCHAR(255) NOT NULL,
Quantity VARCHAR(255) NOT NULL,
MrpTk Float NOT NULL,
TotalMrpTk float NOT NULL
)

Update  SalesDetails set AvailableQuantity='120' where Quantity='10'
INSERT INTO SalesDetails(Category,ProductCode,AvailableQuantity,Quantity,MrpTk,TotalMrpTk) VALUES('mi','011','150','10',150.25,500.25)
INSERT INTO SalesDetails(Category,ProductCode,AvailableQuantity,Quantity,MrpTk,TotalMrpTk) VALUES('Huawei','012','140','15',175.26,600.25)
INSERT INTO SalesDetails(Category,ProductCode,AvailableQuantity,Quantity,MrpTk,TotalMrpTk) VALUES('Samsung','013','120','20',180.25,800.25)
INSERT INTO SalesDetails(Category,ProductCode,AvailableQuantity,Quantity,MrpTk,TotalmrpTk) VALUES('Oppo','014','105','30',320.25,425.32)
INSERT INTO SalesDetails(Category,ProductCode,AvailableQuantity,Quantity,MrpTk,TotalmrpTk) VALUES('Symphony','015','90','35',260.80,400.25)

SELECT * From SalesDetails
DROP TABLE SalesDetails 
SELECT * FROM SalesDetails Where ProductCode='011' AND (AvailableQuantity='150')


