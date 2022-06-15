CREATE DEFINER=`root`@`localhost` FUNCTION `fn_data_pascoa`(ano INT) RETURNS datetime
BEGIN
DECLARE seculo INT;
DECLARE  G INT;
DECLARE K INT;
DECLARE  I INT;
DECLARE H INT;
DECLARE J INT;
DECLARE L INT;
DECLARE MesDePascoa INT;
DECLARE DiaDePascoa INT;
DECLARE pascoa DATE;
	SET seculo = ano / 100;
	SET G = ano % 19;
    SET K = ( seculo - 17 ) / 25;
    SET I = ( seculo - CAST(seculo / 4 AS double) - CAST(( seculo - K ) / 3 AS double) + 19 * G + 15 ) % 30;
    SET H = I - CAST(I / 28 AS double) * ( 1 * -CAST(I / 28 AS double) * CAST(29 / ( I + 1 ) AS double) ) * CAST(( ( 21 - G ) / 11 ) AS double);
    SET J = ( ano + CAST(ano / 4 AS double) + H + 2 - seculo + CAST(seculo / 4 AS double) ) % 7;
    SET L = H - J;
    SET MesDePascoa = 3 + CAST(( L + 40 ) / 44 AS double);
    SET DiaDePascoa = L + 28 - 31 * CAST(( MesDePascoa / 4 ) AS double);
    SET pascoa = convert(CONCAT(CAST(ano AS CHAR(4)), '-', CAST(MesDePascoa AS CHAR(2)), '-', CAST(DiaDePascoa AS CHAR(2))), DATE) ;
RETURN pascoa;
END