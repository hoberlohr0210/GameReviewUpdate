using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReview.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<GameGenre> GameGenres { get; set; }
    }
}
