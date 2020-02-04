using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XGames.Models;

namespace XGames.DTModels
{
    public class CartDTO: BaseDTO
    {

        public bool checkedOut { get; set; }
        public decimal total { get; set; }
        public ICollection<LineItemDTO> LineItems { get; set; }

    }
}
