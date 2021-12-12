using Products.Domain.Entites.Base;

namespace Products.Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
    }
}
