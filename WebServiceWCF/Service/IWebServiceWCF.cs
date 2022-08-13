using AppClassLibraryClient.model;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WebServiceWCF
{
    [ServiceContract]
    public interface IWebServiceWCF
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "boas-vindas?nome={nome}")]
        string GerarMensagemDeBoasVindas(string nome);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "nome-sobre-nome?nome={nome}&sobreNome={sobreNome}")]
        Pessoa NomeESobreNome(string nome, string sobreNome);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "login")]
        UsuarioLogado Autenticar(UsuarioLogin usuarioLogin);

        [OperationContract]
        [WebInvoke(
        Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare,
        UriTemplate = "validar")]
        TokenValidado Autorizar();

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "usuarios")]
        List<UsuarioResponse> ListarTodosUsuarios();
    }
}
