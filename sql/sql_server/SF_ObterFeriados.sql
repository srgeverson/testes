CREATE FUNCTION ObterFeriados(@ano INT = NULL)
    RETURNS @feriado TABLE (dia DATE, feriado VARCHAR(100))
AS
BEGIN
     DECLARE @pascoa SMALLDATETIME;
     DECLARE @dia INT;
     DECLARE @mes INT;
     DECLARE @anoPascoa INT;
  
     IF(@ano IS NULL)
     BEGIN
         SET @ano = DATEPART(YEAR, GETDATE());
     END
  
     SET @pascoa = dbo.ObterDataPascoa(@ano);
     SET @dia = DATEPART(DAY, @pascoa);
     SET @mes = DATEPART(MONTH, @pascoa);
     SET @anoPascoa = DATEPART(YEAR, @pascoa);
  
     INSERT INTO @feriado (dia, feriado) VALUES(@pascoa, 'Pascoa');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST('1-1-' + CAST(@anoPascoa AS VARCHAR) AS DATE), 'Confraternização Universal');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST(CAST(@anoPascoa AS VARCHAR) + '-4-21' AS DATE), 'Tiradentes');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST(CAST(@anoPascoa AS VARCHAR) + '-5-1' AS DATE), 'Dia do Trabalhador');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST(CAST(@anoPascoa AS VARCHAR) + '-9-7' AS DATE), 'Dia da Independência');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST(CAST(@anoPascoa AS VARCHAR) + '-10-12' AS DATE), 'N. S. Aparecida');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST(CAST(@anoPascoa AS VARCHAR) + '-11-2' AS DATE), 'Todos os santos');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST(CAST(@anoPascoa AS VARCHAR) + '-11-15' AS DATE), 'Proclamação da republica');
     INSERT INTO @feriado (dia, feriado) VALUES(CAST(CAST(@anoPascoa AS VARCHAR) + '-12-25' AS DATE), 'Natal');
     INSERT INTO @feriado (dia, feriado) VALUES(DATEADD(DAY, 60, @pascoa), 'Corpus Christi');
     INSERT INTO @feriado (dia, feriado) VALUES(DATEADD(DAY, -2, @pascoa), '6º feira Santa');
     INSERT INTO @feriado (dia, feriado) VALUES(DATEADD(DAY, -47, @pascoa), '3º feria Carnaval');
     INSERT INTO @feriado (dia, feriado) VALUES(DATEADD(DAY, -48, @pascoa), '2º feria Carnaval');
  
     RETURN;
END