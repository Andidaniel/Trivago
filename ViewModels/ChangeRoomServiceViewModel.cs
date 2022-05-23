using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trivago.Business_Layer;
using Trivago.Data;
using Trivago.Models;
using Trivago.Utils;

namespace Trivago.ViewModels
{
    public class ChangeRoomServiceViewModel:ViewModel
    {
        public ObservableCollection<Service> Services { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }

        public HotelContext dbContext { get; set; }
        public ChangeRoomServiceViewModel()
        {
            dbContext = new HotelContext();
            Services = new ObservableCollection<Service>(dbContext.Services);
        }

        #region Commands

        private ICommand updateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(UpdateService);
                }

                return updateCommand;
            }
        }

        #endregion

        public void UpdateService(object param)
        {
            AdminBLL.EditRoomService(dbContext, (param as Service).Id, NewName, NewDescription);
            /*foreach (var service in Services)
            {
                if (service.Id == (param as Service).Id)
                {
                    service.Description = NewDescription;
                    service.Name = NewName;
                    break;
                }
            }*/
            Services = new ObservableCollection<Service>(dbContext.Services);
            OnPropertyChanged("Services");
        }
    }
}
