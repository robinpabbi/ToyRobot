using ToyRobot.ActionExecutors;
using ToyRobot.TablePositionValidator;
using ToyRobot.TableTop;

namespace ToyRobot.Actions
{
    internal class ConsoleActionController: IActionController
    {
        private ITableTop _tableTop;
        private readonly ITablePositionValidator _tablePositionValidator;
        private readonly IActionExecutorProvider _actionExecutorProvider;
        private readonly IActionParser _actionParser;

        #region Constructor

        public ConsoleActionController(ITablePositionValidator positionValidator, IActionParser actionParser, IActionExecutorProvider actionExecutorProvider) {
            _tablePositionValidator = positionValidator;
            _actionExecutorProvider = actionExecutorProvider;
            _actionParser = actionParser;
        }

        #endregion Constructor

        #region Methods

        public void Initialize(ITableTop tableTop)
        {
            _tableTop = tableTop;
        }

        public void Start() {

            while(true)
            {
                Console.WriteLine();
                Console.Write("Enter you action:");

                var action = Console.ReadLine();

                var userAction = _actionParser.ParseAction(action, out var actionParams);

                if(userAction == Enums.UserAction.EXIT)
                {
                    break;
                }

                var executor = _actionExecutorProvider.GetActionExecutor(userAction);

                if(executor != null && executor.CanExecute(_tableTop)) {
                    executor.Execute(_tableTop, _tablePositionValidator, actionParams);
                }
            }
            
        }


        #endregion Methods
    }
}
