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
    public class ChangeRoomServiceViewModel:ViewModel
    {
        public ObservableCollection<Service> Services { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }

        public HotelContext dbContext { get; set; }
        public ChangeRoomServiceViewModel()
        {
            dbContext = new HotelContext();
            Services = new ObservableCollection<Service>(dbContext.Services.Where(s=>s.Deleted==false));
        }

        #region Commands

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(UpdateService);
                }

                return _updateCommand;
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand= new RelayCommand(DeleteService);
                }

                return _deleteCommand;
            }
        }

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(AddService);
                }

                return _addCommand;
            }
        }

        #endregion
        public void AddService(object param)
        {
            if (NewName != null && NewDescription != null)
            {
                AdminBLL.AddRoomService(dbContext, NewName, NewDescription);
                Services = new ObservableCollection<Service>(dbContext.Services.Where(s => s.Deleted == false));
                OnPropertyChanged("Services");
                (param as ListBox).SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Please fill in all the required fields", "Complete everything!", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }
        public void DeleteService(object param)
        {
            if ((param as ListBox).SelectedItem != null)
            {
                AdminBLL.DeleteRoomService(dbContext, ((param as ListBox).SelectedItem as Service).Id);
                Services = new ObservableCollection<Service>(dbContext.Services.Where(s=>s.Deleted==false));
                OnPropertyChanged("Services");
                (param as ListBox).SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Select a service from the list first!", "No service selected!", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }

        }
        public void UpdateService(object param)
        {
            if((param as ListBox).SelectedItem !=null)
            {
                /*foreach (var service in Services)
                {
                    if (service.Id == (param as Service).Id)
                    {
                        service.Description = NewDescription;
                        service.Name = NewName;
                        break;
                    }
                }*/
                AdminBLL.EditRoomService(dbContext, ((param as ListBox).SelectedItem as Service).Id, NewName, NewDescription);
                Services = new ObservableCollection<Service>(dbContext.Services.Where(s => s.Deleted == false));
                OnPropertyChanged("Services");
                (param as ListBox).SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Select a service from the list first!", "No service selected!", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            }
        }
    }
}
