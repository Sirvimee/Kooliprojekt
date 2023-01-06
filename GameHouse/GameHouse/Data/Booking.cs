using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ServiceStack.DataAnnotations;

namespace GameHouse.Data
{
    public class Booking
    {
        [AutoIncrement]
        public int Id { get; set; }

        [DisplayName("Tuba")]
        public Room Name { get; set; }
        public int NameId { get; set; }

        [DisplayName("Kuupäev")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Kellaaeg")]
        public string Time { get; set; }

        [DisplayName("Kliendi nimi")]
        public string ContactName { get; set; }

        [DisplayName("E-post")]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        public int Phone { get; set; }

    }
}
