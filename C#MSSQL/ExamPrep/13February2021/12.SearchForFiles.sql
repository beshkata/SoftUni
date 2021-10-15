CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(100))
AS
BEGIN
	DECLARE @fileExtensionLenght INT = LEN(@fileExtension)
	SELECT Id
	,[Name]
	,CONCAT(Size, 'KB') AS Size
	FROM Files
	WHERE RIGHT([Name],@fileExtensionLenght) = @fileExtension
	ORDER BY Id, [Name], Size DESC
END

EXEC usp_SearchForFiles 'html'
