using AutoMapper;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using sync.Api.GraphQL;
using sync.Core.Items;
using sync.Data.Repository.Items;
using sync.Domain.Mapper;

namespace sync.Api.Configs
{
    public class ServiceConfig: IServiceConfig
    {
        public void Configure(IServiceCollection services)
        {
            //** mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //** service here
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IGroupService, GroupService>();

            //** repository here
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();

            //** graphQL here
            //** categery
            services.AddSingleton<CategoryType>();
            services.AddSingleton<GroupType>();
            services.AddScoped<GraphQLQueries>();
            services.AddScoped<ISchema, QuerySchema>();
            //* end groups
            services.AddGraphQL(opt => opt.EnableMetrics = false).AddSystemTextJson();
        }
    }
}
