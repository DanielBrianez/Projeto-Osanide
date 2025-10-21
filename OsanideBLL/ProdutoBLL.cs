using OsanideDTO;
using OsanideDAL;

namespace OsanideBLL
{
    public class ProdutoBLL
    {
        public void CadastrarProduto(ProdutoDTO produto)
        {
            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new Exception("Nome do produto é obrigatório!");
            }

            if (string.IsNullOrWhiteSpace(produto.Descricao))
            {
                throw new Exception("A descrição do produto é obrigatória!");
            }

            if (produto.Preco <= 0)
            {
                throw new Exception("Preço do produto é obrigatório!");
            }

            if (produto.QtdEstoque < 0)
            {
                throw new Exception("A quantidade de produtos deve ser maior que 0!");
            }

            if (string.IsNullOrWhiteSpace(produto.Categoria))
            {
                throw new Exception("A categoria do produto é obrigatória!");
            }
        }
        public List<ProdutoDTO> ListarProdutos() => Database.Produtos;

        public void AtualizarProduto(ProdutoDTO produto)
        {
            var produtoExistente = Database.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (produtoExistente == null)
                throw new Exception("Produto não encontrado.");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("Nome do produto é obrigatório.");

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Categoria = produto.Categoria;
            produtoExistente.QtdEstoque = produto.QtdEstoque;
        }

        public void RemoverProduto(int id)
        {
            var produto = Database.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            Database.Produtos.Remove(produto);
        }
    }
}
