using System.Reflection;
using ToyRobot.Enums;

namespace ToyRobot.ActionExecutors
{
    internal class ActionExecutorProvider : IActionExecutorProvider
    {
        #region Private Members

        private readonly IDictionary<UserAction, IActionExecutor> actionToActionExecutorDict = new Dictionary<UserAction, IActionExecutor>();

        #endregion Private Members

        #region Constructor

        public ActionExecutorProvider() {
            RegisterAllActionExecutors();
        }

        #endregion Constructor

        #region Methods

        public IActionExecutor GetActionExecutor(UserAction action)
        {
            return actionToActionExecutorDict[action];
        }

        private void RegisterAllActionExecutors()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            foreach (var actionExecutorType in types)
            {
                var attribute = actionExecutorType.GetCustomAttribute<ActionExecutorAttribute>();

                if(attribute != null)
                {
                    actionToActionExecutorDict.Add(attribute.UserAction, Activator.CreateInstance(actionExecutorType) as IActionExecutor);
                }
            }
        }

        #endregion Methods
    }
}

