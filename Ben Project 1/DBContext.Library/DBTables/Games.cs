using System;
using System.Collections.Generic;

namespace DBContext.Library
{
    public partial class Games
    {
        public Games()
        {
            Inventory = new HashSet<Inventory>();
            OrderGames = new HashSet<OrderGames>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal StandardPrice { get; set; }
        public decimal AdvancedPrice { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrderGames> OrderGames { get; set; }
    }
}
