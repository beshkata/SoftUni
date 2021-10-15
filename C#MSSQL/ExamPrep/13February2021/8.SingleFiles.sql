SELECT Id
	  ,[Name]
	  ,CONCAT(Size, 'KB') AS Size
FROM Files
WHERE Id NOT IN (
					SELECT
						CASE
						WHEN ParentId IS NULL THEN 0
						ELSE ParentId
						END
					FROM Files
				)
ORDER BY Id, [Name], Size






