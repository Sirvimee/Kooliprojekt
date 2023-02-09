using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ServiceStack.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameHouse.Data
{
    public class Booking
    {
        private DateTime _relaseDate = DateTime.MinValue;


        [AutoIncrement]
        public int Id { get; set; }

        [DisplayName("Tuba")]
        public Room Room { get; set; }
        public int RoomId { get; set; }

        [DisplayName("Kuupäev")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date
        {
            get
            {
                return (_relaseDate == DateTime.MinValue) ? DateTime.Now : _relaseDate;
            }
            set
            {
                _relaseDate = value;
            }
        }

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
