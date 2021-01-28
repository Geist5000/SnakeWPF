using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SimulationObjects
{
    class GameObject
    {
        Game game;

        protected Game Game { get => game; set => game = value; }

        public GameObject(Game game)
        {
            Game = game;
        }
    }
}
