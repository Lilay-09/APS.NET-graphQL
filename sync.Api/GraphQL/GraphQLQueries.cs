using GraphQL;
using GraphQL.Types;
using sync.Core.Items;
using sync.Domain.Items;
using sync.Domain.Response;

namespace sync.Api.GraphQL
{
    public class GraphQLQueries:ObjectGraphType
    {
        public GraphQLQueries(ICategoryService categoryService,IGroupService _groupService) {
            FieldAsync<ListGraphType<CategoryType>>(
                name: "categories",
                resolve: async context =>
                {
                    try
                    {
                        var categories = await categoryService.GetCategories();
                        return categories.Data ?? new List<CategoryResponse>();
                    }
                    catch (Exception ex)
                    {
                        // Log the error
                        Console.WriteLine($"Error fetching categories: {ex.Message}");
                        return new List<Category>(); // Return empty list in case of error
                    }
                }
            );
            FieldAsync<CategoryType>(
            Name = "category",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
                resolve: async x =>
                {
                    try
                    {
                        var categoryId = x.GetArgument<Guid>("id");
                        var details = await categoryService.GetCategory(categoryId);
                        return details.Data ?? null;
                    }
                    catch (Exception ex)
                    {
                        // Log the error
                        Console.WriteLine($"Error fetching category: {ex.Message}");
                        return null; // Return null in case of error
                    }
                }
            );


            FieldAsync<ListGraphType<GroupType>>(
               name: "groups",
               resolve: async context =>
               {
                   try
                   {
                       var group = await _groupService.GetGroupList();
                       return group.Data ?? new List<GroupResponse>();
                   }
                   catch (Exception ex)
                   {
                       // Log the error
                       Console.WriteLine($"Error fetching groups: {ex.Message}");
                       return new List<GroupType>(); // Return empty list in case of error
                   }
               }
           );
        }
    }
}
