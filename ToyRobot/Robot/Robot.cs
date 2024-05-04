using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;

namespace ToyRobot.Robot
{
    internal class Robot : IRobot
    {
        private int _x, _y;
        private Direction _direction;


        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Direction Facing { get => _direction; set => _direction = value; }

        public override string ToString()
        {
            return $"{X}, {Y}, {Facing}";
        }
    }
}
