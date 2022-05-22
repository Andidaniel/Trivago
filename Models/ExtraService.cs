using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivago.Models
{
    public class ExtraService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }

        public List<ReservationService> ReservationServices { get; set; }
    }
}
