using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Snake.Hitboxes
{
    class SquareCollider : Collider
    {
        public static int RESOLUTION = 30;
        float width;
        float height;
        Vector2 location;

        public SquareCollider(Vector2 location, float width, float height)
        {
            this.Location = location;
            this.Width = width;
            this.Height = height;
        }

        public float Width { get => width; set => width = value; }
        public float Height { get => height; set => height = value; }
        public Vector2 Location { get => location; set => location = value; }

        public bool DoesCollide(Collider other)
        {
            if (other == this) return false;

            
            float xDiff = Width / RESOLUTION;
            float yDiff = Height / RESOLUTION;
            for (float x = 0; x < Width; x += xDiff)
            {
                for (float y = 0; y < Height; y += yDiff)
                {
                    Vector2 toCheck = Location; // Vector2 is a Struct, so it will copied here
                    toCheck.X += x;
                    toCheck.Y += y;
                    if (other.IsInside(toCheck))
                    {
                        return true;
                    }
                }
            }

            return false; 
        }

        public bool IsInside(Vector2 location)
        {

            // (100,100) w: 100 b: 100 

            // testvector: (50,50)
            // (100,100)-(50,50) = (50,50)
            var diff = location - this.Location;
            return diff.X > 0 && diff.X < Width && diff.Y > 0 && diff.Y < Height;
        }
    }
}
