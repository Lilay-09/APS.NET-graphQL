using GraphQL.Types;
using sync.Domain.Items;
using sync.Domain.Response;


namespace sync.Api.GraphQL
{
    public class CategoryType : ObjectGraphType<CategoryResponse>
    {
        public CategoryType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            //Field<CategoryType>("category", arguments);
        }
    }
}
