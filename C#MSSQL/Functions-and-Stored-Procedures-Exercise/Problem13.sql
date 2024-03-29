--13. *Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE AS
RETURN
(
	SELECT SUM([Cash]) AS [SumCash]
	  FROM (
			SELECT ug.[Cash], ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.[Cash] DESC) AS [RowNumber]
			  FROM [Games] AS g
			  JOIN [UsersGames] AS ug
			    ON g.[Id] = ug.GameId
			 WHERE g.[Name] = @gameName
		   ) AS [NumberRowsSubQuery]
	 WHERE [RowNumber] % 2 <> 0
)

SELECT * FROM dbo.ufn_CashInUsersGames ('Love in a mist')