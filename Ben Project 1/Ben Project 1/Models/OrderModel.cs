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
        [Display(Name = "ID")]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderCustomerId { get; set; }

        public decimal OrderCost { get; set; }

        public int OrderStoreId { get; set; }

        public List<OrderGamesImp> OrderGames { get; set; }

        public OrderGamesImp NextOrderGame { get; set; }

        public List<StoreImp> Stores { get; set; }

        public List<GamesImp> Games { get; set; }
    }
}
