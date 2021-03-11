/*
Print the numbers 1 to 1000 to the console. 
Print them in groups of 10 per line with a space separating each number.  
When the number is multiple of three, print “sweet” instead of the number on the console.  
If the number is a multiple of five, print “salty” (instead of the number) to the console.  
For numbers which are multiples of three and five, print “sweet’nSalty” to the console (instead of the number).  
After the numbers have all been printed, print out how many sweet’s, how many salty’s, and how many sweet’nSalty’s. These are three separate groups, so sweet’nSalty does not increment sweet or salty (and vice versa). 
Include verbose commentary in the source code to tell me what each few lines are doing. 
*/


using System;

namespace SweetNSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            // hard coded variables for meeting code requirements. Defined then passed into the constructor of an object cointaining the sweet'nSalty game.
            var start = 1;
            var end = 1000;
            var checkedNumbers = new[] {3, 5};
            var buzzwords = new[] {"sweet", "salty", "sweet'nSalty"};
            
            Looper sweetNSalty_1 = new Looper(start, end, checkedNumbers, buzzwords);
            sweetNSalty_1.Run();
        }
    }


    // Not that it's needed in this case, I'm just not very familiar with interfaces yet and wanted practice using them.
    // In this case, interface is in charge of making sure Looper class is using all of the methods it needs to run properly.
    public interface ByAnotherNameRequires
    {
        void Run();
        void Intro();
        void ValidateRange();
        void CountToNumber(int first, int last);
        void EvaluatePrint(int number, int[] arr);
        void PrintAltString(string newWord);
        void UpdateScore(int option);
        void PrintResults();
    }

    // Object storing an instance of the sweet'nSalty game
    public class Looper : ByAnotherNameRequires
    {
        // constructor to ensure values are provided where they are needed.
        public Looper(int startNumberIn, int endNumberIn, int[] divisorArr, string[] altWordsIn)
        {
            startNumber = startNumberIn;
            endNumber = endNumberIn;
            divisors = divisorArr;
            altWords = altWordsIn;
            scoreBoard = new int[altWords.Length]; // create scoreBoard array of the same length as the altWords array
            ValidateRange(); // correct range if values are flipped
        }

        // defining properties the class will need in order to control state
        // parallel arrays are used to relate arrays of differing data types. In this case each index of the altWords array is related to each index of the scoreBoard array
        public int startNumber { get; set; }
        public int endNumber { get; set; }
        public int[] divisors { get; set; }
        public string[] altWords { get; set; }
        public int[] scoreBoard { get;}


        // Method for calling class instructions in order
        public void Run()
        {
            Intro();
            CountToNumber(startNumber, endNumber);
            PrintResults();
        }

        // Just some flavor to separate the start of the output from whatever was in the console before hand.
        public void Intro()
        {
            Console.Write("\nProgram Start:\n___________________________________________________\n");
        }

        // ensures range will be valid. If the beginning of the range is larger than the end then flip their values.
        public void ValidateRange()
        {
            var n = 0; // var to store state of property so it can be reassigned to another property if needed.
            if (startNumber > endNumber)
            {
                n = startNumber;
                startNumber = endNumber;
                endNumber = n;
            }
        }

        // Handles running the program in the defined range. 
        public void CountToNumber(int first, int last)
        {
            for (var i = startNumber; i <= endNumber; i++)
            {
                EvaluatePrint(i, divisors);// check what needs to be printed each iteration. Does so by making call to the EvaluatePrint method.

                if ((i - startNumber + 1) % 10 == 0 && i != 0) // if block to check if the current iteration (as long as it isn't zero) is divisible by 10. Go to new line if so.
                {                                          // in this check the iterator is shifted to start at zero so that the formatting works no matter what the start of the range is.
                    Console.Write("\n");
                }
            }
        }

        // Primary set of logic for determining flow of program. Checks the number passed into it against the divisors (array of ints in this case) to see what needs to be printed in the current iteration
        public void EvaluatePrint(int number, int[] arr)
        {
            var hits = 0;// setup var for tracking how many hits there are (up to two in this case). Every divisor that is a match gets added to this value.
                         // Allows any two numbers to be used as the divisors without changing anything in code. In the end hits will have one of the following values:
                         //                                                                                                                         hits = 0                - print number
                         //                                                                                                                         hits = divisor[0]       - print sweet
                         //                                                                                                                         hits = divisor[1]       - print salty
                         //                                                                                                                         hits = sum of divisors  - print sweet'nSalty

            foreach (var divisor in arr)// go thru array of divisors and check each one to see if it goes evenly into the current number
            {
                if (number % divisor == 0)// checking if number is multiple of divisor by seeing if it has a remainder when divided.
                {
                    hits += divisor; 
                }
            }

            // Set of if blocks to control what to print to the console based on what (if any) conditions were met to replace a number with a buzz word.
            //              -As a side note, this is where I stopped building around the idea of allowing for more divisors/buzz words to check for.
            //               This is where the program will fail if the Looper is instantiated with more than the expected number of divisors/buzz words(2/3 respectively).
            // Because hits = 0 will be most common, that is checked first so the program doesn't have to do a bunch of unnecessary comparisons each iteration.
            if (hits == 0)// If there were no matches
            {
                Console.Write(number + " ");// print number
            }
            else if (hits == arr[0])// If hits = the value of the 1st divisor
            {
                PrintAltString(altWords[0]);// Print the 1st buzz word
                UpdateScore(0);             // And increment the 1st score in the scoreboard
            }
            else if (hits == arr[1])// If hits = the value of the 2nd divisor
            {
                PrintAltString(altWords[1]);// Print the 2nd buzz word
                UpdateScore(1);             // And increment the 2nd score in the scoreboard
            }
            else if (hits == arr[0] + arr[1])// If hits = the sum of the 1st and 2nd divisors
            {
                PrintAltString(altWords[2]);// Print the 3rd buzz word
                UpdateScore(2);             // And increment the 3rd score in the scoreboard
            }
        }

        // Have the Console write whatever string is passed into the method and add proper spacing
        // Enables whatever we are replacing the number with to be more complex (if needed) without needing to duplicate code
        public void PrintAltString(string newWord)
        {
            Console.Write(newWord + " ");
        }

        // Method for updating the number of times whatever word appears. 'option' represents which index in the array needs to be incremented.
        public void UpdateScore(int option)
        {
            scoreBoard[option] += 1;
        }

        // Output formatted results to the console
        public void PrintResults()
        {
            Console.Write("\n^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^");// Start with a fancy line separating numbers from results
            for (var i = 0; i < altWords.Length; i++)                              // Loop thru every position in the arrays.
            {                                                                      // for is used instead of foreach because the incrementer is needed to reference multiple arrays of different data types.
                Console.Write("\n" + altWords[i] + " - Occurs " + scoreBoard[i] + " times");// Output the word and its corrosponding score the the console
            }
            Console.Write("\n___________________________________________________\n");// End with a line to separate the end of the program from the next prompt in the console
        }
    }
}
