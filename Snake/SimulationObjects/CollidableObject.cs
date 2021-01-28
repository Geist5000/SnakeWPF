using Snake.Hitboxes;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Controls;

namespace Snake.SimulationObjects
{
    abstract class CollidableObject:GameObject
    {
        protected CollidableObject(Game game) : base(game)
        {}
        public abstract Collider GetHitbox();
    }
}
