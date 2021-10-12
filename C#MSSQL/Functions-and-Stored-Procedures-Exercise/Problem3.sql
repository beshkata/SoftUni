--03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith @startingString VARCHAR(50)
AS
SELECT [Name]
FROM [Towns]
WHERE LEFT([Name], LEN(@startingString)) = @startingString

GO

EXEC usp_GetTownsStartingWith 'MO'