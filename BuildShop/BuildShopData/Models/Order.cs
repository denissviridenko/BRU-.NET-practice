using System;
using System.Collections.Generic;

namespace BuildShopPresentationLayer
{
    public partial class Order
    {
        public int Id { get; set; }
        public string ClientMobilePhone { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
    }
}
