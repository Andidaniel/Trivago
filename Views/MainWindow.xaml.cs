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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trivago.Data;
using Trivago.Models;
using Trivago.Views;

namespace Trivago
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HotelContext _hotelContext = new HotelContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdminLogin(object sender, RoutedEventArgs e)
        {
            AdminView adminView = new AdminView(_hotelContext);
            App.Current.MainWindow.Close();
            App.Current.MainWindow = adminView;
            App.Current.MainWindow.Show();
        }

        private void ViewReservations(object sender, RoutedEventArgs e)
        {
            NoAccountView noAccountView = new NoAccountView(_hotelContext);
            App.Current.MainWindow.Close();
            App.Current.MainWindow = noAccountView;
            App.Current.MainWindow.Show();
        }
    }
}
