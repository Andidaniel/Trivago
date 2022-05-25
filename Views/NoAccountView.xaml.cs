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
using Trivago.Data;

namespace Trivago.Views
{
    /// <summary>
    /// Interaction logic for NoAccountView.xaml
    /// </summary>
    public partial class NoAccountView : Window
    {
      
        public NoAccountView()
        {
          
            InitializeComponent();
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
