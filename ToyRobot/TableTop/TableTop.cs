using ToyRobot.Enums;
using ToyRobot.Robot;

namespace ToyRobot.TableTop
{
    internal abstract class TableTop : ITableTop
    {
        private readonly int _width, _height;
        private IRobot _robot;

        public TableTop(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int Width => _width;

        public int Height => _height;

        public IRobot Robot => _robot;

        public void PlaceRobot(int x, int y, Direction direction)
        {
            if (_robot != null)
            {
                _robot.X = x;
                _robot.Y = y;
                _robot.Facing = direction;
            }
            else
            {
                // Can be enhanced to use factory
                _robot = new Robot.Robot()
                {
                    X = x,
                    Y = y,
                    Facing = direction
                };
            }
        }
    }
}
