CREATE PROCEDURE [dbo].[spTransaction_Get]
	@TransactioId int
AS
BEGIN

select tId, TransactionDate, Amount, TransactionType, AccountId
from [Transaction]
where tId = @TransactioId

END;
