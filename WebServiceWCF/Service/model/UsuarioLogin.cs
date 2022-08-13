using System.Runtime.Serialization;
/// <summary>
/// Classe que representa usuário que irá se autenticar
/// </summary>
[DataContract]
public class UsuarioLogin
{
    [DataMember]
    public string login { get; set; }
    [DataMember]
    public string senha { get; set; }
}