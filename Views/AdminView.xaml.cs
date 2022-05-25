using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Trivago.Data;

namespace Trivago.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void ToManageExtraServices(object sender, RoutedEventArgs e)
        {
            ModifyServicesView newView = new ModifyServicesView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = newView;
            App.Current.MainWindow.Show();
        }

        private void ToManageServices(object sender, RoutedEventArgs e)
        {
            ModifyExtraServicesView newView = new ModifyExtraServicesView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = newView;
            App.Current.MainWindow.Show();
        }

        private void ToAddRoom(object sender, RoutedEventArgs e)
        {
            AddRoomView newView = new AddRoomView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = newView;
            App.Current.MainWindow.Show();
            
        }

        private void BackToMainMenu(object sender, RoutedEventArgs e)
        {
            MainWindow newView = new MainWindow();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = newView;
            App.Current.MainWindow.Show();

        }
    }
}
