SELECT [FullName]
      ,COUNT([Username]) AS [UsersCount]
FROM
	(
		SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName]
			  ,u.[Username]
		FROM [Employees] AS e
		LEFT JOIN [Reports] AS r
		ON e.[Id] = r.[EmployeeId]
		LEFT JOIN [Users] AS u
		ON r.[UserId] = u.[Id]
	) AS [NameAndUsernameSubQuery]
GROUP BY [FullName]
ORDER BY [UsersCount] DESC, [FullName]
