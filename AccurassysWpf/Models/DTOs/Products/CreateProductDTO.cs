namespace AccurassysWpf.Models.DTOs.Products
{
    public class CreateProductDto
    {
        public string Image { get; set; } = String.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public double OldPrice { get; set; } = 0;
        public string Installment { get; set; } = string.Empty;
    }
}
