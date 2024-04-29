CREATE PROCEDURE [dbo].[spClient_GetAll]
AS
BEGIN

select FirstName, LastName, isVerified
from Client

END;
