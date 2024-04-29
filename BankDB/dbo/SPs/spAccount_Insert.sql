CREATE PROCEDURE [dbo].[spAccount_Insert]
	@Balance		money = 0,
	@InterestRate	decimal(4,2) = 0,
	@ClientId		int
AS
BEGIN

insert into dbo.Account (Balance, InterestRate, ClientId)
values (@Balance, @InterestRate, @ClientId)

END;
