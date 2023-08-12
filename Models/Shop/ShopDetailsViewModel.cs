namespace Shop.Models.Shop
{
    public class ShopDetailsViewModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        public string ModelType { get; set; }

        public string Category { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }
    }
}
