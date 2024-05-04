using ToyRobot.Enums;

namespace ToyRobot.ActionExecutors
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ActionExecutorAttribute : Attribute
    {
        public UserAction UserAction { get; private set; }

        public ActionExecutorAttribute(UserAction userAction)
        {
            UserAction = userAction;
        }
    }
}
