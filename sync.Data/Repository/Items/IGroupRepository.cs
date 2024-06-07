using sync.Domain.Items;

namespace sync.Data.Repository.Items
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetGroupList();
        Task<Group> GetGroup(Guid id);
    }
}
