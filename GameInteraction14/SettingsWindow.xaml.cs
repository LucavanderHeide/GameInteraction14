﻿using System;
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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Easy(object sender, RoutedEventArgs e)
        {
            bool EasyDifficulty = true;
            bool MediumDifficulty = false;
            bool HardDifficulty = false;
        }
        private void Medium(object sender, RoutedEventArgs e)
        {
            bool EasyDifficulty = false;
            bool MediumDifficulty = true;
            bool HardDifficulty = false;
        }
        private void Hard(object sender, RoutedEventArgs e)
        {
            bool EasyDifficulty = false;
            bool MediumDifficulty = false;
            bool HardDifficulty = true;
        }
    }
}
