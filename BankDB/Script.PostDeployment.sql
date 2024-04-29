if not exists (select 1 from dbo.Client)
begin 

	insert into dbo.Client(FirstName, LastName, isVerified)
	values
		('TestName', 'TestSurname', 1)
end;

if not exists (select 1 from dbo.LTransactionType)
begin 

	insert into dbo.LTransactionType(ttId, tType)
	values
		(0, 'Deposit'),
		(1, 'Withdrawal'),
		(2, 'Transfer')
end;
