SELECT LastName, CEILING(AVG([Length])) AS CiagrLength, CEILING(AVG(RingRange)) AS CiagrRingRange
FROM (
		SELECT c.LastName
			  ,s.[Length]
			  ,s.RingRange
		FROM Clients AS c
		JOIN ClientsCigars AS cc
		ON c.Id = cc.ClientId
		JOIN Cigars AS cr
		ON cc.CigarId = cr.Id
		JOIN Sizes AS s
		ON cr.SizeId = s.Id
		) AS SubQuery
GROUP BY LastName
ORDER BY CiagrLength DESC

