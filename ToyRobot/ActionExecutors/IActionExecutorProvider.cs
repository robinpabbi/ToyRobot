using ToyRobot.Enums;

namespace ToyRobot.ActionExecutors
{
    internal interface IActionExecutorProvider
    {
        IActionExecutor GetActionExecutor(UserAction action);
    }
}
