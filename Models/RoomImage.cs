using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivago.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public int RoomId { get; set; }
        public int ImageId { get; set; }

        public Room Room { get; set; }
        public Image Image { get; set; }

    }
}
