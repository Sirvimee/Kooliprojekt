using ServiceStack.DataAnnotations;
using System.ComponentModel;

namespace GameHouse.Data
{
    public class Room
    {
        [AutoIncrement]
        public int Id { get; set; }

        [DisplayName("Toa nimi")]
        public string Name { get; set; }

        [DisplayName("Kirjeldus")]
        public string Description { get; set; }

        [DisplayName("Hind")]
        public string Price { get; set; }

        [DisplayName("Pilt")]
        public string? Image { get; set; }

        public IList<Booking> Bookings { get; set; }

        public Room()
        {
            Bookings = new List<Booking>();
        }

    }
}
