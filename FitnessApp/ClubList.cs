using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class ClubList
    {
        public static List<Club> clubList = new()
        {
            new Club(1, "Detroit Club", "1122 Gratiot Ave", "Detroit", "Michigan", "48224"),
            new Club(2, "Lansing Club", "45 Lansing Rd", "Lansing", "Michigan", "48864"),
            new Club(3, "Ann Arbor Club", "333 Airport Blvd", "Ann Arbor", "Michigan", "48103"),
            new Club(4, "Rochester Club", "23 Mile Road", "Rochester Hills", "Michigan", "48307"),
        };

        public static void DisplayClubList(List<Club> clubList)
        {
            foreach (Club club in clubList)
                Console.WriteLine($"{club.id} {club.clubName}, {club.street}, {club.city}, {club.state} {club.postalCode}");
        }

        public static int WhichClub(int thisClubId, List<Club> clubList)
        {
            int newClubId;
            bool notValid = true;
            do
            {
                string checkClubId = Console.ReadLine();
                if (int.TryParse(checkClubId, out newClubId)) // if valid club id entered, use it else ask for another.
                {
                    if ((newClubId >= 1) && (newClubId <= clubList.Count))
                    {
                        thisClubId = newClubId;
                        notValid = false;
                    }
                    else
                    {
                        Console.WriteLine($"\nThe club Id entered, {newClubId}, does not match any known clubs. Please try again: ");
                        notValid = true;
                    }
                }
                else
                    notValid = false; // Enter or some non-integer was entered so no need to continue.
            }
            while (notValid == true);
            Console.WriteLine();
            return thisClubId;
        }
    }
}
