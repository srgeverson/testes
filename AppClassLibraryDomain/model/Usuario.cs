namespace AppClassLibraryDomain.model
{
    public class Usuario
    {
        private int? id;
        private string nome;
        private string email;
        private string senha;
        private bool? ativo;

        public int? Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public bool? Ativo { get => ativo; set => ativo = value; }
    }
}
