﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameInteraction14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {

            GameWindow GW = new GameWindow();

            GW.Left = this.Left;
            GW.Top = this.Top;

            GW.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        // Om naar de instructie pagina te navigeren
        private void BtnInstructiePagina(object sender, RoutedEventArgs e)
        {
            InstructionWindow instructionWindow = new InstructionWindow();
            instructionWindow.Show(); // Open het instructievenster
            this.Close(); // Sluit het huidige venster
        }

        // Om naar de settings window te navigeren
        private void Settings(object sender, RoutedEventArgs e)
        {
            // Maak ik het aan
            SettingsWindow settingsWindo = new SettingsWindow();
            settingsWindo.Show(); // Zodra op de knop wordt geklikt, wordt de settings window getoond
            this.Close();
        }
    }
}