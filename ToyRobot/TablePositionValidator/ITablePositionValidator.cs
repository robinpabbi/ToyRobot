using ToyRobot.TableTop;

namespace ToyRobot.TablePositionValidator
{
    public interface ITablePositionValidator
    {
        bool IsValid(ITableTop tableTop, int x, int y);
    }
}
