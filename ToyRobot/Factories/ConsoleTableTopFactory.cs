using System.Drawing;
using ToyRobot.TableTop;

namespace ToyRobot.Factories
{
    internal class ConsoleTableTopFactory : ITableTopFactory
    {
        public ITableTop GetTableTop()
        {
            PrintWelcomeMessage();
            Console.WriteLine("Table Top type: \n\tFor Square enter 1 (anything except '2' will be considered as square top).\n\tFor Rectangular enter 2.");
            Console.Write("Enter you table top choice:");

            var tableTopChoice = Console.ReadLine();

            return MapTableTopChoiceToTableTop(tableTopChoice);

        }

        private ITableTop MapTableTopChoiceToTableTop(string tableTopChoice)
        {
            switch (tableTopChoice)
            {
                case "2":
                    Console.Write("Enter width of Rectangular table top:");
                    var strWidth = Console.ReadLine();

                    Console.Write("Enter height of Rectangular table top:");
                    var strHeight = Console.ReadLine();

                    if(ValidateTableTopSizeInput(strWidth, out var width) &&
                        ValidateTableTopSizeInput(strHeight, out var height))
                    {
                        if (width == height)
                        {
                            return new SquareTableTop(width);
                        } else
                        {
                            return new RectangularTableTop(width, height);
                        }
                    }
                    break;
                default:
                    Console.Write("Enter side size of Square table top:");
                    var strSize = Console.ReadLine();

                    if(ValidateTableTopSizeInput(strSize, out var size))
                    {
                        return new SquareTableTop(size);
                    }
                    break;
            }

            Console.WriteLine("Invalid entries found, falling back to Square tabletop of 5x5.");
            return new SquareTableTop(5);
        }

        private void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Table Top Toy Robot Game.");
            Console.WriteLine();
        }

        private bool ValidateTableTopSizeInput(string strSize, out int size)
        {
            size = 0;
            if(int.TryParse(strSize.Trim(), out size))
            {
                if(size <= 0)
                {
                    Console.WriteLine("Side length can only be non zero positive value.");
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
