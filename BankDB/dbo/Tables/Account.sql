CREATE TABLE [dbo].[Account]
(
	[aId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Balance] MONEY NOT NULL, 
    [InterestRate] DECIMAL(4, 2) NOT NULL, 
    [ClientId] INT NOT NULL, 
    CONSTRAINT [FK_Account_Client] FOREIGN KEY ([ClientId]) REFERENCES [Client]([cId])
)