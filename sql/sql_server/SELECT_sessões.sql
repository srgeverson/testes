--Verificando as sess�es abertas
SELECT s.session_id, s.login_time, s.[host_name], s.program_name,
       s.host_process_id, s.client_version
FROM sys.dm_exec_sessions AS s
WHERE login_name = 'user_teste'

--Encerrando a sess�o por ID
KILL 52;
KILL 57;
KILL 56;
KILL 59;
KILL 61;