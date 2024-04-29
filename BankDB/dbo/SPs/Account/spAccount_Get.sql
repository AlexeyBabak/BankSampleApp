CREATE PROCEDURE [dbo].[spAccount_Get]
	@AccountId int
AS
BEGIN

select aId, Balance, InterestRate, ClientId
from Account
where aId = @AccountId

END;
