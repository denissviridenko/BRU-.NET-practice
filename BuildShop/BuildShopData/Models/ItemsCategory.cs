using System;
using System.Collections.Generic;

namespace BuildShopPresentationLayer
{
    public partial class ItemsCategory
    {
        public ItemsCategory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
