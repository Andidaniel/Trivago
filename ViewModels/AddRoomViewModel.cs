using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Trivago.Business_Layer;
using Trivago.Data;
using Trivago.Models;
using Trivago.Utils;

namespace Trivago.ViewModels
{
    public class SelectableService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; } = false;

    }
    public class AddRoomViewModel:ViewModel
    {
        private readonly HotelContext dbContext;

        public ObservableCollection<RoomType> RoomTypes { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        public ObservableCollection<SelectableService> SelectableServices { get; set; }
        public List<Service> SelectedServices { get; set; }
        public string Floor { get; set; }
        public string Number { get; set; }

        public AddRoomViewModel()
        {
            dbContext = new HotelContext();
            RoomTypes = new ObservableCollection<RoomType>(dbContext.RoomTypes);
            Services = new ObservableCollection<Service>(dbContext.Services.Where(s => s.Deleted == false));
            SelectableServices = new ObservableCollection<SelectableService>();
            SelectedServices = new List<Service>();
            foreach (Service service in Services)
            {
                SelectableServices.Add(new SelectableService
                {
                    IsSelected = false,
                    Id = service.Id,
                    Name = service.Name,

                });
            }
        }

        #region Commands

        private ICommand _selectServicesCommand;
        public ICommand SelectServicesCommand
        {
            get
            {
                if (_selectServicesCommand == null)
                {
                    _selectServicesCommand = new RelayCommand(Select);
                }

                return _selectServicesCommand;
            }
        }

        private ICommand _createRoomCommand;

        public ICommand CreateRoomCommand
        {
            get
            {
                if (_createRoomCommand == null)
                {
                    _createRoomCommand= new RelayCommand(Create);
                }

                return _createRoomCommand;
            }
        }

        #endregion

        public void Select(object param)
        {
            foreach (var item in (param as ListBox).Items)
            {
                if ((item as SelectableService).IsSelected == true)
                {
                    SelectedServices.Add(new Service
                    {
                        Id = (item as SelectableService).Id,
                        Name = (item as SelectableService).Name,
                    });
                }
            }
        }

        public void Create(object param)
        {
            AdminBLL.CreateRoom(dbContext, SelectedServices, int.Parse(Floor), int.Parse(Number),
                ((param as ListBox).SelectedItem as RoomType).Id);
        }
    }
}
