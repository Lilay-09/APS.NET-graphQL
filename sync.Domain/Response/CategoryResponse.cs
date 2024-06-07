using System.Text.RegularExpressions;

namespace sync.Domain.Response
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public List<Group> Groups = new List<Group>();
    }
}
