using System;

namespace Pizzabox.Domain.IO
{
    public static class InputReader
    {
        public static string GetInput()
        {
            return Console.ReadLine();
        }
        
        public static int ValidateInput(string input, int[] range)
        {
            int output = ConvertToInt(input);
            while (IntInRange(output, range) == false)
            {
                Messenger.InvalidInputMessage();
                input = Console.ReadLine();
                output = ConvertToInt(input);
            }
            return output;
        }

        private static int ConvertToInt(string input)
        {
            int convertedInput;
            if (int.TryParse(input, out convertedInput))
            {
                return convertedInput;
            }
            else
            {
                return -1;
            }
        }

        private static bool IntInRange(int number, int[] range)
        {
            if(number < range[0] || number > range[1])
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}