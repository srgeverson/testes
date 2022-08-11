public class WebServiceWCF : IWebServiceWCF
{
    public string GerarMensagemDeBoasVindas(string nome)
    {
        return string.Format("Seja bem vindo {0}!", nome);
    }

    public Pessoa NomeESobreNome(string nome, string sobreNome)
    {
        return new Pessoa() { Nome = nome, SobreNome = sobreNome };
    }
}
