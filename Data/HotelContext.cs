using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivago.Models;


namespace Trivago.Data
{
    public class HotelContext:DbContext
    {
        public HotelContext():base("name=HotelDB")
        {
        }
        public DbSet<Room>Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomService> RoomServices { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<ExtraService> ExtraServices { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }

       

    }
}
