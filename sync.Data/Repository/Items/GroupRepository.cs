using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sync.Domain.Items;
using sync.Domain.Response;

namespace sync.Data.Repository.Items
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public GroupRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GroupRepository()
        {
            if (_context == null)
            {
                _context = new DatabaseContext();
            }
        }
        public async Task<List<Group>> GetGroupList()
        {
            List<Group> list = await _context.Groups
             .Join(_context.Categories,
                   g => g.CategoryId,
                   c => c.Id,
                   (g, c) => new { Group = g, Category = c })
             .Select(gc => new Group
             {
                 Id = gc.Group.Id,
                 Name = gc.Group.Name,
                 Category = new Category { Id = gc.Category.Id, Name = gc.Category.Name }
             })
             .ToListAsync();
            return list;
        }
        public async Task<Group> GetGroup(Guid id)
        {
            Group details = await _context.Groups.FirstOrDefaultAsync(c => c.Id == id);
            return details;
        }
    }
}
