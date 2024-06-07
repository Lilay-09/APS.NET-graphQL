using GraphQL.Types;

namespace sync.Api.GraphQL
{
    public class QuerySchema:Schema
    {
        public QuerySchema(IServiceProvider serviceProvider):base(serviceProvider) {
            Query = serviceProvider.GetRequiredService<GraphQLQueries>();
        }
    }
}
