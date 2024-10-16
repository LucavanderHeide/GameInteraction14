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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;

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
        private Rect PlayerHitBox;
        private int ClothesCounter = 100;
        private int Limit = 50;
        private int Score = 0;
        private List<Rectangle> RemoveClothes = new List<Rectangle>();
        
       

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
            PlayerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);
            ClothesCounter -= 1;
            CreateClothes();
            ScoreText.Content = "Score: " + Score;
            CheckScore(Score);

        }

        private void CreateClothes()
        {


            //controleren of er nog kledingstukken zijn en eventueel nieuwe aanmaken
            if (ClothesCounter < 0)
            {
                AddClothes();
                ClothesCounter = Limit;
            }

            //controleren of er kledingstukken zijn en deze naar beneden laten bewegen
            //controleren of er contact wordt gemaakt met de speler
            foreach (var x in GameScreen.Children.OfType<Rectangle>())
            {

                if (x is Rectangle && (string)x.Tag == "Clothes")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + 3);

                    if (Canvas.GetTop(x) > 405)
                    {
                        RemoveClothes.Add(x);
                        Score -= 10;
                    }

                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (PlayerHitBox.IntersectsWith(enemyHitBox))
                    {
                        Score += 10;
                        RemoveClothes.Add(x);
                    }

                }

                //controleren of een shirt een negatief effect heeft op de speler
                if (x is Rectangle && (string)x.Tag == "ElsaShirt")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + 3);

                    if (Canvas.GetTop(x) > 425)
                    {
                        RemoveClothes.Add(x);
                        Score += 10;
                    }

                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (PlayerHitBox.IntersectsWith(enemyHitBox))
                    {
                        Score -= 20;
                        RemoveClothes.Add(x);
                    }

                }

            }

            //verwijderen van kledingstukken
            foreach (Rectangle i in RemoveClothes)
            {
                GameScreen.Children.Remove(i);
            }


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

            //ractangle voor de kleding aanmaken
            Rectangle newClothes = new Rectangle
            {
                Tag = ClothesType,
                Width = 50,
                Height = 50,
                Fill = ClothesImage
            };

            //positie bepalen van de kledingstukken
            int ClothesPosition = Random.Next(25, 800);
            Canvas.SetTop(newClothes, 17);
            Canvas.SetLeft(newClothes, ClothesPosition);
            GameScreen.Children.Add(newClothes);
        }

        //als de score onder een bepaalde waarde komt, wordt het spel gestopt
        public void CheckScore(int score)
        {
            if(score <= -60)
            {
                MessageBox.Show("Je hebt verloren, je hebt teveel min-punten behaald");
                GameTimer.Stop();
                
                MainWindow MW = new MainWindow();
                MW.Left = this.Left;
                MW.Top = this.Top;

                MW.Show();
                this.Close();
            }
        }

        
    }
}

