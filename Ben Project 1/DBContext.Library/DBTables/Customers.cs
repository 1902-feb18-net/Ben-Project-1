using System;
using System.Collections.Generic;

namespace DBContext.Library
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultStoreId { get; set; }

        public virtual Stores DefaultStore { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
