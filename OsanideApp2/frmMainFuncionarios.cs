using OsanideBLL;

namespace OsanideDesktop
{
    public partial class frmMainFuncionarios : Form
    {
        public frmMainFuncionarios()
        {
            InitializeComponent();
        }
        private void AbrirUserControl(UserControl uc)
        {
            panelConteudo.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(uc);

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

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            panelConteudo.Controls.Clear();
            AbrirUserControl(new ucProdutos());
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            AbrirUserControl(new ucProdutos());
            lblUsuario.Text = $"Seja bem-vindo(a) {AppSession.UsuarioLogado.Nome}!";
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfig configurar = new frmConfig();
            configurar.Show();
        }
    }
}
