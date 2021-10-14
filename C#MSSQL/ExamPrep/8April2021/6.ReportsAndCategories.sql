SELECT r.[Description]
      ,c.[Name]
FROM [Reports] AS r
JOIN [Categories] AS c
ON r.[CategoryId] = C.[Id]
ORDER BY r.[Description], c.[Name]