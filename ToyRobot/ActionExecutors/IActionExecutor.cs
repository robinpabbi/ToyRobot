using ToyRobot.TablePositionValidator;
using ToyRobot.TableTop;

namespace ToyRobot.ActionExecutors
{
    internal interface IActionExecutor
    {
        void Execute(ITableTop tableTop, ITablePositionValidator positionValidator, string actionParam = null);

        bool CanExecute(ITableTop tableTop);
    }
}
