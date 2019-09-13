CREATE TABLE Africa 
(
	Land NVARCHAR(50) PRIMARY KEY,
	Fødselsrate FLOAT NOT NULL,
)
GO

CREATE TABLE Asien 
(
	Land NVARCHAR(50) PRIMARY KEY,
	Fødselsrate FLOAT NOT NULL,
)
GO

CREATE TABLE Europa
(
	Land NVARCHAR(50) PRIMARY KEY,
	Fødselsrate FLOAT NOT NULL,
)
GO

CREATE TABLE Mellemamerika 
(
	Land NVARCHAR(50) PRIMARY KEY,
	Fødselsrate FLOAT NOT NULL,
)
GO

CREATE TABLE Nordamerika 
(
	Land NVARCHAR(50) PRIMARY KEY,
	Fødselsrate FLOAT NOT NULL,
)
GO

CREATE TABLE Oceanien
(
	Land NVARCHAR(50) PRIMARY KEY,
	Fødselsrate FLOAT NOT NULL,
)
GO

CREATE TABLE Sydamerika
(
	Land NVARCHAR(50) PRIMARY KEY,
	Fødselsrate FLOAT NOT NULL,
)
GO

INSERT INTO Africa VALUES('Africa', 1.1)
INSERT INTO Asien VALUES('Asien', 1.2)
INSERT INTO Europa VALUES('Europa', 1.3)
INSERT INTO Mellemamerika VALUES('Mellemamerika', 1.4)
INSERT INTO Nordamerika VALUES('Nordamerika', 1.5)
INSERT INTO Oceanien VALUES('Oceanien', 1.6)
INSERT INTO Sydamerika VALUES('Sydamerika', 1.7)

SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Africa
SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Asien
SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Europa
SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Mellemamerika
SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Nordamerika
SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Oceanien
SELECT *, RANK() OVER (ORDER BY Fødselsrate DESC) AS Rang FROM Sydamerika 