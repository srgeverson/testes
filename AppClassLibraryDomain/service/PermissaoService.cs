using AppClassLibraryDomain.DAO;
using AppClassLibraryDomain.model;
using System.Collections.Generic;

namespace AppClassLibraryDomain.service
{
    /// <summary>
    /// Classe responsável por tratar dos dados cadastrais relacionados as permissões.
    /// </summary>
    public class PermissaoService
    {

        private PermissaoDAO permissaoDAO;

        public PermissaoService()
        {
            this.permissaoDAO = new PermissaoDAO();
        }

        public List<Permissao> PermissoesPorNomeUsuario(string usuario)
        {
            return permissaoDAO.SelectByNomeUsuario(usuario);
        }

        public List<Permissao> Todos()
        {
            return permissaoDAO.Select();
        }
    }
}
