using MessagePack;
using ServiceStack.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHouse.Data
{
    public class Gallery
    {
        [AutoIncrement]
        public int Id { get; set; }

        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Lae pilt üles (1000x667px)")]
        public IFormFile ImageFile { get; set; }

        [DisplayName("Tuba")]
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }
}
