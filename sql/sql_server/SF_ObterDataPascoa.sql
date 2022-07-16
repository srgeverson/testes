CREATE FUNCTION ObterDataPascoa(@ano INT)
    RETURNS SMALLDATETIME
AS
BEGIN
    DECLARE @seculo INT, @G INT, @K INT, @I INT, @H INT, @J INT, @L INT, @MesDePascoa INT, @DiaDePascoa INT, @pascoa SMALLDATETIME;
  
    SET @seculo = @ano / 100
    SET @G = @ano % 19
    SET @K = ( @seculo - 17 ) / 25
    SET @I = ( @seculo - CAST(@seculo / 4 AS INT) - CAST(( @seculo - @K ) / 3 AS INT) + 19 * @G + 15 ) % 30
    SET @H = @I - CAST(@I / 28 AS INT) * ( 1 * -CAST(@I / 28 AS INT) * CAST(29 / ( @I + 1 ) AS INT) ) * CAST(( ( 21 - @G ) / 11 ) AS INT)
    SET @J = ( @ano + CAST(@ano / 4 AS INT) + @H + 2 - @seculo + CAST(@seculo / 4 AS INT) ) % 7
    SET @L = @H - @J
    SET @MesDePascoa = 3 + CAST(( @L + 40 ) / 44 AS INT)
    SET @DiaDePascoa = @L + 28 - 31 * CAST(( @MesDePascoa / 4 ) AS INT)
    SET @pascoa = CAST(@MesDePascoa AS VARCHAR(2)) + '-' + CAST(@DiaDePascoa AS VARCHAR(2)) + '-' + CAST(@ano AS VARCHAR(4))
     
    RETURN @pascoa;
END