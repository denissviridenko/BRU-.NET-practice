using BuildShopPresentationLayer;
using Microsoft.EntityFrameworkCore;

namespace BuildShopPresentationLayer.Implementations
{
    public class ItemsCategoryRepository : IItemsCategoryRepository
    {
        private readonly BuildShopContext _context;

        public ItemsCategoryRepository(BuildShopContext context)
        {
            _context = context;
        }

        public Task<bool> Create(ItemsCategory entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.ItemsCategories.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(ItemsCategory entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.ItemsCategories.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<ItemsCategory>> GetAll()
        {
            return _context.ItemsCategories.ToListAsync();
        }

        public Task<ItemsCategory> GetById(Guid id)
        {
            return _context.ItemsCategories.FirstOrDefaultAsync(x => x.Id == id);
        }


        public Task<bool> Update(ItemsCategory entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.ItemsCategories.Update(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
