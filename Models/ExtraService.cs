using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivago.Models
{
    /// <summary>
    /// Extra services that a reservation can have.
    /// e.g: Transportation, Meals
    /// </summary>
    public class ExtraService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }

        public List<ReservationService> ReservationServices { get; set; }
    }
}
