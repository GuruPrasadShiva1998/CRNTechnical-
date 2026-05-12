using Domain.Entities;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<Product> Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new GenericRepository<Product>(context);
        }

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
