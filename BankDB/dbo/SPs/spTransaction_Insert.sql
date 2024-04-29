CREATE PROCEDURE [dbo].[spTransaction_Insert]
	@TransactionDate	datetime,
	@Amount				money,
	@TransactionType	int,
	@AccountId			int
AS
BEGIN

insert into dbo.[Transaction] (TransactionDate, Amount, TransactionType, AccountId)
values (@TransactionDate, @Amount, @TransactionType, @AccountId)

END;
