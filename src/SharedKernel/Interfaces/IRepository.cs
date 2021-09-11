using System.Threading.Tasks;


namespace SharedKernel.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<T> AddAsync<T>(T entity);
        Task<T> UpdateAsync<T>(T entity);
        Task<T> DeleteAsync<T>(T entity);
    }
}