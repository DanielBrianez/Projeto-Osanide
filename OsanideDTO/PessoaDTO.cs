namespace OsanideDTO
{
    public enum TipoUsuario
    {
        Funcionario = 1,
        Administrador = 2
    }

    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public TipoUsuario TipoUsuario { get; set; } = TipoUsuario.Funcionario;

    }
}
