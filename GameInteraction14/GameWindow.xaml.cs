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
using System.Windows.Threading;

namespace GameInteraction14
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private bool RightKeyPressed, LeftKeyPressed;
        private DispatcherTimer GameTimer = new DispatcherTimer();
        public GameWindow()
        {
            InitializeComponent();
            GameScreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(20);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
        }

        public void GameTick(object sender, EventArgs e)
        {
            
        }

        public void KeyboardUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                RightKeyPressed = false;
            }
            if (e.Key == Key.A)
            {
                LeftKeyPressed = false;
            }
        }

        public void KeyboardDown(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.D)
            {
                RightKeyPressed = true;
            }
            if (e.Key == Key.A)
            {
                LeftKeyPressed = true;
            }
        }
    }
}
