using ToyRobot.TableTop;

namespace ToyRobot.Actions
{
    public interface IActionController
    {
        void Initialize(ITableTop tableTop);

        void Start();
    }
}
