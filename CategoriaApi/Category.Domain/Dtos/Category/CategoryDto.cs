namespace Categories.Domain.Dtos.Category
{
    public class CategoryDto : CategoryBaseDto
    {
        public virtual IEnumerable<ProductDto> Products { get; set; }

    }
}
