using ToyRobot.Enums;
using ToyRobot.TablePositionValidator;
using ToyRobot.TableTop;

namespace ToyRobot.ActionExecutors.Executors
{
    [ActionExecutor(UserAction.LEFT)]
    internal class LeftActionExecutor : IActionExecutor
    {
        public bool CanExecute(ITableTop tableTop)
        {
            // can be executed only if Robot is placed on table
            return tableTop.Robot != null;
        }

        /// <summary>
        ///         W
        ///  |---------------|
        ///  |               |
        /// S|               | N
        ///  |---------------|
        ///         E
        /// </summary>
        /// <param name="tableTop"></param>
        /// <param name="positionValidator"></param>
        /// <param name="actionParam"></param>
        public void Execute(ITableTop tableTop, ITablePositionValidator positionValidator, string actionParam = null)
        {

            var currentFacing = tableTop.Robot.Facing;
            var targetFacing = (Direction)(((int)currentFacing - 1 + 4) % 4);

            Console.WriteLine($"Moved Left from {currentFacing} to {targetFacing}.");
            tableTop.Robot.Facing = targetFacing;
        }
    }
}
