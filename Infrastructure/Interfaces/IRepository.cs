namespace Infrastructure.Interfaces{
    public interface IRepository<T> where T : class{
        T? GetById(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> GetQuery();
        void Add(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}