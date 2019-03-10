using DBContext.Library;
using Project_1.BLL.Library.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ben_Project_1.Models
{
    public class StoreModel
    {
        public int StoreId { get; set; }

        public string Location { get; set; }

        public int DeluxePackageRemaining { get; set; }

        public decimal ShippingCosts { get; set; }

        public List<Inventory> Inventory { get; set; }

    }
}
