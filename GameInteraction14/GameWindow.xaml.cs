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
        private int Speed = 10;
        private Random Random = new Random();
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
            Controls();
        }

        private void Controls()
        {
            if (RightKeyPressed && Canvas.GetLeft(Player) < 820)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + Speed);
            }
            if (LeftKeyPressed && Canvas.GetLeft(Player) > 10)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - Speed);
            }




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

        private void AddClothes(string ClothesType = "Clothes")
        {
            int ClothesColor = Random.Next(1, 8);
            ImageBrush ClothesImage = new ImageBrush();
            //random bepalen welk shirt er wordt gemaakt
            switch (ClothesColor)
            {
                case 1:
                    ClothesImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/BlueShirt.png"));
                    break;
                case 2:
                    ClothesImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/BlackShirt.png"));
                    break;
                case 3:
                    ClothesImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/GreenShirt.png"));
                    break;
                case 4:
                    ClothesImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/YellowShirt.png"));
                    break;
                case 5:
                    ClothesImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/RedShirt.png"));
                    break;
                case 6:
                    ClothesImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/WhiteShirt.png"));
                    break;
                case 7:
                    ClothesImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/ElsaShirt.png"));
                    ClothesType = "ElsaShirt";
                    break;
            }
        }
    }
}

