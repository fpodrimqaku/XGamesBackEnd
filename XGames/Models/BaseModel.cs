using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.Models
{
    public class BaseModel
    {
        public int ID {get;set;}
        public bool isActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
