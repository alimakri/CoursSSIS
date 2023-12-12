CREATE DATABASE [BD1] ON PRIMARY
( 
NAME = N'BD1', 
FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.INSTANCEA\MSSQL\DATA\BD1.mdf' , 
SIZE = 8192KB , 
FILEGROWTH = 65536KB 
)
LOG ON 
( 
NAME = N'BD1_log', 
FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.INSTANCEA\MSSQL\DATA\BD1_log.ldf' , 
SIZE = 8192KB , 
FILEGROWTH = 65536KB 
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('[dbo].Personne') AND type in ('U'))
BEGIN
	CREATE TABLE Personne
	(
	[Id] bigint NOT NULL,
	Nom [nvarchar](max) NOT NULL,
	Prenom [nvarchar](max) NOT NULL,
	Ville [nvarchar](max) NULL,
	CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED ([Id] ASC),
	);
END

SELECT        
	Person.Person.BusinessEntityID, 
	Person.Person.FirstName, 
	Person.Person.LastName, Person.Address.City
FROM            
	Person.Address 
	INNER JOIN Person.BusinessEntityAddress ON Person.Address.AddressID = Person.BusinessEntityAddress.AddressID 
	INNER JOIN Person.Person ON Person.BusinessEntityAddress.BusinessEntityID = Person.Person.BusinessEntityID
Where FirstName IS NOT null and LastName is not NULL and City is not null
Order by BusinessEntityID

select * from BD1.dbo.personne

