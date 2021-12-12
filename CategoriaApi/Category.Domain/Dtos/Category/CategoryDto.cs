namespace Categories.Domain.Dtos
{
    public class CategoryDto
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }
        public virtual List<ProductDto> Products { get; set; }
    }
}
