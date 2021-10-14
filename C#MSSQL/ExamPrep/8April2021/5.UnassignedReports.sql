SELECT [Description]
      ,FORMAT([OpenDate], 'dd-MM-yyyy') AS [OpeniDate]
FROM [Reports]
WHERE [EmployeeId] IS NULL
ORDER BY [OpenDate], [Description]
