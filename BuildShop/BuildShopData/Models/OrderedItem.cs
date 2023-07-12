using System;
using System.Collections.Generic;

namespace BuildShopPresentationLayer
{
    public partial class OrderedItem
    {
        public int OrderId { get; set; }
        public int Item { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
