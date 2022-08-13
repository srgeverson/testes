/************************************************************
 * Code formatted by SoftTree SQL Assistant � v11.0.35
 * Time: 20/06/2022 00:32:25
 ************************************************************/
 
 --SELECT * FROM permissoes;
 --DELETE FROM permissoes;
--DESATIVAR IDENTITY TABELA
SET IDENTITY_INSERT permissoes ON

INSERT INTO permissoes (id,nome, descricao, ativo, data_cadastro, data_operacao)
VALUES 
(1, 'listar_permissao', 'Permite visualizar todas as permissões.', 1, GETDATE(), GETDATE()),
(2, 'listar_usuario', 'Permite visualizar todos os usuários.', 1, GETDATE(), GETDATE()),
(3, 'editar_usuario', 'Permite editar usuário.', 1, GETDATE(), GETDATE()),
(4, 'cadastrar_usuario', 'Permite cadastrar usuário.', 1, GETDATE(), GETDATE()),
(5, 'excluir_usuario', 'Permite excluir usuário.', 1, GETDATE(), GETDATE()),
(6, 'proprio_usuario', 'Permite acesso aos recursos apenas do perfil do próprio usuário.', 1,GETDATE(), GETDATE());

--ATIVAR IDENTITY TABELA
SET IDENTITY_INSERT permissoes OFF

--SELECT * FROM usuarios_permissoes;
--DELETE FROM usuarios_permissoes;
INSERT INTO usuarios_permissoes
(usuario_id, permissao_id, ativo, data_cadastro, data_operacao)
VALUES
(1, 1, 1, GETDATE(), GETDATE()),
(1, 2, 1, GETDATE(), GETDATE()),
(1, 3, 1, GETDATE(), GETDATE()),
(1, 4, 1, GETDATE(), GETDATE()),
(1, 5, 1, GETDATE(), GETDATE()),
(1, 6, 1, GETDATE(), GETDATE()),
(2, 6, 1, GETDATE(), GETDATE());