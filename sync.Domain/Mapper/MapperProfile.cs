using AutoMapper;
using sync.Domain.Items;
using sync.Domain.Response;

namespace sync.Domain.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<Group, GroupResponse>();
        }
    }
}
