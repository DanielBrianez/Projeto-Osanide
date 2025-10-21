namespace OsanideDTO
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int QtdEstoque { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}
