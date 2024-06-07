using sync.Domain.Items;

namespace sync.Domain.Response
{
    public class GroupResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryResponse Category { get; set; } = new CategoryResponse();
    }
}
