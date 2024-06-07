using sync.Domain.UM;

namespace sync.Data.Repository.UM
{
    public interface IUMRepository
    {
        Task<User> Register(User user)
    }
}
