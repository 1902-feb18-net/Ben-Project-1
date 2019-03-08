using System;
using System.Collections.Generic;

namespace DBContext.Library
{
    public partial class Orders
    {
        public Orders()
        {
            OrderGames = new HashSet<OrderGames>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderCustomerId { get; set; }
        public decimal OrderCost { get; set; }
        public int OrderStoreId { get; set; }

        public virtual Customers OrderCustomer { get; set; }
        public virtual Stores OrderStore { get; set; }
        public virtual ICollection<OrderGames> OrderGames { get; set; }
    }
}
