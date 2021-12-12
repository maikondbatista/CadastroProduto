using Newtonsoft.Json;

namespace Categories.Domain.Dtos
{
    public class CategoryPostDto : CategoryDto
    {
        [JsonIgnore]
        public override long Id { get; set; } = 0;
        
        [JsonIgnore]
        public override List<ProductDto> Products { get; set; }
    }
}
