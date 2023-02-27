namespace GameHouse.Models
{
    public class CombinedViewModel
    {
        public IEnumerable<GameHouse.Data.Gallery> Galleries { get; set; }
        public GameHouse.Data.Room Room { get; set; }

    }
}
