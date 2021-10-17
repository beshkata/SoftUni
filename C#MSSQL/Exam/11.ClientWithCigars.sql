CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS 
BEGIN
	DECLARE @result INT = (	SELECT COUNT(*)
							FROM Clients AS c
							JOIN ClientsCigars AS cc
							ON c.Id = cc.ClientId
							JOIN Cigars AS cr
							ON cc.CigarId = cr.Id
							WHERE c.FirstName = @name)
	RETURN @result
END

SELECT dbo.udf_ClientWithCigars('Betty')