CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(12) NOT NULL, 
    [CompanyId] INT NOT NULL, 
    CONSTRAINT [FK_Persons_Companies] FOREIGN KEY ([CompanyId]) REFERENCES [Company]([Id])
)
