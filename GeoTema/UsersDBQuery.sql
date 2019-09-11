CREATE TABLE Users 
(
	Username NVARCHAR(50) PRIMARY KEY,
	[Password] NVARCHAR(50) NOT NULL,
	Usertype NVARCHAR(50) NOT NULL,
)
GO

INSERT INTO Users VALUES('1','1','Bruger')
INSERT INTO Users VALUES('2','2','Superbruger')
INSERT INTO Users VALUES('3','3','Administrator')

SELECT * FROM Users ORDER BY Usertype ASC, Username ASC