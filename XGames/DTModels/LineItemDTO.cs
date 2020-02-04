using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.DTModels
{
    public class LineItemDTO :BaseDTO
    {

        public int quantity { get; set; }
        public int GameId { get; set; }
        public int CartId { get; set; }

    }
}
