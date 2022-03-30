using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class Main
    {
        public static int userChoice(int numChoices)
        {
            bool parsedSuccessfully = false;
            int userToDo = 1;
            do
            {
                string userInput = Console.ReadLine();
                parsedSuccessfully = int.TryParse(userInput, out userToDo);
                if (!parsedSuccessfully || userToDo <= 0 || userToDo > numChoices)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Entry not valid.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (!parsedSuccessfully);
            return userToDo;
        }
    }
}
