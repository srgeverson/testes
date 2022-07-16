
SET LANGUAGE english
  
SELECT dia,
feriado
FROM dbo.ObterFeriados(2013)
ORDER BY dia;

select * from usuarios;
select * from usuarios;
select getdate();
select month(getdate());
select day(getdate());
declare @teste int = (select year(getdate()));
select @teste +2;