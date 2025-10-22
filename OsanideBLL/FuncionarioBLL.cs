using OsanideDTO;
using OsanideDAL;

namespace OsanideBLL
{
    public class FuncionarioBll
    {
        public FuncionarioDTO Login(string login, string senha)
        {
            var funcionario = Database.Funcionarios
                .FirstOrDefault(f => f.Login == login && f.Senha == senha);

            if (funcionario == null)
                throw new Exception("Usuário ou senha inválidos.");

            return funcionario;
        }

        public void CadastrarFuncionario(FuncionarioDTO funcionario)
        {
            var funcionarios = Database.Funcionarios;

            // Validações
            if (string.IsNullOrWhiteSpace(funcionario.Nome))
                throw new Exception("Nome é obrigatório!");

            if (string.IsNullOrWhiteSpace(funcionario.Login))
                throw new Exception("Login é obrigatório!");

            if (string.IsNullOrWhiteSpace(funcionario.Email))
                throw new Exception("E-mail é obrigatório!");

            if (string.IsNullOrWhiteSpace(funcionario.Senha))
                throw new Exception("Senha é obrigatória!");

            if (funcionario.Cargo == 0)
            {
                throw new Exception("Cargo é obrigatório!");
            }
            if (string.IsNullOrWhiteSpace(funcionario.DataDeAdmissao))
            {
                // Preenche automaticamente com a data de hoje
                funcionario.DataDeAdmissao = DateTime.Now.ToString("dd/MM/yyyy");
            }

            // Evita duplicidade de login
            if (funcionarios.Any(f => f.Login == funcionario.Login))
                throw new Exception("Já existe um funcionário com esse login!");

            funcionarios.Add(funcionario);
        }

        public void RedefinirSenha(string login, string novaSenha)
        {
            var funcionario = Database.Funcionarios.FirstOrDefault(f => f.Login == login);
            if (funcionario == null)
                throw new Exception("Funcionário não encontrado!");

            funcionario.Senha = novaSenha;
        }

        public List<FuncionarioDTO> ListarFuncionarios() => Database.Funcionarios;

        public void RemoverFuncionario(int id)
        {
            var funcionario = Database.Funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
                throw new Exception("Funcionário não encontrado.");

            Database.Funcionarios.Remove(funcionario);
        }
    }
}

