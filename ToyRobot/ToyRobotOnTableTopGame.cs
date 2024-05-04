using ToyRobot.Actions;
using ToyRobot.Factories;

namespace ToyRobot
{
    internal class ToyRobotOnTableTopGame
    {
        #region Private Members

        private readonly IActionController _actionController;
        private readonly ITableTopFactory _tableTopFactory;

        #endregion Private Members

        #region Constructor

        public ToyRobotOnTableTopGame(ITableTopFactory tableTopFactory, IActionController actionController)
        {
            _actionController = actionController;
            _tableTopFactory = tableTopFactory;
        }

        #endregion Constructor

        #region Methods

        public void Start()
        {
            var tableTop = _tableTopFactory.GetTableTop();

            _actionController.Initialize(tableTop);

            _actionController.Start();
        }

        #endregion Methods
    }
}
