CREATE FUNCTION CountWords (@sentence NVARCHAR(MAX))
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    DECLARE @index INT = 0;
    DECLARE @len INT = LEN(@sentence);
    DECLARE @inWord BIT = 0;

    SET @count = 0;

    WHILE @index < @len
    BEGIN
        IF SUBSTRING(@sentence, @index + 1, 1) <> ' ' AND @inWord = 0
        BEGIN
            SET @inWord = 1;
            SET @count = @count + 1;
        END
        ELSE IF SUBSTRING(@sentence, @index + 1, 1) = ' '
        BEGIN
            SET @inWord = 0;
        END
        SET @index = @index + 1;
    END

    RETURN @count;
END;
