using ServiceStack.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using ForeignKeyAttribute = System.ComponentModel.DataAnnotations.Schema.ForeignKeyAttribute;

namespace GameHouse.Data
{
    public class Room
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Required]
        [StringLength(10,MinimumLength =2)]
        [DisplayName("Toa nimi")]
        public string Name { get; set; }

        [DisplayName("Kirjeldus")]
        public string Description { get; set; }

        [StringLength(10, MinimumLength = 2)]
        [DisplayName("Hind")]
        public string Price { get; set; }

        [DisplayName("Pilt")]
        public string? Image { get; set; }

        [NotMapped]
        [DisplayName("Lae pilt ülesse")]
        public IFormFile ImageFile { get; set; }

        public IList<Booking> Bookings { get; set; }

        [ForeignKey("RoomId")]
        public ICollection<Gallery> Galleries { get; set; }

        //public Room()
        //{
        //    Bookings = new List<Booking>();
        //    Galleries = new List<Gallery>();
        //}

    }
}
