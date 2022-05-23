using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Trivago.Data;
using Trivago.Models;


namespace Trivago.Business_Layer
{
    public static class AdminBLL
    {
        public static bool EditRoomService(HotelContext dbContext, int id, string newName, string newDescription)
        {
            try
            {
                dbContext.Services
                    .Where(service => service.Id == id)
                    .ToList()
                    .ForEach(s =>
                    {
                        s.Description = newDescription;
                        s.Name = newName;
                    });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        } 
    }
}
