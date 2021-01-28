using Snake.Hitboxes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Controls;
using System.Linq;

namespace Snake.SimulationObjects
{
    class SnakeObjekt : CollidableObject, DrawableObject
    {
        List<SnakeBodyPart> body;
        SnakeBodyPart head;
        Direction nextDirection;
        Direction currentDirection;
        SnakeCollider collider;

        public SnakeObjekt(Game game, Vector2 startLocation) : this(game, startLocation, 3)
        {

        }
        public SnakeObjekt(Game game,Vector2 startLocation,int defaultLength) : base(game)
        {
            this.body = new List<SnakeBodyPart>();
            this.head = new SnakeBodyPart(this.Game, startLocation);
            this.collider = new SnakeCollider(this.head.GetHitbox());
            for (int i = 0; i < defaultLength-1; i++)
            {
                this.AddBodyPart();
            }
        }

        internal Direction NextDirection 
        { 
            get => nextDirection;
            set
            {
                // preventing a 180° direction change
                if (Math.Abs(currentDirection-value)%3 < 2)
                {
                    nextDirection = value;
                }
                
            }
        }

        public void AddBodyPart()
        {
            
            SnakeBodyPart lastPart = GetLastPart();

            SnakeBodyPart bodyPart = new SnakeBodyPart(this.Game,lastPart.Location);
            this.body.Add(bodyPart);
            this.collider.Add(bodyPart.GetHitbox());
        }

        private SnakeBodyPart GetLastPart()
        {
            if (body.Count > 0)
            {
                return body.Last();
            }
            else
            {
                return head;
            }
        }

        private void MoveInDirection()
        {
            Vector2 newHeadLoc = head.Location;
            currentDirection = NextDirection;
            switch (currentDirection)
            {
                case Direction.DOWN: 
                    newHeadLoc.Y += head.Height;
                    break;
                case Direction.UP:
                    newHeadLoc.Y -= head.Height;
                    break;
                case Direction.LEFT:
                    newHeadLoc.X -= head.Width;
                    break;
                case Direction.RIGTH:
                    newHeadLoc.X += head.Width;
                    break;
                default:
                    break;
            }

            Vector2 lastLoc = head.Location;
            head.Location = newHeadLoc;
            foreach (var b in body)
            {
                Vector2 thisLoc = b.Location;
                b.Location = lastLoc;
                lastLoc = thisLoc;
            }
        }

        public void Animate(TimeSpan intervall)
        {
            MoveInDirection();
        }

        public void DrawTo(Canvas canvas)
        {
            head.DrawTo(canvas);
            foreach (var b in body)
            {
                b.DrawTo(canvas);
            }
        }

        public override Collider GetHitbox()
        {
            return collider;
        }
    }
}
