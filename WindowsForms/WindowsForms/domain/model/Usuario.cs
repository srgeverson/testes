namespace WindowsForms.domain.model
{
    [Serializable]
    public class Usuario
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public bool? Ativo { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
