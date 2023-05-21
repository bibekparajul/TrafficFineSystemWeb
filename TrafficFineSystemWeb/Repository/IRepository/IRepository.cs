using System.Linq.Expressions;

namespace TrafficFineSystemWeb.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
       
        T GetFirstorDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
       
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        void Add(T entity);

        //update ko lagi generic repo ma narakhney

        //for Delete
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
