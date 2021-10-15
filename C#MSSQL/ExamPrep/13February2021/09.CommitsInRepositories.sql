SELECT TOP(5) Id
			 ,[Name]
			 ,COUNT(*) AS Commits
FROM 
	(SELECT r.[Name], r.Id
	FROM Commits AS c
	JOIN Repositories AS r
	ON c.RepositoryId = r.Id
	JOIN RepositoriesContributors AS rc
	ON r.Id = rc.RepositoryId) AS SubQuery
GROUP BY [Name], Id
ORDER BY Commits DESC, Id, [Name]
