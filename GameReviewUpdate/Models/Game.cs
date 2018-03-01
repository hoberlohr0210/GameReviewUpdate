using System.Collections.Generic;

namespace GameReview.Models
{
    public class Game
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public GameType Type { get; set; }
        public ReviewGame Review { get; set; }
        public string Players { get; set; }
        public int ID { get; set; }
        public int TypeID { get; set; }
        public int ReviewID { get; set; }

        public IList<GameGenre> GameGenres { get; set; }

        

    }

}