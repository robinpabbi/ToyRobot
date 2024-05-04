using ToyRobot.Enums;
using ToyRobot.TablePositionValidator;
using ToyRobot.TableTop;

namespace ToyRobot.ActionExecutors.Executors
{
    [ActionExecutor(UserAction.REPORT)]
    internal class ReportActionExecutor : IActionExecutor
    {
        public bool CanExecute(ITableTop tableTop)
        {
            return tableTop.Robot != null;
        }

        public void Execute(ITableTop tableTop, ITablePositionValidator positionValidator, string actionParam = null)
        {
            Console.WriteLine($"Output: {tableTop.Robot}");
        }
    }
}
