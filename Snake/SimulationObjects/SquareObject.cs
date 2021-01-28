using Snake.Hitboxes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake.SimulationObjects
{
    class SquareObject : CollidableObject , DrawableObject
    {
        protected Brush color = Brushes.Black;
        float width;
        float height;
        Vector2 location;
        SquareCollider collider;
        float spacer;

        public SquareObject(Game game, Vector2 location, float height, float width, Brush color) : this(game,location,height,width,color,5)
        {

        }
        public SquareObject(Game game, Vector2 location, float height, float width, Brush color,float spacer):base(game)
        {
            Location = location;
            Height = height;
            Width = width;
            this.color = color;
            collider = new SquareCollider(Location, Width, Height);
            this.spacer = spacer;
        }

        public Vector2 Location
        {
            get { return location; }
            set { 
                location = value;
                if(collider != null)
                {
                    collider.Location = Location;
                }
            }
        }
        public float Height 
        { 
            get => height;
            set { 
                height = value; 
                if(collider != null)
                {
                    collider.Height = Height;
                }
            }
        }
        public float Width 
        { 
            get => width;
            set { 
                width = value;
                if (collider != null)
                {
                    collider.Width = Width;
                }
            }
        }

        public void Animate(TimeSpan intervall)
        {
            // no movement does occure
        }

        public void DrawTo(Canvas canvas)
        {
            Rectangle r = new Rectangle();
            r.Fill = color;
            r.Width = Width;
            r.Height = Height;
            Canvas.SetLeft(r,Location.X);
            Canvas.SetTop(r, Location.Y);
            canvas.Children.Add(r);
        }

        public override Collider GetHitbox()
        {
            return collider;
        }
    }
}
