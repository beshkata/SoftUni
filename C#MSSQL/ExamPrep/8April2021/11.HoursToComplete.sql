CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT 
AS
BEGIN
	DECLARE @differenceInHours INT = 0

	IF (@StartDate IS NOT NULL AND @EndDate IS NOT NULL)
	BEGIN
		SET @differenceInHours = DATEDIFF(HOUR, @StartDate, @EndDate)
	END
	RETURN @differenceInHours
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
