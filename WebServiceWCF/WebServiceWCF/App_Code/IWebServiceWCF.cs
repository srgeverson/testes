using System.ServiceModel;

[ServiceContract]
public interface IWebServiceWCF
{

	[OperationContract]
	string GerarMensagemDeBoasVindas(string nome);
}
