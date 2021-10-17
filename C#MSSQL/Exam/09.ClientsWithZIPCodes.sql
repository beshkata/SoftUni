SELECT FullName
      ,Country
	  ,ZIP
	  ,CONCAT('$',MAX(CigarPrice)) AS CigarPrice
FROM	(
			SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName
			,a.Country
			,a.ZIP
			,cr.PriceForSingleCigar AS CigarPrice
			FROM Clients AS c
			JOIN Addresses a
			ON c.AddressId = a.Id
			LEFT JOIN ClientsCigars AS cc
			ON c.Id = cc.ClientId
			LEFT JOIN Cigars AS cr
			ON cc.CigarId = cr.Id
			WHERE ISNUMERIC(a.ZIP) = 1
		) AS SubQuery
GROUP BY FullName, Country, ZIP
ORDER BY FullName