--07. Define Function

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @flag BIT = 1;
	DECLARE @index INT = 1;
	DECLARE @count INT = LEN(@word)

	WHILE @index <= @count
	BEGIN
		IF CHARINDEX(SUBSTRING(@word,@index,1),@setOfLetters ) = 0
		BEGIN
			SET @flag = 0
			BREAK
		END
		SET @index = @index + 1
	END
	RETURN @flag
END

select dbo.ufn_IsWordComprised ('pppp', 'Guy')