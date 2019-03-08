using System;
using System.Collections.Generic;

namespace DBContext.Library
{
    public partial class OrderGames
    {
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int GameQuantity { get; set; }
        public int Edition { get; set; }
        public decimal Price { get; set; }

        public virtual Games Game { get; set; }
        public virtual Orders Order { get; set; }
    }
}
