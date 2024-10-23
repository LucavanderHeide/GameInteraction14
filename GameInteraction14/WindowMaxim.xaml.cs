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

namespace GameInteraction14
{
    /// <summary>
    /// Interaction logic for WindowMaxim.xaml
    /// </summary>
    public partial class WindowMaxim : Window
    {
        public WindowMaxim()
        {
            InitializeComponent();
        }

        private void BackSettings(object sender, RoutedEventArgs e)
        {
            MainWindow Back = new MainWindow();
            Back.Left = this.Left;
            Back.Top = this.Top;
            Back.Show();
            this.Close();
        }

        //Om terug te gaan naar Main window
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Left = this.Left;
            mainWindow.Top = this.Top;
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
