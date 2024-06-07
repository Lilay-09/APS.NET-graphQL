namespace sync.Data.Repository
{
    public interface IRepository<T> where T: class
    {
        Task<T> Create(T ent);
    }
}
