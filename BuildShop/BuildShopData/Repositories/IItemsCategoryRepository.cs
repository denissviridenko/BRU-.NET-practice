using BuildShopPresentationLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BuildShopDataAccessLayer.Repositories
{
    public interface IItemsCategoryRepository : IBaseRepository<ItemsCategory>
    {
        Task<List<ItemsCategory>> GetRange(List<Guid> workIds);
    }
}
