using GameReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReview.Models
{
    public class ReviewGame
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public string Name { get; set; }
        public IList<Game> Games { get; set; }
    }
}
