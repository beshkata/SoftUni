--10. People with Balance Higher Than

CREATE PROC usp_GetHoldersWithBalanceHigherThan @amountOfMoney DECIMAL(18,4)
AS
BEGIN
	SELECT ah.[FirstName], ah.[LastName]
	FROM [AccountHolders] AS ah
	JOIN [Accounts] AS a
	ON ah.[Id] = a.[AccountHolderId]
	GROUP BY ah.[FirstName], ah.[LastName]
	HAVING SUM(a.[Balance]) > @amountOfMoney
	ORDER BY ah.[FirstName], ah.[LastName]
END

EXEC usp_GetHoldersWithBalanceHigherThan 100000

