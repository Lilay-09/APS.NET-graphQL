using sync.Domain.Items;

namespace sync.Data.Repository.Items
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(Guid id);
    }
}
