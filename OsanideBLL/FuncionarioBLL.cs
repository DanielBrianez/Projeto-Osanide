using OsanideDTO;
using OsanideDAL;

namespace OsanideBLL
{
    public class FuncionarioBll
    {
        // ✅ LOGIN
        public FuncionarioDTO Login(string login, string senha)
        {
            var funcionarios = JsonDatabase.Ler<FuncionarioDTO>("funcionarios.json");
            var funcionario = funcionarios.FirstOrDefault(f => f.Login == login && f.Senha == senha);

            if (funcionario == null)
                throw new Exception("Usuário ou senha inválidos.");

            return funcionario;
        }

        // ✅ CADASTRAR FUNCIONÁRIO
        public void CadastrarFuncionario(FuncionarioDTO funcionario)
        {
            var funcionarios = JsonDatabase.Ler<FuncionarioDTO>("funcionarios.json");

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
                throw new Exception("Cargo é obrigatório!");

            if (string.IsNullOrWhiteSpace(funcionario.DataDeAdmissao))
                funcionario.DataDeAdmissao = DateTime.Now.ToString("dd/MM/yyyy");

            // Evita duplicidade de login
            if (funcionarios.Any(f => f.Login == funcionario.Login))
                throw new Exception("Já existe um funcionário com esse login!");

            // Define novo ID (caso não exista)
            funcionario.Id = funcionarios.Any() ? funcionarios.Max(f => f.Id) + 1 : 1;

            funcionarios.Add(funcionario);
            JsonDatabase.Salvar("funcionarios.json", funcionarios);
        }

        // ✅ REDEFINIR SENHA
        public void RedefinirSenha(string login, string novaSenha)
        {
            var funcionarios = JsonDatabase.Ler<FuncionarioDTO>("funcionarios.json");
            var funcionario = funcionarios.FirstOrDefault(f => f.Login == login);
            if (funcionario == null)
                throw new Exception("Funcionário não encontrado!");

            funcionario.Senha = novaSenha;
            JsonDatabase.Salvar("funcionarios.json", funcionarios);
        }

        // ✅ LISTAR FUNCIONÁRIOS
        public List<FuncionarioDTO> ListarFuncionarios()
        {
            return JsonDatabase.Ler<FuncionarioDTO>("funcionarios.json");
        }

        // ✅ REMOVER FUNCIONÁRIO
        public void RemoverFuncionario(int id)
        {
            var funcionarios = JsonDatabase.Ler<FuncionarioDTO>("funcionarios.json");
            var funcionario = funcionarios.FirstOrDefault(f => f.Id == id);
            if (funcionario == null)
                throw new Exception("Funcionário não encontrado.");

            funcionarios.Remove(funcionario);
            JsonDatabase.Salvar("funcionarios.json", funcionarios);
        }

        // ✅ ATUALIZAR FUNCIONÁRIO
        public void AtualizarFuncionario(FuncionarioDTO funcionarioAtualizado)
        {
            var funcionarios = JsonDatabase.Ler<FuncionarioDTO>("funcionarios.json");

            var funcionarioExistente = funcionarios.FirstOrDefault(f => f.Id == funcionarioAtualizado.Id);
            if (funcionarioExistente == null)
                throw new Exception("Funcionário não encontrado!");

            funcionarioExistente.Nome = funcionarioAtualizado.Nome;
            funcionarioExistente.Login = funcionarioAtualizado.Login;
            funcionarioExistente.Senha = funcionarioAtualizado.Senha;
            funcionarioExistente.Email = funcionarioAtualizado.Email;
            funcionarioExistente.Cargo = funcionarioAtualizado.Cargo;
            funcionarioExistente.DataDeAdmissao = funcionarioAtualizado.DataDeAdmissao;
            funcionarioExistente.TipoUsuario = funcionarioAtualizado.TipoUsuario;

            JsonDatabase.Salvar("funcionarios.json", funcionarios);

            // Atualiza sessão, se for o usuário logado
            if (AppSession.UsuarioLogado.Id == funcionarioAtualizado.Id)
                AppSession.UsuarioLogado = funcionarioExistente;
        }
    }
}
