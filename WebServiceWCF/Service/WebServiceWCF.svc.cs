using AppClassLibraryClient.mapper;
using AppClassLibraryClient.model;
using AppClassLibraryDomain.DAO;
using AppClassLibraryDomain.model;
using AppClassLibraryDomain.service;
using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using WebServiceWCF.Service;

namespace WebServiceWCF
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WebServiceWCF : IWebServiceWCF
    {
        private UsuarioService usuarioService;
        private PermissaoService permissaoService;
        private UsuarioMapper usuarioMapper;

        public WebServiceWCF()
        {
            if (string.IsNullOrEmpty(ConexaoDAO.URLCONEXAO))
                ConexaoDAO.URLCONEXAO = ConfigurationManager.AppSettings["connectionString"];

            if (usuarioService == null)
                usuarioService = new UsuarioService();

            if (permissaoService == null)
                permissaoService = new PermissaoService();

            if (usuarioMapper == null)
                usuarioMapper = new UsuarioMapper();
        }

        public UsuarioLogado Autenticar(UsuarioLogin usuarioLogin)
        {
            if (string.IsNullOrEmpty(usuarioLogin.login) || string.IsNullOrEmpty(usuarioLogin.senha))
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 400, Mensagem = "E-mail ou senha não informado!" }, HttpStatusCode.BadRequest);

            var usuario = usuarioService.BuscarPorEmail(usuarioLogin.login);
            if (usuario == null)
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 404, Mensagem = "Não foi encontrado usuário vinculado ao e-mail informado!" }, HttpStatusCode.NotFound);
            try
            {
                var authorizationWCF = new AuthorizationWCF();
                return authorizationWCF.gerarToken(usuario, usuarioLogin, permissaoService);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = ex.Message }, HttpStatusCode.Unauthorized);
            }
        }

        public TokenValidado Autorizar()
        {
            try
            {
                var authorizationWCF = new AuthorizationWCF();
                return authorizationWCF.validarToken(WebOperationContext.Current.IncomingRequest);
            }
            catch (TokenNotYetValidException tnyvex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = tnyvex.Message }, HttpStatusCode.Unauthorized);
            }
            catch (TokenExpiredException teex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = teex.Message }, HttpStatusCode.Unauthorized);
            }
            catch (SignatureVerificationException svex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = svex.Message }, HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                throw new WebFaultException<TokenValidado>(new TokenValidado() { StatusCode = 401, Mensagem = ex.Message }, HttpStatusCode.Unauthorized);
            }
        }

        public UsuarioLogado Cadastrar(UsuarioLogin usuarioLogin)
        {
            //string passwordHash = BCryptNet.HashPassword("Pa$$w0rd1");
            //bool verified = BCryptNet.Verify("Pa$$w0rd", passwordHash);
            return null;
        }

        public string GerarMensagemDeBoasVindas(string nome)
        {
            return string.Format("Seja bem vindo {0}!", nome);
        }

        public Pessoa NomeESobreNome(string nome, string sobreNome)
        {
            return new Pessoa() { Nome = nome, SobreNome = sobreNome };
        }

        public List<UsuarioResponse> ListarTodosUsuarios()
        {
            return usuarioMapper.ToListResponse(usuarioService.Todos());
        }
    }
}
