using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivago.Data;
using Trivago.Models;

namespace Trivago.ViewModels
{
    public class UIRoom
    {
        public int Id { get; set; }
        public string FloorNumber { get; set; }
        public string RoomNumber { get; set; }
        public List<Service> Services { get; set; }
        public string TypeName { get; set; }
        public override string ToString()
        {
            StringBuilder toReturn = new StringBuilder();
            toReturn.Append($"Type: {TypeName}\nFloor: {FloorNumber}\nNumber: { RoomNumber}\nServices:\n");
            foreach (Service service in Services)
            {
                toReturn.Append("-");
                toReturn.Append(service.Name);
                toReturn.Append("\n");
            }

            return toReturn.ToString();
        }
    }
    public class NoAccountViewModel
    {
        private readonly HotelContext dbContext;
        public List<Room> Rooms { get; set; }
        public List<Service> Services { get; set; }
        public ObservableCollection<UIRoom> UIRooms { get; set; }
        public List<RoomService> RoomServices { get; set; }
        public List<RoomType> RoomTypes { get; set; }
        public NoAccountViewModel()
        {
            dbContext = new HotelContext();
            Services = new List<Service>(dbContext.Services.Where(s => s.Deleted == false));
            Rooms = new List<Room>(dbContext.Rooms.Where(r => r.Active == true));
            RoomServices = new List<RoomService>(dbContext.RoomServices.Where(rs => rs.Deleted == false));
            UIRooms = new ObservableCollection<UIRoom>();
            RoomTypes = new List<RoomType>(dbContext.RoomTypes);
            foreach (Room room in Rooms)
            {
                string typeName="";
                foreach (var roomType in RoomTypes)
                {
                    if (room.RoomTypeId == roomType.Id)
                    {
                        typeName = roomType.Name;
                        break;
                    }
                }
                UIRooms.Add(new UIRoom
                {
                    Id = room.Id,
                    FloorNumber = room.Floor.ToString(),
                    RoomNumber = room.Number.ToString(),
                    TypeName = typeName
                });
            }

           
            
            foreach (UIRoom uiRoom in UIRooms)
            {
                uiRoom.Services = new List<Service>();
                List<int> Ids = new List<int>();

                foreach (var roomService in RoomServices)
                {
                    if (roomService.RoomId == uiRoom.Id)
                    {
                        Ids.Add(roomService.ServiceId);
                    }
                }

                foreach (var service in Services)
                {
                    foreach (var id in Ids)
                    {
                        if (service.Id == id)
                        {
                            uiRoom.Services.Add(service);
                            break;
                        }
                    }
                }
            }
         
        }
    }
}
