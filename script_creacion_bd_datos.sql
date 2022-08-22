CREATE DATABASE GYF;

CREATE TABLE Categories (
    ID INT NOT NULL IDENTITY(1,1),
	Description VARCHAR(20),
    CONSTRAINT PK_Categories PRIMARY KEY (ID)
);

INSERT INTO Categories SELECT 'PRODUNO';
INSERT INTO Categories SELECT 'PRODDOS';

CREATE TABLE Products(
	ID INT NOT NULL IDENTITY(1,1),
	Price INT NOT NULL,
	Upload_Date DATETIME NOT NULL,
	Category INT NOT NULL
	CONSTRAINT FK_Category_Product
	FOREIGN KEY (Category) REFERENCES Categories(ID)
)

INSERT INTO Products(Price, Upload_Date, Category)
VALUES (10, '2019-10-25', 2);

INSERT INTO Products(Price, Upload_Date, Category)
VALUES (60, '2019-10-21', 1);

INSERT INTO Products(Price, Upload_Date, Category)
VALUES (5, '2019-10-22', 2);

INSERT INTO Products(Price, Upload_Date, Category)
VALUES (5, '2019-10-29', 1);

INSERT INTO Products(Price, Upload_Date, Category)
VALUES (15, '2019-09-11', 2);


	

	
