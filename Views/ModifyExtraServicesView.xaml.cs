using System;
using System.Collections.Generic;
using System.Linq;
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
using Trivago.Models;

namespace Trivago.Views
{
    /// <summary>
    /// Interaction logic for ModifyExtraServicesView.xaml
    /// </summary>
    public partial class ModifyExtraServicesView : Window
    {
        public ModifyExtraServicesView()
        {
            InitializeComponent();
        }
        private void ChangedItem(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                if ((sender as ListBox).SelectedItem != null)
                {
                    TitleTB.Text = ((sender as ListBox).SelectedItem as ExtraService).Title;
                    PriceTB.Text = ((sender as ListBox).SelectedItem as ExtraService).Price.ToString();
                }
            }
        }
        private void BackToAdmin(object sender, RoutedEventArgs e)
        {
            AdminView adminView = new AdminView();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = adminView;
                App.Current.MainWindow.Show();
        }
    }
}
