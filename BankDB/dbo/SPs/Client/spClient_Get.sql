CREATE PROCEDURE [dbo].[spClient_Get]
	@ClientId int
AS
BEGIN

select FirstName, LastName, isVerified
from Client
where cId = @ClientId

END;
