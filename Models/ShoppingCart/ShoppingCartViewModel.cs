namespace Shop.Models.ShoppingCart
{
    public class ShoppingCartProductsViewModel
    {
        public Guid ShoppingCartId { get; set; }
        public int Id { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
