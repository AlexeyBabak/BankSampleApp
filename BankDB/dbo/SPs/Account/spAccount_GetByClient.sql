CREATE PROCEDURE [dbo].[spAccount_GetByClient]
	@ClientId int
AS
BEGIN

select aId, Balance, InterestRate, ClientId
from Account
where ClientId = @ClientId

END;
