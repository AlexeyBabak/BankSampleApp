CREATE PROCEDURE [dbo].[spAccount_UpdateInterestRate]
	@AccountId	int,
	@InterestRate	decimal(4,2)
AS
BEGIN

update Account
set InterestRate = @InterestRate
where aId = @AccountId

END;
