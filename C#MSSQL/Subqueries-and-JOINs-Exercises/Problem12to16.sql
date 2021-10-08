--USE [Geography]

--12. Highest Peaks in Bulgaria
SELECT 
	 c.[CountryCode]
	,m.[MountainRange]
	,p.[PeakName]
	,p.[Elevation]
FROM [Countries] AS c
JOIN [MountainsCountries] as mc
ON c.[CountryCode] = mc.[CountryCode]
JOIN [Mountains] as m
ON mc.[MountainId] = m.[Id]
JOIN [Peaks] AS p
ON m.[Id] = p.[MountainId]
WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

--13. Count Mountain Ranges
SELECT 
	 c.[CountryCode]
	,COUNT(m.[MountainRange]) AS [MountainRanges]
FROM [Countries] AS c
JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
JOIN [Mountains] AS m
ON mc.[MountainId] = m.[Id]
WHERE c.[CountryCode] IN ('US', 'RU', 'BG')
GROUP BY c.[CountryCode]

--14. Countries with Rivers
SELECT TOP(5) 
	 c.[CountryName]
	,r.[RiverName]
FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
WHERE c.[ContinentCode] = 'AF'
ORDER BY c.[CountryName]

--15. *Continents and Currencies
SELECT 
	 [ContinentCode]
	,[CurrencyCode]
	,[CurrencyCount]
FROM
	(
	SELECT *
		, DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) 
		AS [CurrencyRank]

	FROM
			(
				SELECT 
				[ContinentCode]
				, [CurrencyCode]
				, COUNT([CurrencyCode]) AS [CurrencyCount]
				FROM [Countries]
				GROUP BY [ContinentCode], [CurrencyCode]
			) AS [CurrencySubQuery]
	WHERE [CurrencyCount] > 1
	) AS [CurrencyRankSubQuery]
WHERE [CurrencyRank] = 1

--16. Countries Without Any Mountains
SELECT 
	COUNT(c.[CountryCode]) AS [Count]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
WHERE mc.[MountainId] IS NULL

--17. Highest Peak and Longest River by Country
SELECT *
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m
ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p
ON m.[Id] = p.[MountainId]
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]

