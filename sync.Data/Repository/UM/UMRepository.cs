using sync.Domain.UM;

namespace sync.Data.Repository.UM
{
    public class UMRepository:IUMRepository
    {
        private readonly DatabaseContext _context;
        public UMRepository(DatabaseContext context)
        {
            _context = context;
        }
        public UMRepository() {
            _context = new DatabaseContext();
        }

        public async Task<User> Register(User user)
        {
            try
            {
                User create = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Paswword = user.Paswword,
                    Email = user.Email,
                    Phone = user.Phone,
                };
                await _context.AddAsync(create);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new ArgumentException("Fail " + ex);
                
            }
            return user;
        }
    }
}
