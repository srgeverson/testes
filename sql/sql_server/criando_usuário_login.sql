--DB Principal
 USE [master];
 GO
--Apagando Login
DROP LOGIN [user_teste]
GO
--Criando o Login
CREATE LOGIN [user_teste] 
WITH PASSWORD = '12345678';
GO
--Apagando Usuário
DROP USER IF EXISTS [user_teste]
GO
--Habilitando o Login
ALTER LOGIN [user_teste] ENABLE
GO
