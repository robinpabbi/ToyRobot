using ToyRobot.Enums;
using ToyRobot.TablePositionValidator;
using ToyRobot.TableTop;

namespace ToyRobot.ActionExecutors.Executors
{
    [ActionExecutor(UserAction.INVALID)]
    internal class InvalidActionExecutor : IActionExecutor
    {
        public bool CanExecute(ITableTop tableTop)
        {
            return true;
        }

        public void Execute(ITableTop tableTop, ITablePositionValidator positionValidator, string actionParam = null)
        {
            Console.WriteLine("Ignoring the action as it is Invalid action.");
        }
    }
}
