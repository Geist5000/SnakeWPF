using Snake.Hitboxes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Snake.SimulationObjects
{
    class SnakeBodyPart : SquareObject
    {
        public SnakeBodyPart(Game game, Vector2 location) : this(game, location, 20, 20)
        {

        }
        public SnakeBodyPart(Game game, Vector2 location, float height, float width) : base(game,location, height, width, Brushes.Black)
        {
        }
    }
}
