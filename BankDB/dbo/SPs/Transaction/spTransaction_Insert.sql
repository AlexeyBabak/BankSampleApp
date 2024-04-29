CREATE PROCEDURE [dbo].[spTransaction_Insert]
	@Amount				money,
	@TransactionType	int,
	@AccountId			int
AS
BEGIN

insert into dbo.[Transaction] (TransactionDate, Amount, TransactionType, AccountId)
values (getdate(), @Amount, @TransactionType, @AccountId)

END;
