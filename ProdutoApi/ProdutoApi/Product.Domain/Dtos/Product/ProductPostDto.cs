using Newtonsoft.Json;

namespace Products.Domain.Dtos
{
    public class ProductPostDto : ProductDto
    {
        [JsonIgnore]
        public override long Id { get; set; } = 0;
    }
}
