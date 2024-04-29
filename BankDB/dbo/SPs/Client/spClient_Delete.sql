CREATE PROCEDURE [dbo].[spClient_Delete]
	@ClientId int
AS
BEGIN

delete
from Client
where cId = @ClientId

END;
