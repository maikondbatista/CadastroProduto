namespace Products.Domain.Dtos
{
    public class ProductDto
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual long CategoryId { get; set; }
        public virtual DateTime? Created { get; set; }
        public virtual DateTime? Updated { get; set; }
    }
}
