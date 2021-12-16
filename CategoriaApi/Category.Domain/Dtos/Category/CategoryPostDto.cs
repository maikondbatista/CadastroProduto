using Newtonsoft.Json;

namespace Categories.Domain.Dtos
{
    public class CategoryPostDto : CategoryBaseDto
    {
        [JsonIgnore]
        public override long Id { get; set; } = 0;
        
    }
}
