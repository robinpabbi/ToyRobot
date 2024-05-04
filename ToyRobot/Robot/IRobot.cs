﻿using ToyRobot.Enums;

namespace ToyRobot.Robot
{
    public interface IRobot
    {
        int X { get; set; }

        int Y { get; set; }

        Direction Facing { get; set; }
    }
}
