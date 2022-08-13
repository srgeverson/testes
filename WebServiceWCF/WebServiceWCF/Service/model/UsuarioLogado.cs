using System.Runtime.Serialization;
/// <summary>
/// Classe que representa usuário que irá se autenticar
/// </summary>
[DataContract]
public class UsuarioLogado
{
    [DataMember]
    public string Token { get; set; }
    [DataMember]
    public string Nome { get; set; }
    [DataMember]
    public string Mensagem { get; set; }
}