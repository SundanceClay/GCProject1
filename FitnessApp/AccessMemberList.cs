using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class AccessMemberList
    {
        public static int ChooseMember(List<Member> membersList)
        {
            int memberId = 0;
            bool notValid = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\nType a member id, or '0' for list of members\n(or 'q' to return to main menu): ");
                Console.ForegroundColor = ConsoleColor.White;
                string idOrList = Console.ReadLine();

                if (int.TryParse(idOrList, out memberId)) // if valid member id entered (i.e. its an integer and not 0, use it else ask for another.
                {
                    if (memberId == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        DisplayMembers(membersList);
                        Console.ForegroundColor = ConsoleColor.White;
                        notValid = true;
                    }
                    else if (membersList.Contains(membersList.Where(x => x.Id == memberId).FirstOrDefault()))
                    {
                        notValid = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"The member Id entered, {memberId}, does not match any members on the list. Please try again. ");
                        Console.ForegroundColor = ConsoleColor.White;
                        notValid = true;
                    }
                }
                else
                {
                    if (idOrList == "q") // if user changes mind and wants to return to main menu without choosing.
                        notValid = false;
                    else
                        notValid = true; // Enter key or some non-integer was entered so need to continue loop.
                }
            }
            while (notValid == true);
            return memberId;
        }

        public static void DisplayMembers(List<Member> membersList)
        {
            Console.WriteLine();
            foreach (Member member in membersList)
            {
                Console.WriteLine($"{member.Id} {member.Name}");
            }
            Console.WriteLine();
        }
    }
}
