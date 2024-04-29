CREATE PROCEDURE [dbo].[spAccount_GetAll]
AS
BEGIN

select aId, Balance, InterestRate, ClientId
from Account

END;
