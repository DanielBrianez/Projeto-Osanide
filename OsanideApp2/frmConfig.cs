using OsanideBLL;
using OsanideDAL;
using OsanideDTO;

namespace OsanideDesktop
{
    public partial class frmConfig : Form
    {
        private readonly FuncionarioBll funcionarioBLL = new();
        public frmConfig()
        {
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            txtNome.Text = AppSession.UsuarioLogado.Nome;
            txtUsuario.Text = AppSession.UsuarioLogado.Login;
            txtSenha.Text = AppSession.UsuarioLogado.Senha;
            txtEmail.Text = AppSession.UsuarioLogado.Email;
        }

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

            JsonDatabase.Salvar("funcionarios.json", funcionarios);
        }
        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void chkSenha_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkSenha.Checked)
            {
                txtSenha.UseSystemPasswordChar = false;
                chkSenha.Text = "Ocultar";
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                chkSenha.Text = "Exibir";
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            var usuario = AppSession.UsuarioLogado;

            if (usuario == null)
            {
                MessageBox.Show("Nenhum usuário encontrado");
                return;
            }

            var confirma = MessageBox.Show(
                $"{AppSession.UsuarioLogado.Nome}, deseja realmente excluir sua conta? Você será desconectado da sessão",
                "Confirmação", MessageBoxButtons.YesNo);

            if (confirma == DialogResult.Yes)
            {
                funcionarioBLL.RemoverFuncionario(AppSession.UsuarioLogado.Id);
            }

            MessageBox.Show($"Usuário(s) {AppSession.UsuarioLogado.Nome} removido(s) com sucesso!", "Exclusão de Usuários", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.OpenForms.OfType<frmMainFuncionarios>().FirstOrDefault()?.Close();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioAtualizado = new FuncionarioDTO
                {
                    Id = AppSession.UsuarioLogado.Id,
                    Nome = txtNome.Text,
                    Login = txtUsuario.Text,
                    Senha = txtSenha.Text,
                    Email = txtEmail.Text,
                };

                funcionarioBLL.AtualizarFuncionario(usuarioAtualizado);

                MessageBox.Show($"Usuário {usuarioAtualizado.Nome} atualizado com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
    }
}
