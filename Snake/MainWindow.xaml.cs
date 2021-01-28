using Snake.SimulationObjects;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameLoop;
        Game game;
        public MainWindow()
        {
            
            InitializeComponent();
            InitializeGame();
        }

        void InitializeGame()
        {
            this.game = new Game(MainCanvas);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (!game.IsRunning)
            {
                game.Start();
            }
            else
            {
                switch (e.Key)
                {
                    case Key.W:
                    case Key.Up:
                        game.DirectionChange(Direction.UP);
                        break;
                    case Key.D:
                    case Key.Right:
                        game.DirectionChange(Direction.RIGTH);
                        break;
                    case Key.A:
                    case Key.Left:
                        game.DirectionChange(Direction.LEFT);
                        break;
                    case Key.S:
                    case Key.Down:
                        game.DirectionChange(Direction.DOWN);
                        break;
                }
            }
        }
    }
}
