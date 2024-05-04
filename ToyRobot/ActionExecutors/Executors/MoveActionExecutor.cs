using ToyRobot.Enums;
using ToyRobot.TablePositionValidator;
using ToyRobot.TableTop;

namespace ToyRobot.ActionExecutors.Executors
{
    [ActionExecutor(UserAction.MOVE)]
    internal class MoveActionExecutor : IActionExecutor
    {
        public bool CanExecute(ITableTop tableTop)
        {
            // can be executed only if Robot is placed on table
            return tableTop.Robot != null;
        }

        /// <summary>
        ///     ----------> X axis
        ///     |
        ///     |
        ///     V 
        ///     Y Axis
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
            int targetX = tableTop.Robot.X;
            int targetY = tableTop.Robot.Y;

            switch (tableTop.Robot.Facing)
            {
                case Direction.NORTH:
                    targetX++;
                    break;
                case Direction.EAST:
                    targetY++;
                    break;
                case Direction.SOUTH:
                    targetX--;
                    break;
                case Direction.WEST:
                    targetY--;
                    break;
            }

            if(positionValidator.IsValid(tableTop, targetX, targetY))
            {
                Console.WriteLine($"Moving Robot to {targetX}, {targetY}");
                tableTop.Robot.X = targetX;
                tableTop.Robot.Y = targetY;
            } else
            {
                Console.WriteLine($"Can not move to target location, as Robot will fall from table. Hence ignoring the move");
            }
        }
    }
}
