using System;
using System.Collections.Generic;
using AppClassLibraryDomain.DAO;
using AppClassLibraryDomain.DAO.NHibernate;
using AppClassLibraryDomain.model;
using BCryptNet = BCrypt.Net.BCrypt;

namespace AppClassLibraryDomain.service
{
    /// <summary>
    /// Classe responsável por tratar dos dados cadastrais relacionados usuários.
    /// </summary>
    public class UsuarioService
    {
        private UsuarioDAO usuarioDAO;
        private UsuarioNHibernateDAO usuarioNHibernateDAO;

        public UsuarioService()
        {
            if (usuarioDAO == null)
                usuarioDAO = new UsuarioDAO();

            if (usuarioNHibernateDAO == null)
                usuarioNHibernateDAO = new UsuarioNHibernateDAO();
        }

        public IList<Usuario> GetUsuarios()
        {
            return usuarioNHibernateDAO.GetUsuarios();
        }

        public bool AlterarPorId(Usuario usuario, int id)
        {
            usuario.Id = id;
            return usuarioDAO.Update(usuario);
        }

        public bool ApagarPorId(Int32 id)
        {
            return usuarioDAO.DeletePorId(id);
        }
        public Usuario BuscarPorId(Int32 id)
        {
            return usuarioDAO.SelectPorId(id);
        }

        public Usuario BuscarPorNome(string nome)
        {
            return usuarioDAO.SelectPorNome(nome);
        }
        public Usuario BuscarPorEmail(string nome)
        {
            return usuarioDAO.SelectPorEmail(nome);
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            usuario.Ativo = true;
            usuario.Senha = BCryptNet.HashPassword(usuario.Senha);
            return usuarioDAO.Insert(usuario);
        }

        public bool ValidarSenha(string senhaTexto, string senhaEncriptada)
        {
            return BCryptNet.Verify(senhaTexto, senhaEncriptada);
        }

        public List<Usuario> Todos()
        {
            return usuarioDAO.Select();
        }

        public bool AlterarPorId(int? id)
        {
            return usuarioDAO.UpdateDataUltimoAcesso(id);
        }
    }
}
