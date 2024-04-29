CREATE TABLE [dbo].[Transaction]
(
	[tId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TransactionDate] DATETIME NOT NULL, 
    [Amount] MONEY NOT NULL, 
    [TransactionType] INT NOT NULL, 
    [AccountId] INT NOT NULL, 
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([aId]), 
    CONSTRAINT [FK_Transaction_LTransactionType] FOREIGN KEY ([TransactionType]) REFERENCES [LTransactionType]([ttId])
)
