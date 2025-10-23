using OsanideDTO;

namespace OsanideDAL
{
    public static class Database
    {
        public static List<ProdutoDTO> Produtos
        {
            get => JsonDatabase.Ler<ProdutoDTO>("produtos.Json");
            set => JsonDatabase.Salvar("produtos.Json", value);
        }
        public static List<FuncionarioDTO> Funcionarios
        {
            get => JsonDatabase.Ler<FuncionarioDTO>("funcionarios.Json");
            set => JsonDatabase.Salvar("funcionarios.Json", value);
        }

        public static List<ProdutoDTO> QtdEstoque
        {
            get => JsonDatabase.Ler<ProdutoDTO>("qtdEstoque.Json");
            set => JsonDatabase.Salvar("qtdEstoque.Json", value);
        }
    }
}
