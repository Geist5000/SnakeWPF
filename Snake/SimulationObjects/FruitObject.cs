using Snake.Hitboxes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace Snake.SimulationObjects
{
    class FruitObject : SquareObject
    {
        public FruitObject(Game game, Vector2 location) : base(game, location, 20, 20, Brushes.Red)
        {
        }
    }
}
