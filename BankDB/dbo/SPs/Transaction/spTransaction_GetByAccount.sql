CREATE PROCEDURE [dbo].[spTransaction_GetByAccount]
	@AccountId int
AS
BEGIN

select tId, TransactionDate, Amount, TransactionType, AccountId
from [Transaction]
where AccountId = @AccountId

END;
