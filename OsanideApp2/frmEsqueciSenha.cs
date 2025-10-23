using OsanideBLL;
using OsanideDAL;

namespace OsanideDesktop
{
    public partial class frmEsqueciSenha : Form
    {
        private readonly FuncionarioBll funcionarioBll = new FuncionarioBll();

        public frmEsqueciSenha()
        {
            InitializeComponent();

            // Deixar os TextBoxes de senha com bolinhas
            txtNovaSenha.UseSystemPasswordChar = true;
            txtConfirmarSenha.UseSystemPasswordChar = true;
        }

        // Checkbox para exibir/ocultar senha
        private void chkSenha_CheckedChanged(object sender, EventArgs e)
        {
            bool mostrar = chkSenha.Checked;
            txtNovaSenha.UseSystemPasswordChar = !mostrar;
            txtConfirmarSenha.UseSystemPasswordChar = !mostrar;
            chkSenha.Text = mostrar ? "Ocultar" : "Exibir";
        }

        // Botão para redefinir senha
        private void btnAtualizarSenha_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string novaSenha = txtNovaSenha.Text.Trim();
            string confirmarSenha = txtConfirmarSenha.Text.Trim();

            // 1️⃣ Validação de campos
            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(novaSenha) ||
                string.IsNullOrWhiteSpace(confirmarSenha))
            {
                MessageBox.Show("Preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (novaSenha != confirmarSenha)
            {
                MessageBox.Show("As senhas não coincidem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Verifica se o login existe
            var funcionario = Database.Funcionarios.FirstOrDefault(f => f.Login == login);
            if (funcionario == null)
            {
                MessageBox.Show("Login não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3️⃣ Atualiza a senha via BLL
                funcionarioBll.RedefinirSenha(login, novaSenha);

                MessageBox.Show("Senha redefinida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4️⃣ Limpa campos e foca no login
                txtLogin.Text = "";
                txtNovaSenha.Text = "";
                txtConfirmarSenha.Text = "";
                txtLogin.Focus();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
