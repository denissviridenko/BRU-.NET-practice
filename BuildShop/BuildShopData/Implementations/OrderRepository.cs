using BuildShopDataAccessLayer.Repositories;
using BuildShopPresentationLayer;
using Microsoft.EntityFrameworkCore;

namespace BuildShopPresentationLayer.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BuildShopContext _context;

        public OrderRepository(BuildShopContext context)
        {
            _context = context;
        }

        public Task<bool> Create(Order entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Orders.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(Order entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Orders.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<Order>> GetAll()
        {
            return _context.Orders.ToListAsync();
        }

        public Task<Order> GetById(Guid id)
        {
            return _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Order entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Orders.Update(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
