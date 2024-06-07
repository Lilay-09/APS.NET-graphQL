using AutoMapper;
using sync.Data.Repository.Items;
using sync.Domain.Response;

namespace sync.Core.Items
{
    public class GroupService: IGroupService
    {
        private readonly IMapper _mapper;

        private readonly IGroupRepository _groupRepository;
        public GroupService(IMapper mapper,IGroupRepository groupRepository) {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }
        public async Task<ApiResponse<List<GroupResponse>>> GetGroupList() {
            var apiRes = new ApiResponse<List<GroupResponse>>();
            var list = await _groupRepository.GetGroupList();
            var result = _mapper.Map<List<GroupResponse>>(list);
            apiRes.Data = result;
            return apiRes;
        }

        public async Task<ApiResponse<GroupResponse>> GetGroup(Guid id)
        {
            var apiRes = new ApiResponse<GroupResponse>();
            var details = await _groupRepository.GetGroup(id);
            var result = _mapper.Map<GroupResponse>(details);
            if (details != null)
            {
                apiRes.Data = result;
            }
            else
            {
                apiRes.Data = null;
            }
            return apiRes;
        }
    }
}
