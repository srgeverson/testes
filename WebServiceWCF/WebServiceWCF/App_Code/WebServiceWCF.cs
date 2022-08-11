public class WebServiceWCF : IWebServiceWCF
{
	public string GerarMensagemDeBoasVindas(string nome)
	{
		return string.Format("Seja bem vindo {0}!", nome);
	}
}
