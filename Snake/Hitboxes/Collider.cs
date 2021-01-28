using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Snake.Hitboxes
{
    interface Collider
    {
        public bool DoesCollide(Collider other);
        public bool IsInside(Vector2 point);
    }
}
