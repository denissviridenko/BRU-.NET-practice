using BuildShopPresentationLayer;
using BuildShopPresentationLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildShopPresentationLayer.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private readonly BuildShopContext _context;

        public ItemRepository(BuildShopContext context)
        {
            _context = context;
        }

        public Task<bool> Create(Item entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Items.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(Item entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Items.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<Item>> GetAll()
        {
            return _context.Items.ToListAsync();
        }

        public Task<Item> GetById(Guid id)
        {
            return _context.Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Item entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Items.Update(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
