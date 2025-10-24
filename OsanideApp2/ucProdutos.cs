using System.Data;
using System.Xml.Linq;
using OsanideBLL;
using OsanideDAL;
using OsanideDTO;

namespace OsanideDesktop
{
    public partial class ucProdutos : UserControl
    {
        ProdutoBLL produtoBLL = new();
        private int? produtoSelecionadoId = null;

        public ucProdutos()
        {
            InitializeComponent();
        }
        public void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                string.IsNullOrWhiteSpace(txtPreco.Text) ||
                string.IsNullOrWhiteSpace(txtQtdEstoque.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var produto = new ProdutoDTO
            {
                Id = Database.Funcionarios.Count + 1,
                Nome = txtNome.Text.Trim(),
                Categoria = txtCategoria.Text.Trim(),
                Descricao = txtDescricao.Text.Trim(),
                QtdEstoque = int.TryParse(txtQtdEstoque.Text, out var qtd) ? qtd : 0,
                Preco = double.TryParse(txtPreco.Text, out var preco) ? preco : 0
            };

            try
            {
                produtoBLL.CadastrarProduto(produto);
                MessageBox.Show($"Produto {produto.Nome} cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao cadastrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AtualizarGrid();
        }

        public bool ValidarCampos(out double preco, out int qtdEstoque)
        {
            preco = 0;
            qtdEstoque = 0;

            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtQtdEstoque.Text) ||
                string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!double.TryParse(txtPreco.Text, out preco))
            {
                MessageBox.Show("Preço inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreco.Focus();
                return false;
            }

            if (!int.TryParse(txtQtdEstoque.Text, out qtdEstoque))
            {
                MessageBox.Show("Quantidade em estoque inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQtdEstoque.Focus();
                return false;
            }

            return true;
        }

        public void LimparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtPreco.Text = "";
            txtQtdEstoque.Text = "";
            txtCategoria.Text = "";
            produtoSelecionadoId = null;
            btnAtualizar.Enabled = false;
        }

        public void AtualizarGrid()
        {
            dgProdutos.Columns.Clear();
            dgProdutos.AutoGenerateColumns = false;
            dgProdutos.RowTemplate.Height = 40;
            dgProdutos.AllowUserToAddRows = false;

            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Name = "Id" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", Name = "Nome" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição", Name = "Descricao" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QtdEstoque", HeaderText = "Qtd. Estoque", Name = "QtdEstoque" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoria", Name = "Categoria" });
            dgProdutos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preço", Name = "Preco" });

            var produtos = produtoBLL.ListarProdutos();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Descricao", typeof(string));
            dt.Columns.Add("QtdEstoque", typeof(int));
            dt.Columns.Add("Categoria", typeof(string));
            dt.Columns.Add("Preco", typeof(double));

            foreach (var f in produtos)
            {
                dt.Rows.Add(f.Id, f.Nome, f.Descricao, f.QtdEstoque, f.Categoria, f.Preco);
            }

            dgProdutos.DataSource = dt;
        }

        public void dgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgProdutos.Rows[e.RowIndex];

            produtoSelecionadoId = Convert.ToInt32(row.Cells["Id"].Value);
            txtNome.Text = row.Cells["Nome"].Value.ToString();
            txtCategoria.Text = row.Cells["Categoria"].Value.ToString();
            txtPreco.Text = row.Cells["Preco"].Value.ToString();
            txtDescricao.Text = row.Cells["Descricao"].Value.ToString();
            txtQtdEstoque.Text = row.Cells["QtdEstoque"].Value.ToString();

            btnAtualizar.Enabled = true;
        }

        public void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var produtoAtualizado = new ProdutoDTO
                {
                    Id = produtoSelecionadoId.Value,
                    Nome = txtNome.Text.Trim(),
                    Descricao = txtDescricao.Text.Trim(),
                    Categoria = txtCategoria.Text.Trim(),
                    Preco = double.TryParse(txtPreco.Text, out var preco) ? preco : 0,
                    QtdEstoque = int.TryParse(txtQtdEstoque.Text, out var qtd) ? qtd : 0
                };

                produtoBLL.AtualizarProduto(produtoAtualizado);

                MessageBox.Show($"Produto {produtoAtualizado.Nome} atualizado com sucesso!");
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        public void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para excluir.");
                return;
            }

            int id = dgProdutos.SelectedRows[0].Cells["Id"]
                .Value.GetHashCode();

            string nome = dgProdutos.SelectedRows[0].Cells["Nome"].Value.ToString();

            var confirmacao = MessageBox.Show(
                $"Tem certeza que deseja excluir o produto {nome}?",
                "Confirmação", MessageBoxButtons.YesNo);

            if (confirmacao == DialogResult.Yes)
            {
                produtoBLL.RemoverProduto(id);
                MessageBox.Show($"Produto {nome} removido com sucesso!");
                AtualizarGrid();
            }
        }
        
        public void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            BuscarProduto();
        }

        public void BuscarProduto()
        {
            string termo = txtPesquisa.Text.Trim().ToLower();

            var filtrados = produtoBLL.ListarProdutos()
                .Where(p => p.Nome.ToLower().Contains(termo))
                .ToList();

            dgProdutos.DataSource = filtrados;
        }

        public void btnPesquisa_Click(object sender, EventArgs e)
        {
            BuscarProduto();
        }

        public void ucProdutos_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}
