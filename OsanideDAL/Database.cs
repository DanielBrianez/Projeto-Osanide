using OsanideDTO;

namespace OsanideDAL
{
    public static class Database
    {
        public static List<ProdutoDTO> Produtos
        {
            get => JsonDatabase.Ler<ProdutoDTO>("Produtos.Json");
            set => JsonDatabase.Salvar("Produtos.Json", value);
        }
        public static List<FuncionarioDTO> Funcionarios
        {
            get => JsonDatabase.Ler<FuncionarioDTO>("Funcionarios.Json");
            set => JsonDatabase.Salvar("Funcionarios.Json", value);
        }
    }
}
