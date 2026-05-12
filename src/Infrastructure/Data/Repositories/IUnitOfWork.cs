using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Product> Products { get; }
        Task SaveAsync();
    }
}
