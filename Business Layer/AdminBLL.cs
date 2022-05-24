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
        public static bool AddRoomService(HotelContext dbContext, string newName, string newDescription)
        {
            try
            {
                dbContext.Services.Add(new Service
                {
                    Name = newName,
                    Description = newDescription,
                    Deleted = false
                });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
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
        public static bool DeleteRoomService(HotelContext dbContext, int id)
        {
            try
            {
                dbContext.Services
                    .Where(service => service.Id == id)
                    .ToList()
                    .ForEach(s => s.Deleted = true);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool AddExtraService(HotelContext dbContext, string newTitle, float newPrice)
        {
            try
            {
                dbContext.ExtraServices.Add(new ExtraService
                {
                    Title = newTitle,
                    Price = newPrice,
                    Deleted = false
                });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool EditExtraService(HotelContext dbContext, int id, string newTitle, float newPrice)
        {
            try
            {
                dbContext.ExtraServices
                    .Where(eservice => eservice.Id == id)
                    .ToList()
                    .ForEach(es =>
                    {
                        es.Title = newTitle;
                        es.Price = newPrice;
                    });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool DeleteExtraService(HotelContext dbContext, int id)
        {
            try
            {
                dbContext.ExtraServices
                    .Where(eservice => eservice.Id == id)
                    .ToList()
                    .ForEach(es => es.Deleted = true);
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
