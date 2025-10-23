using OsanideBLL;
using OsanideDAL;
using OsanideDTO;

namespace OsanideDesktop
{
    public partial class frmCadastrar : Form
    {
        private readonly FuncionarioBll FuncionarioBll = new FuncionarioBll();

        public frmCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtLogin.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboCargo.SelectedValue == null)
            {
                MessageBox.Show("Selecione um cargo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(txtData.Text, out DateTime dataAdmissao))
            {
                MessageBox.Show("Data de admissão inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var funcionario = new FuncionarioDTO
            {
                Id = Database.Funcionarios.Count + 1,
                Nome = txtNome.Text.Trim(),
                Login = txtLogin.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Senha = txtSenha.Text.Trim(),
                Cargo = (int)cboCargo.SelectedValue,
                DataDeAdmissao = dataAdmissao.ToString("dd/MM/yyyy"),
                TipoUsuario = (TipoUsuario)cboCargo.SelectedItem
            };



            try
            {
                FuncionarioBll.CadastrarFuncionario(funcionario);
                MessageBox.Show($"Funcionário {funcionario.Nome} cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtData.Text = string.Empty;
            cboCargo.SelectedIndex = -1;
        }

        private void txtNome_Click(object sender, EventArgs e) => txtNome.Text = string.Empty;
        private void txtLogin_Click(object sender, EventArgs e) => txtLogin.Text = string.Empty;
        private void txtEmail_Click(object sender, EventArgs e) => txtEmail.Text = string.Empty;
        private void txtSenha_Click(object sender, EventArgs e) => txtSenha.Text = string.Empty;

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            var confirmacao = mdSair.Show("Deseja realmente sair?");

            if (confirmacao == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmCadastrar_Load(object sender, EventArgs e)
        {
            cboCargo.DataSource = Enum.GetValues(typeof(TipoUsuario));
            cboCargo.SelectedIndex = 0; // seleciona a primeira opção por padrão
        }

        private void chkSenha_CheckedChanged(object sender, EventArgs e)
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
    }
}

