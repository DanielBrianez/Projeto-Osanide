using OsanideBLL;

namespace OsanideDesktop
{
    public partial class frmMainAdmin : Form
    {
        public frmMainAdmin()
        {
            InitializeComponent();
        }
        private void AbrirUserControl(UserControl uc)
        {
            panelConteudo.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(uc);

        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            AbrirUserControl(new ucHome());
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfig configurar = new frmConfig();
            configurar.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            AbrirUserControl(new ucProdutos());
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            AbrirUserControl(new ucFuncionarios());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmacao = mdSair.Show("Deseja realmente sair?");

                if (confirmacao == DialogResult.Yes)
                {
                    frmLogin principal = new frmLogin();
                    principal.Show();
                    Close();
                }
            }
            catch (Exception ex)
            {
                mdNotifica.Show($"Erro no sistema: {ex.Message}");
            }
        }

        private void frmMainAdmin_Load(object sender, EventArgs e)
        {
            AbrirUserControl(new ucHome());
            lblUsuario.Text = $"Seja bem-vindo(a) {AppSession.UsuarioLogado.Nome}!";
        }
    }
}

