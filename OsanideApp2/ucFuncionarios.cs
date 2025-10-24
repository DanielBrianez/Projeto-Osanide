using System.Data;
using OsanideBLL;
using OsanideDAL;
using OsanideDTO;

namespace OsanideDesktop
{
    public partial class ucFuncionarios : UserControl
    {
        FuncionarioBll funcionarioBLL = new();
        private int? funcionarioSelecionadoId = null;
        public ucFuncionarios()
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
                funcionarioBLL.CadastrarFuncionario(funcionario);
                MessageBox.Show($"Funcionário {funcionario.Nome} cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AtualizarGrid();
        }

        private void ucFuncionarios_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
            cboCargo.DataSource = Enum.GetValues(typeof(TipoUsuario));
            cboCargo.SelectedIndex = -1;
        }

        private void AtualizarGrid()
        {
            dgFuncionarios.Columns.Clear();
            dgFuncionarios.AutoGenerateColumns = false;
            dgFuncionarios.RowTemplate.Height = 40;
            dgFuncionarios.AllowUserToAddRows = false;

            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", Name = "Nome" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "User", Name = "Login" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Name = "Email" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha", Name = "Senha" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cargo", HeaderText = "Cargo", Name = "Cargo" });
            dgFuncionarios.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DataDeAdmissao", HeaderText = "Data de Admissão", Name = "DataDeAdmissao" });

            var funcionarios = funcionarioBLL.ListarFuncionarios();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Login", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Senha", typeof(string));
            dt.Columns.Add("Cargo", typeof(string));
            dt.Columns.Add("DataDeAdmissao", typeof(DateTime));

            foreach (var f in funcionarios)
            {
                dt.Rows.Add(f.Id, f.Nome, f.Login, f.Senha, f.Cargo, f.Email, f.DataDeAdmissao);
            }

            dgFuncionarios.DataSource = dt;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioAtualizado = new FuncionarioDTO
                {
                    Id = funcionarioSelecionadoId.Value,
                    Nome = txtNome.Text,
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text,
                    Email = txtEmail.Text,
                    TipoUsuario = (TipoUsuario)cboCargo.SelectedItem
                };

                funcionarioBLL.AtualizarFuncionario(usuarioAtualizado);

                MessageBox.Show($"Funcionario {usuarioAtualizado.Nome} atualizado com sucesso!");
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgFuncionarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um funcionário para excluir.");
                return;
            }

            int id = dgFuncionarios.SelectedRows[0].Cells["Id"]
                .Value.GetHashCode();

            string nome = dgFuncionarios.SelectedRows[0].Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show(
                $"Tem certeza que deseja excluir o funcionário {nome}?",
                "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                funcionarioBLL.RemoverFuncionario(id);
                MessageBox.Show($"Funcionário {nome} removido com sucesso!");
                AtualizarGrid();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            BuscarFuncionario();
        }

        private void BuscarFuncionario()
        {
            string termo = txtPesquisa.Text.Trim().ToLower();

            var filtrados = funcionarioBLL.ListarFuncionarios()
                                    .Where(funcionario => funcionario.Nome.ToLower().Contains(termo))
                                    .Select(funcionario => new
                                    {
                                        funcionario.Id,
                                        funcionario.Nome,
                                        funcionario.Email,
                                        funcionario.Login,
                                        funcionario.Senha,
                                        funcionario.Cargo,
                                        funcionario.DataDeAdmissao

                                    }).ToList();

            dgFuncionarios.DataSource = filtrados;
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarFuncionario();
        }

        private void dgFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgFuncionarios.Rows[e.RowIndex];

            funcionarioSelecionadoId = Convert.ToInt32(row.Cells["Id"].Value);
            txtNome.Text = row.Cells["Nome"].Value.ToString();
            txtLogin.Text = row.Cells["Login"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtSenha.Text = row.Cells["Senha"].Value.ToString();
            txtData.Text = row.Cells["DataDeAdmissao"].Value.ToString();

            if (Enum.TryParse(row.Cells["Cargo"].Value.ToString(), out TipoUsuario tipo))
            {
                cboCargo.SelectedItem = tipo;
            }

            btnAtualizar.Enabled = true;
        }
    }
}
