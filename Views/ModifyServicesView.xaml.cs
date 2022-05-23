using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Trivago.Business_Layer;
using Trivago.Data;
using Trivago.Models;

namespace Trivago.Views
{
    /// <summary>
    /// Interaction logic for ModifyExtraServicesView.xaml
    /// </summary>
    public partial class ModifyServicesView : Window
    {
        public ModifyServicesView()
        {
            InitializeComponent();
        }

        private void ChangedItem(object sender, SelectionChangedEventArgs e)
        {
            NameTB.Text = ((sender as ListBox).SelectedItem as Service).Name;
            DescriptionTB.Text = ((sender as ListBox).SelectedItem as Service).Description;
            
        }


        private void ToSelection(object sender, RoutedEventArgs e)
        {

            AdminView adminView = new AdminView();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = adminView;
                App.Current.MainWindow.Show();
            
        }
    }
}
