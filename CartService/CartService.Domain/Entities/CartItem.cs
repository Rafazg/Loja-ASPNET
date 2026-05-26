namespace CartService.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public string NomeProduto { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public int Quantidade { get; set; }
    }
}