CREATE TABLE [dbo].[PersonAddress]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FullAddress] VARCHAR(500) NOT NULL, 
    [ZipCode] VARCHAR(10) NOT NULL, 
    [IsBilling] BIT NOT NULL, 
    [PersonId] INT NOT NULL
    CONSTRAINT [FK_PersonAddresses_Person] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
