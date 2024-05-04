using ToyRobot.Enums;
using ToyRobot.Robot;

namespace ToyRobot.TableTop
{
    public interface ITableTop
    {
        int Width { get; }
        int Height { get; }

        IRobot Robot { get; }

        void PlaceRobot(int x, int y, Direction direction);
    }
}
