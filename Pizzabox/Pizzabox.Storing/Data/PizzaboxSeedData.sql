--CREATE DATABASE PizzaboxDB;


CREATE TABLE Stores(
StoreID INT PRIMARY KEY IDENTITY(1,1),
StoreName VARCHAR(50) NOT NULL,
StoreAddress VARCHAR(50) NOT NULL,
OpperationHourStart VARCHAR(3) NOT NULL,
OpperationHourEnd VARCHAR(3) NOT NULL);

INSERT INTO Stores (StoreName, StoreAddress, OpperationHourStart, OpperationHourEnd)
VALUES
('MMP Bay Area', '123 W Pillage St', '11a', '11p'),
('MMP Downtown', '88675 1st St N', '8a', '10p'),
('MMP Cypress', '789 N Monitor Ave', '11a', '11p'),
('MMP Heights', '0112 Hillock Way', '11a', '11p'),
('MMP Hills', '456 Speaker Ln', '11a', '11p');

--SELECT * FROM Stores;


CREATE TABLE CrustOptions(
CrustID INT PRIMARY KEY IDENTITY(1, 1),
CrustOptionName VARCHAR(50) NOT NULL,
CrustOptionPrice DECIMAL(4, 2) NOT NULL);

INSERT INTO CrustOptions (CrustOptionName, CrustOptionPrice)
VALUES
('Thin Crust', 0.0),
('Hand Tossed', 0.0),
('Pan', 1.0),
('Deep Dish', 1.0),
('Stuffed Crust', 1.5),
('Pretzel Crust', 0.0);

--SELECT * FROM CrustOptions;


CREATE TABLE SauceOptions(
SauceID INT PRIMARY KEY IDENTITY(1, 1),
SauceOptionName VARCHAR(50) NOT NULL);

INSERT INTO SauceOptions (SauceOptionName)
VALUES
('Regular'),
('Alfredo'),
('BBQ');

--SELECT * FROM SauceOptions;


CREATE TABLE Toppings(
ToppingID INT PRIMARY KEY IDENTITY(1, 1),
ToppingName VARCHAR(50) NOT NULL,
ToppingPrice DECIMAL(4, 2) NOT NULL);

INSERT INTO Toppings (ToppingName, ToppingPrice)
VALUES
('Cheese', 0.0),
('Black Olives', 1.0),
('Green Olives', 1.0),
('Spinach', 0.5),
('Fresh Mozzerella', 1.5),
('Green Peppers', 1.0),
('Mushrooms', 1.0),
('Jalapenos', 1.0),
('Pepperoni', 1.0),
('Italian Sausage', 1.0),
('Ham', 1.0),
('Grilled Chicken', 1.0);

--SELECT * FROM Toppings;


CREATE TABLE SizeOptions(
SizeID INT PRIMARY KEY IDENTITY(1, 1),
SizeName VARCHAR(50) NOT NULL,
SizePrice DECIMAL(4, 2) NOT NULL);

INSERT INTO SizeOptions (SizeName, SizePrice)
VALUES
('Personal', 8.74),
('Small', 10.74),
('Medium', 12.74),
('Large', 16.74),
('Mighty Mark', 25.74);

--SELECT * FROM SizeOptions;

CREATE TABLE PresetPizzas(
PizzaID INT PRIMARY KEY IDENTITY(10000, 1),
PizzaName VARCHAR(50) NOT NULL);

INSERT INTO PresetPizzas (PizzaName)
VALUES
('Pepperoni Pizza'),
('Sausage Pizza'),
('Cheese Pizza'),
('Supreme Pizza'),
('Meat Lovers Pizza'),
('Spinach Alfredo Pizza'),
('Garden Pizza');

--SELECT * FROM PresetPizzas


CREATE TABLE PresetPizzaJunction(
PizzaID INT FOREIGN KEY REFERENCES PresetPizzas(PizzaID) ON DELETE CASCADE,
CrustID INT FOREIGN KEY REFERENCES CrustOptions(CrustID) ON DELETE CASCADE,
SauceID INT FOREIGN KEY REFERENCES SauceOptions(SauceID) ON DELETE CASCADE,
SizeID INT FOREIGN KEY REFERENCES SizeOptions(SizeID) ON DELETE CASCADE,
ToppingID INT FOREIGN KEY REFERENCES Toppings(ToppingID) ON DELETE CASCADE);

INSERT INTO PresetPizzaJunction (PizzaID, CrustID, SauceID, SizeID, ToppingID)
VALUES
(10000, 2, 1, 4, 1),
(10000, 2, 1, 4, 9),
(10001, 2, 1, 4, 1),
(10001, 2, 1, 4, 10),
(10002, 2, 1, 4, 1),
(10002, 2, 1, 4, 5),
(10003, 2, 1, 4, 1),
(10003, 2, 1, 4, 2),
(10003, 2, 1, 4, 6),
(10003, 2, 1, 4, 9),
(10003, 2, 1, 4, 10),
(10004, 2, 1, 4, 1),
(10004, 2, 1, 4, 9),
(10004, 2, 1, 4, 10),
(10004, 2, 1, 4, 11),
(10004, 2, 1, 4, 12),
(10005, 2, 2, 4, 1),
(10005, 2, 2, 4, 4),
(10006, 2, 1, 4, 1),
(10006, 2, 1, 4, 2),
(10006, 2, 1, 4, 3),
(10006, 2, 1, 4, 6),
(10006, 2, 1, 4, 7);

--SELECT * FROM PresetPizzaJunction;


CREATE TABLE Orders(
OrderID INT PRIMARY KEY IDENTITY(1, 1),
FulfillingStore INT FOREIGN KEY REFERENCES Stores(StoreID) ON DELETE CASCADE,
OrderDate DATETIME NOT NULL,
TotalSale DECIMAL(8, 2));


CREATE TABLE PizzaHistory(
PizzaID INT PRIMARY KEY IDENTITY(1, 1),
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) ON DELETE CASCADE);

--SELECT * FROM PizzaHistory


CREATE TABLE PizzaHistoryJunction(
PizzaID INT FOREIGN KEY REFERENCES PizzaHistory(PizzaID) ON DELETE CASCADE,
CrustID INT FOREIGN KEY REFERENCES CrustOptions(CrustID) ON DELETE CASCADE,
SauceID INT FOREIGN KEY REFERENCES SauceOptions(SauceID) ON DELETE CASCADE,
SizeID INT FOREIGN KEY REFERENCES SizeOptions(SizeID) ON DELETE CASCADE,
ToppingID INT FOREIGN KEY REFERENCES Toppings(ToppingID) ON DELETE CASCADE);

--SELECT * FROM PizzaHistoryJunction;


CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY(1, 1),
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL);

INSERT INTO Customers (FirstName, LastName)
VALUES
('carl', 'sagan'),
('neil', 'tyson'),
('richard', 'feynman');
