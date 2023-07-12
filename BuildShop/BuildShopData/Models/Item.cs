using System;
using System.Collections.Generic;

namespace BuildShopPresentationLayer
{
    public partial class Item
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Name { get; set; } = null!;
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string OriginCountry { get; set; } = null!;

        public virtual ItemsCategory CategoryNavigation { get; set; } = null!;
    }
}
