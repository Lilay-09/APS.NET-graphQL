
using GraphQL.Types;
using sync.Domain.Response;

namespace sync.Api.GraphQL
{
    public class GroupType : ObjectGraphType<GroupResponse>
    {
        public GroupType()
        {

            Field(x => x.Id);
            Field(x => x.Name);
            Field<CategoryType>("category", resolve: context => context.Source.Category);
        }
    }
}
