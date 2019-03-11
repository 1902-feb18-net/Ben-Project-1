using Project_1.BLL.Library.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ben_Project_1.Models
{
    public class OrderModel
    {

        public OrderModel()
        {
            Editions = new Dictionary<int, string>();

        }

        [Display(Name = "ID")]
        public int OrderId { get; set; }

        [Display(Name = "Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer ID")]
        public int OrderCustomerId { get; set; }

        [Display(Name = "Total Cost")]
        public decimal OrderCost { get; set; }

        [Display(Name = "Store ID")]
        public int OrderStoreId { get; set; }

        public List<OrderGamesImp> OrderGames { get; set; }

        public OrderGamesImp NextOrderGame { get; set; }

        public List<StoreImp> Stores { get; set; }

        public List<GamesImp> Games { get; set; }

        public Dictionary<int, string> Editions;

    }
}
