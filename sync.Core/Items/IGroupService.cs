using sync.Domain.Response;

namespace sync.Core.Items
{
    public interface IGroupService
    {
        Task<ApiResponse<List<GroupResponse>>> GetGroupList();
        Task<ApiResponse<GroupResponse>> GetGroup(Guid id);
    }
}
