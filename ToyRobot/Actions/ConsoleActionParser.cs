using ToyRobot.Enums;

namespace ToyRobot.Actions
{
    public interface IActionParser
    {
        UserAction ParseAction(string useAction, out string actionParameters);
    }

    internal class ConsoleActionParser : IActionParser
    {
        public UserAction ParseAction(string userAction, out string actionParameters)
        {
            actionParameters = null;

            if (string.IsNullOrEmpty(userAction))
            {
                return UserAction.INVALID;
            }

            var args = userAction.Split(' ');

            userAction = args[0];

            if (args.Length > 1)
            {
                actionParameters = args[1];
            }

            if (Enum.TryParse(userAction.Trim().ToUpper(), out UserAction action))
            {
                return action;
            }

            return UserAction.INVALID;
        }
    }
}
