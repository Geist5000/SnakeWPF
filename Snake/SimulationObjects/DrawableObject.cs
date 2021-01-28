using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Controls;

namespace Snake.SimulationObjects
{
    interface DrawableObject
    {
        public void Animate(TimeSpan interval);
        public void DrawTo(Canvas canvas);
    }
}
