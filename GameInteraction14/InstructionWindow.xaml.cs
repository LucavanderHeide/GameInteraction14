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
    /// Interaction logic for InstructionWindow.xaml
    /// </summary>
    public partial class InstructionWindow : Window
    {
        public InstructionWindow()
        {
            InitializeComponent();
        }

        // Om terug te navigeren naar de mainwindow (Het start scherm)
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Left = this.Left;
            mainWindow.Top = this.Top;
            mainWindow.Show();
            this.Close();
        }

        // Om naar de gamewindow te navigeren
        private void StartGame(object sender, RoutedEventArgs e)
        {
            GameWindow GameWindow = new GameWindow();
            GameWindow.Left = this.Left;
            GameWindow.Top = this.Top;
            GameWindow.Show();
            this.Close();
        }

    }
}
