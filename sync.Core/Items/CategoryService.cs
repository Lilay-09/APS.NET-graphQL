using AutoMapper;
using sync.Data.Repository.Items;
using sync.Domain.Response;

namespace sync.Core.Items
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<CategoryResponse>>> GetCategories()

        {
            var apiRes = new ApiResponse<List<CategoryResponse>>();
            apiRes.StatusCode = System.Net.HttpStatusCode.OK;
            var list = await _categoryRepository.GetCategories();
            var res = _mapper.Map<List<CategoryResponse>>(list);
        
            apiRes.Data = res;
            return apiRes;
        }

        public async Task<ApiResponse<CategoryResponse>> GetCategory(Guid id)
        {
            var apiRes = new ApiResponse<CategoryResponse>();
            CategoryResponse result = new CategoryResponse();
            var details = await _categoryRepository.GetCategory(id);
            if (details != null)
            {
                apiRes.Data = _mapper.Map<CategoryResponse>(details);
            }
            else
            {
                apiRes.IsSuccess = false;
                apiRes.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return apiRes;
        }
    }
}
