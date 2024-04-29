CREATE PROCEDURE [dbo].[spClient_Insert]
	@FirstName	nvarchar(50),
	@LastName	nvarchar(50),
	@isVerified	bit
AS
BEGIN

insert into dbo.Client (FirstName, LastName, isVerified)
values (@FirstName, @LastName, @isVerified)

END;
