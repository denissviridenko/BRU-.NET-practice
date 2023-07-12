using System;
using System.Collections.Generic;

namespace BuildShopPresentationLayer
{
    public partial class Delivery
    {
        public int OrderedId { get; set; }
        public string Address { get; set; } = null!;

        public virtual Order Ordered { get; set; } = null!;
    }
}
