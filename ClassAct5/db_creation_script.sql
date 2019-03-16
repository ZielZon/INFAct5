CREATE DATABASE API_DB;

GO

use API_DB;

CREATE TABLE API_DB.dbo.Brands
(
	Brand_ID int NOT NULL,
	Brand_Name VARCHAR(30),
	PRIMARY KEY (Brand_ID)
);

CREATE TABLE API_DB.dbo.Monitors
(
	Monitor_ID int NOT NULL,
	Monitor_Name VARCHAR(30),
	Brand_ID int,
	PRIMARY KEY (Monitor_ID),
	Foreign key (Brand_ID) REFERENCES API_DB.dbo.Brands (Brand_ID)
);

CREATE TABLE API_DB.dbo.Keyboards
(
	Keyboard_ID int NOT NULL,
	Keyboard_Name VARCHAR(30),
	Brand_ID int,
	PRIMARY KEY (Keyboard_ID),
	Foreign key (Brand_ID) REFERENCES API_DB.dbo.Brands (Brand_ID)
);

GO

INSERT INTO API_DB.dbo.Brands (Brand_ID,Brand_Name) VALUES (1,'Asus'), (2,'Gigabyte'), (3,'Dell')

INSERT INTO API_DB.dbo.Monitors (Monitor_ID, Monitor_Name, Brand_ID) VALUES (10,'A12344',1), (11,'G43GHd',2), (12,'De4390E',3)

INSERT INTO API_DB.dbo.Keyboards (Keyboard_ID, Keyboard_Name, Brand_ID) VALUES (100,'AceCat',1), (101,'Gorgon',2), (102,'Dezine',3)