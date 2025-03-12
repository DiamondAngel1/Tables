using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Services{
    public class Repository<T> :IRepository<T> where T : class{
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;
        public Repository(Context context){
            _context = context;
            _dbSet = context.Set<T>();
        }
        public T? GetById(int id){
            return _dbSet.Find(id);
        }
        public IEnumerable<T> GetAll(){
            return _dbSet.ToList();
        }
        public IQueryable<T> GetQuery(){
            return _dbSet;
        }
        public void Add(T entity){
            _dbSet.Add(entity);
        }
        public void Delete(T entity) {
            _dbSet.Remove(entity);
        }
        public void SaveChanges(){
            _context.SaveChanges();
        }
    }
}
