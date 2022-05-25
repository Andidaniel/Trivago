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

namespace Trivago.Views
{
    /// <summary>
    /// Interaction logic for AddRoomView.xaml
    /// </summary>
    public partial class AddRoomView : Window
    {
        public AddRoomView()
        {
            InitializeComponent();
        }

        private void BlockServiceList(object sender, RoutedEventArgs e)
        {
            ServiceList.Visibility = System.Windows.Visibility.Hidden;
            ServicesLabel.Visibility = System.Windows.Visibility.Hidden;
            (sender as Button).Visibility = System.Windows.Visibility.Hidden;
        }

        private void BackToAdminView(object sender, RoutedEventArgs e)
        {
            AdminView adminView = new AdminView();
            App.Current.MainWindow.Close();
            App.Current.MainWindow = adminView;
            App.Current.MainWindow.Show();
        }
    }
}
