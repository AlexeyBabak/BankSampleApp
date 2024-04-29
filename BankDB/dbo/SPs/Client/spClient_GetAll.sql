CREATE PROCEDURE [dbo].[spClient_GetAll]
AS
BEGIN

select cId, FirstName, LastName, isVerified
from Client

END;
