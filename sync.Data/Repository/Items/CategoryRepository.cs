using Microsoft.EntityFrameworkCore;
using sync.Domain.Items;

namespace sync.Data.Repository.Items
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public CategoryRepository()
        {
            if (_context == null)
            {
                _context = new DatabaseContext();
            }
        }
        public async Task<List<Category>> GetCategories()
        {
            List<Category> list = await _context.Categories.ToListAsync();
            return list;
        }
        public async Task<Category> GetCategory(Guid id)
        {
            Category details = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            return details;
        }
    }
}
