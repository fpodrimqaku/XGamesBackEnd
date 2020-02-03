using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XGames.DTModels
{
    public class GameDTO : BaseDTO
    {


       // [StringLength(80, MinimumLength = 3), Required]
        public string Title { get; set; }


        //[Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

       // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Genre { get; set; }

       // [Range(1, 100), Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency)]
        public decimal Price { get; set; }

       // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), Required, StringLength(5)]
        public string Rating { get; set; }
        public string Description { get; set; }
        public ICollection<GamePictureDTO> Pictures { get; set; }
    }
}
