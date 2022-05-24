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
    public class ChangeRoomExtraServiceViewModel:ViewModel
    {
        public ObservableCollection<ExtraService> ExtraServices { get; set; }
        public HotelContext dbContext { get; set; }

        public string NewTitle { get; set; }
        public string NewPrice { get; set; }
        public ChangeRoomExtraServiceViewModel()
        {
            dbContext = new HotelContext();
            ExtraServices = new ObservableCollection<ExtraService>(dbContext.ExtraServices.Where(es => es.Deleted == false));
        }
        #region Commands

        private ICommand _updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(UpdateExtraService);
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
                    _deleteCommand = new RelayCommand(DeleteExtraService);
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
                    _addCommand = new RelayCommand(AddExtraService);
                }

                return _addCommand;
            }
        }


        #endregion
        private void AddExtraService(object param)
        {
            float fPrice;
            if (float.TryParse(NewPrice, out fPrice) == false)
            {
                MessageBox.Show("Make sure the price is a number", "Price error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                if (!string.IsNullOrEmpty(NewTitle))
                {
                    AdminBLL.AddExtraService(dbContext, NewTitle, fPrice);
                    ExtraServices =
                        new ObservableCollection<ExtraService>(
                            dbContext.ExtraServices.Where(es => es.Deleted == false));
                    OnPropertyChanged("ExtraServices");
                    (param as ListBox).SelectedIndex = 0;
                }
            }
        }

        private void UpdateExtraService(object param)
        {
            float fPrice;
            if (float.TryParse(NewPrice, out fPrice) == false)
            {
                MessageBox.Show("Make sure the price is a number", "Price error!", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            else
            {
                if ((param as ListBox).SelectedItem != null)
                {

                    AdminBLL.EditExtraService(dbContext,((param as ListBox).SelectedItem as ExtraService).Id,NewTitle,fPrice);
                    ExtraServices = new ObservableCollection<ExtraService>(dbContext.ExtraServices.Where(s => s.Deleted == false));
                    OnPropertyChanged("ExtraServices");
                    (param as ListBox).SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Select a service from the list first!", "No service selected!", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                }
            }
           
        }
        private void DeleteExtraService(object param)
        {
            if ((param as ListBox).SelectedItem != null)
            {
                AdminBLL.DeleteExtraService(dbContext, ((param as ListBox).SelectedItem as ExtraService).Id);
                ExtraServices = new ObservableCollection<ExtraService>(dbContext.ExtraServices.Where(es => es.Deleted == false));
                OnPropertyChanged("ExtraServices");
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
