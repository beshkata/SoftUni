SELECT u.[Username]
     , c.[Name] AS CategoryName 
FROM [Reports] AS r
JOIN [Users] AS u
ON r.[UserId] = u.[Id]
JOIN [Categories] AS c
ON r.[CategoryId] = c.[Id]
WHERE DATEPART(DAY, r.[OpenDate]) = DATEPART(DAY, u.[Birthdate]) AND DATEPART(MONTH, r.[OpenDate]) = DATEPART(MONTH, u.[Birthdate]) 
ORDER BY u.[Username], [CategoryName]