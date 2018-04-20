using System.Collections.Generic;

namespace GameReview.Models
{
    public class GameType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Game> Games { get; set; }
        //[ForeignKey("GamesId")]
        //public virtual Game Games { get; set; }
    }
}
