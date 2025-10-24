using OsanideDTO;
using OsanideDAL;

namespace OsanideBLL
{
    public class ProdutoBLL
    {
        public void CadastrarProduto(ProdutoDTO produto)
        {
            // Validações
            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("Nome do produto é obrigatório!");
            if (string.IsNullOrWhiteSpace(produto.Descricao))
                throw new Exception("A descrição do produto é obrigatória!");
            if (produto.Preco <= 0)
                throw new Exception("Preço do produto é obrigatório!");
            if (produto.QtdEstoque < 0)
                throw new Exception("A quantidade de produtos deve ser maior que 0!");
            if (string.IsNullOrWhiteSpace(produto.Categoria))
                throw new Exception("A categoria do produto é obrigatória!");

            // Adiciona na lista
            var produtos = Database.Produtos;
            produtos.Add(produto);
            Database.Produtos = produtos; // garante que a lista seja atualizada
        }

        public List<ProdutoDTO> ListarProdutos()
        {
            Database.Produtos = JsonDatabase.Ler<ProdutoDTO>("Produtos.json"); // Recarrega do arquivo
            return Database.Produtos;
        }

        public void AtualizarProduto(ProdutoDTO produtoAtualizado)
        {
            var produtos = JsonDatabase.Ler<ProdutoDTO>("produtos.json");

            var produtoExistente = produtos.FirstOrDefault(p => p.Id == produtoAtualizado.Id);
            if (produtoExistente == null)
                throw new Exception("Funcionário não encontrado!");

            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Preco = produtoAtualizado.Preco;
            produtoExistente.Descricao = produtoAtualizado.Descricao;
            produtoExistente.QtdEstoque = produtoAtualizado.QtdEstoque;
            produtoExistente.Categoria = produtoAtualizado.Categoria;

            JsonDatabase.Salvar("produtos.json", produtos);

        }

        public void RemoverProduto(int id)
        {
            var produtos = JsonDatabase.Ler<ProdutoDTO>("produtos.json");
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produtos.Remove(produto);
            JsonDatabase.Salvar("produtos.json", produtos);
        }
    }
}
