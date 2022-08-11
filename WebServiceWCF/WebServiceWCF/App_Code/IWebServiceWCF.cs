using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface IWebServiceWCF
{

    [OperationContract]
    string GerarMensagemDeBoasVindas(string nome);

    [OperationContract]
    [WebInvoke(Method = "GET",
       ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "/login?nome={nome}&sobreNome={sobreNome}")]
    Pessoa NomeESobreNome(string nome, string sobreNome);
}
