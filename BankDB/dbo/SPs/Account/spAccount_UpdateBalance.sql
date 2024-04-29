CREATE PROCEDURE [dbo].[spAccount_UpdateBalance]
	@AccountId	int,
	@Amount		money
AS
BEGIN

update Account
set Balance = Balance + @Amount
where aId = @AccountId

END;
