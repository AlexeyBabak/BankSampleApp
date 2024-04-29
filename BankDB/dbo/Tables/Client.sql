CREATE TABLE [dbo].[Client]
(
	[cId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [isVerified] BIT NOT NULL
)
