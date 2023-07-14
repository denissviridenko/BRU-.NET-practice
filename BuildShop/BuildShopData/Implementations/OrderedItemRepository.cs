using BuildShopPresentationLayer;
using Microsoft.EntityFrameworkCore;

namespace BuildShopPresentationLayer.Implementations
{
    public class OrderedItemRepository : IOrderedItemRepository
    {
        private readonly BuildShopContext _context;

        public OrderedItemRepository(BuildShopContext context)
        {
            _context = context;
        }

        public Task<bool> Create(OrderedItem entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.OrderedItems.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(OrderedItem entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.OrderedItems.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<OrderedItem>> GetAll()
        {
            return _context.OrderedItems.ToListAsync();
        }

        public Task<OrderedItem> GetById(Guid id)
        {
            return _context.OrderedItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(OrderedItem entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.OrderedItems.Update(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
