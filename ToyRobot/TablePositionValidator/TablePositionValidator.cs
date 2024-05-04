using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.TableTop;

namespace ToyRobot.TablePositionValidator
{
    internal class TablePositionValidator : ITablePositionValidator
    {
        public bool IsValid(ITableTop tableTop, int x, int y)
        {
            return x >= 0 && x < tableTop.Width && 
                y >= 0 && y < tableTop.Height;
        }
    }
}
