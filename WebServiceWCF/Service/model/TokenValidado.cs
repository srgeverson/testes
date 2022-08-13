using System.Runtime.Serialization;
/// <summary>
/// Classe que representa validação do token
/// </summary>
[DataContract]
public class TokenValidado
{
    [DataMember]
    public int StatusCode { get; set; }
    [DataMember]
    public string Mensagem { get; set; }
}