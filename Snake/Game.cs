using Snake.SimulationObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Linq;
using System.Numerics;
using System.Windows;
using Snake.Hitboxes;

namespace Snake
{
    class Game:DrawableObject
    {
        List<GameObject> objects;
        SnakeObjekt snake;
        FruitObject fruit;
        DispatcherTimer timer;
        Canvas renderSurface;
        Random r;
        private int score;

        public bool IsRunning { get { return timer.IsEnabled; } }

        public Game(Canvas renderSurface):this(renderSurface,new Random())
        {

        }
        public Game(Canvas renderSurface,Random r)
        {
            this.r = r;
            this.renderSurface = renderSurface;
            timer = new DispatcherTimer(DispatcherPriority.Normal);
            timer.Interval = new TimeSpan(0, 0, 0, 0,80);
            timer.Tick += new EventHandler(OnGameLoop);
            this.objects = new List<GameObject>();
        }

        private void OnGameLoop(Object sender, EventArgs args)
        {
            Animate(timer.Interval);
            CheckCollisionsAndReact();
            renderSurface.Children.Clear();
            DrawTo(this.renderSurface);
        }

        private void CheckCollisionsAndReact()
        {
            if (this.snake.GetHitbox().DoesCollide(this.fruit.GetHitbox()))
            {
                FruitDidGetHit();
            }

            if (this.snake.GetHitbox().DoesCollide(this.snake.GetHitbox()))
            {
                GameOver();
            }

            if(this.snake.GetHitbox().DoesCollide(GetBorderCollider())){
                GameOver();
            }
        }

        private Collider GetBorderCollider()
        {
            GroupCollider c = new GroupCollider();
            c.Add(new SquareCollider(new Vector2(-10, 0), 10, (float)renderSurface.ActualHeight));
            c.Add(new SquareCollider(new Vector2((float)renderSurface.ActualWidth, 0), 10, (float)renderSurface.ActualHeight));
            c.Add(new SquareCollider(new Vector2(0, -10),(float)renderSurface.ActualWidth,10));
            c.Add(new SquareCollider(new Vector2(0, (float)renderSurface.ActualHeight), (float)renderSurface.ActualWidth,10));
            return c;

        }

        private void GameOver()
        {
            MessageBox.Show("Died\n\nScore: " + score);
            this.Stop();
        }

        public void Animate(TimeSpan intervall)
        {
            this.snake.Animate(intervall);
            this.fruit.Animate(intervall);
        }

        internal void Start()
        {
            InitializeGame();
            timer.Start();
        }

        internal void Stop()
        {
            timer.Stop();
        }

        public void DrawTo(Canvas canvas)
        {
            this.snake.DrawTo(canvas);
            this.fruit.DrawTo(canvas);
        }

        public void DirectionChange(Direction d)
        {
            this.snake.NextDirection = d;
        }

        public void InitializeGame()
        {
            this.snake = new SnakeObjekt(this,new Vector2(r.Next(Convert.ToInt32(renderSurface.ActualWidth/20-1)) * 20, r.Next(Convert.ToInt32(renderSurface.ActualHeight / 20 - 1)) * 20));
            score = 0;
            PlaceNewFruit();
        }

        private void FruitDidGetHit()
        {
            score++;
            this.snake.AddBodyPart();
            this.PlaceNewFruit();
        }

        private void PlaceNewFruit()
        {
            do
            {
                fruit = new FruitObject(this, new Vector2(0, 0));
                float x = r.Next(Convert.ToInt32(renderSurface.ActualWidth/fruit.Width)-1) *fruit.Width;
                float y = r.Next(Convert.ToInt32(renderSurface.ActualHeight/ fruit.Height) - 1) * fruit.Width;

                fruit.Location = new Vector2(x, y);
            } while (this.snake.GetHitbox().DoesCollide(fruit.GetHitbox()));
            

        }
    }
}
