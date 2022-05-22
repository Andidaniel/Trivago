using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivago.Models
{
    public class Image
    {
        public int Id { get; set; }
        public Byte[] Data { get; set; }

        public List<RoomImage> RoomImages { get; set; }
    }
}
