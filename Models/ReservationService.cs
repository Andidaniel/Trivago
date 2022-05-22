using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivago.Models
{
    public class ReservationService
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int ExtraServiceId { get; set; }

        public Reservation Reservation { get; set; }
        public ExtraService ExtraService { get; set; }
    }
}
