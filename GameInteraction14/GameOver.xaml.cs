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
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        public GameOver()
        {
            InitializeComponent();
        }

        public void OnQuit(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();

            MW.Top = this.Top;
            MW.Left = this.Left;

            MW.Show();
            this.Close();
        }

        public void OnRestart(object sender, RoutedEventArgs e)
        {
            GameWindow GM = new GameWindow();
            GM.Top = this.Top;
            GM.Left = this.Left;
            GM.Show();
            this.Close();
        }
    }
}
