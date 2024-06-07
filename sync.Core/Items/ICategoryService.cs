using sync.Domain.Response;

namespace sync.Core.Items
{
    public interface ICategoryService
    {

        Task<ApiResponse<List<CategoryResponse>>> GetCategories();
        Task<ApiResponse<CategoryResponse>> GetCategory(Guid id);
    }
}
