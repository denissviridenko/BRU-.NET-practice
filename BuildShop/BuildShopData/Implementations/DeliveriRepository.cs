using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildShopPresentationLayer.Implementations
{
    public class DeliveriRepository : IDeliveriRepository
    {
        private readonly BuildShopContext _context;

        public DeliveriRepository(BuildShopContext context)
        {
            _context = context;
        }

        public Task<bool> Create(DeliveriRepository entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Deliveri.Add(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<bool> Delete(DeliveriRepository entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            _context.Deliveri.Remove(entity);

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }

        public Task<List<Deliveri>> GetAll()
        {
            return _context.Deliveri.ToListAsync();
        }

        public Task<Deliveri> GetById(Guid id)
        {
            return _context.Deliveri.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Deliveri entity)
        {
            if (entity == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(_context.SaveChangesAsync().Result != 0);
        }
    }
}
