CREATE PROCEDURE [dbo].[spTransaction_GetAll]
AS
BEGIN

select tId, TransactionDate, Amount, TransactionType, AccountId
from [Transaction]

END;
