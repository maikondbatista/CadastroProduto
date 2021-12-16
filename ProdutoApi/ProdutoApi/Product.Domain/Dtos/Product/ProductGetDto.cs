namespace Products.Domain.Dtos.Product
{
    public class ProductGetDto : ProductDto
    {
        public CategoryDto category { get; set; }
    }
}
