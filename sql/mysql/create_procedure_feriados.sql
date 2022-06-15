CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_feriados`(IN ano INT)
BEGIN
	DECLARE pascoa DATETIME DEFAULT (SELECT data_pascoa(ano));
    DECLARE dia INT(2) DEFAULT DAY(pascoa);
    DECLARE mes INT(2) DEFAULT MONTH(pascoa);
    DECLARE anoPascoa INT(4) DEFAULT YEAR(pascoa);
    
    WITH tb_tmp_feriados AS (
		 SELECT pascoa AS Data, 'Pascoa' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-1-1') AS DATE) AS Data, 'Confraternização Universal' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-4-21') AS DATE) AS Data, 'Tiradentes' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-5-1') AS DATE) AS Data, 'Dia do Trabalhador' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-9-7') AS DATE) AS Data, 'Dia da Independência' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-10-12') AS DATE) AS Data, 'N. S. Aparecida' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-11-2') AS DATE) AS Data, 'Todos os santos' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-11-15') AS DATE) AS Data, 'Proclamação da republica' AS Feriado
        UNION
        SELECT CAST(CONCAT(anoPascoa, '-12-25') AS DATE) AS Data, 'Natal' AS Feriado
        UNION
        SELECT (pascoa + INTERVAL 60 DAY) AS Data, 'Corpus Christi' AS Feriado
        UNION
        SELECT (pascoa + INTERVAL -2 DAY) AS Data, '6º feira Santa' AS Feriado
        UNION
        SELECT (pascoa - INTERVAL 47 DAY) AS Data, '3º feria Carnaval' AS Feriado
        UNION
        SELECT (pascoa - INTERVAL 48 DAY) AS Data, '2º feria Carnaval' AS Feriado
	)
    SELECT * FROM tb_tmp_feriados;
END