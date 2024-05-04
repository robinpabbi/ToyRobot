using ToyRobot.Enums;
using ToyRobot.TablePositionValidator;
using ToyRobot.TableTop;

namespace ToyRobot.ActionExecutors.Executors
{
    [ActionExecutor(UserAction.PLACE)]
    internal class PlaceActionExecutor : IActionExecutor
    {
        public bool CanExecute(ITableTop tableTop)
        {
            // PLace action is first action and can be executed any time and any number of times
            return true;
        }

        public void Execute(ITableTop tableTop, ITablePositionValidator positionValidator, string actionParam = null)
        {
            // Action parameter has to be 3 values comma separated
            // 1. X
            // 2. Y
            // 3. Direction

            if(TryParsingPlaceAction(tableTop, positionValidator, actionParam, out var x, out var y, out var direction))
            {
                Console.WriteLine($"Placing Robot at {x}, {y}, {direction}");
                tableTop.PlaceRobot(x, y, direction);
                
            }
        }

        private bool TryParsingPlaceAction(ITableTop tableTop, ITablePositionValidator positionValidator, string actionParam, out int x, out int y, out Direction direction)
        {
            x = -1;
            y = -1;
            direction = Direction.NORTH;

            if(string.IsNullOrEmpty(actionParam))
            {
                return false;
            }

            string[] args = actionParam.Split(',');

            if (args.Length != 3 || !int.TryParse(args[0].Trim(), out x) || !int.TryParse(args[1].Trim(), out y))
            {
                Console.WriteLine("Invalid PLACE command parameters.");
                return false;
            }

            if (!Enum.TryParse(args[2].Trim().ToUpper(), out direction))
            {
                Console.WriteLine("Invalid Direction provided");
                return false;
            }
            
            if(!positionValidator.IsValid(tableTop, x, y))
            {
                Console.WriteLine("Invalid Location.");
                return false;
            }

            return true;
        }
    }
}
