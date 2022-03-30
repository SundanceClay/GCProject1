// Main execution for Fitness Center Midterm Project with Team: Jake Jones, Lonnie Johnson, and Shawn Penning.
// This is primarily bullet 4 from Fitness Center Requirements assigned to Shawn but also bullet 5 assigned to Lonnie
//Create a list of 4 fitness center loacations 

//Enter information about the clubs (Street, city, state, postalcode, clubname, id)
using FitnessApp;
using Newtonsoft.Json;
using System.Text.Json;




ClubList.DisplayClubList(ClubList.clubList);


int thisClubId = 2; // Future enhancement. Read and store club Id to file.

// Ask user to enter this club's ID
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write($"\nWelcome Fitness Center App user. We have this club as Club Id {thisClubId}." +
    $"\nTo change clubs, enter the new club Id here, or return to continue: ");
Console.ForegroundColor = ConsoleColor.White;

thisClubId = ClubList.WhichClub(thisClubId, ClubList.clubList);

// Now that club id is verified as valid, parse the club list and assign current club.
var club = ClubList.clubList.FirstOrDefault(x => x.id == thisClubId);
Console.WriteLine($"\n This club: {club.id} {club.clubName}, {club.street}, {club.city}, {club.state} {club.postalCode}\n");
Club thisClub = club;

List<Member> membersList = new();

Console.WriteLine($"Welcome to {thisClub.clubName}.");

membersList = Repository.ReadMemberListFromFile();

string yn = "y";
while (yn == "y")
{
    Console.Write("\n1. Add Members\n2. Remove Members\n" +
    "3. Display Member Information\n4. CheckIn Member\n5. Generate Member Bill/Points\n6. Exit the program.");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\n\nWhat would you like to do? ");
    Console.ForegroundColor = ConsoleColor.White;
    int userToDo = Main.userChoice(6);

    
    bool isSingleClub = true;
    switch (userToDo)
    {
        case 1:
            // Add Member
            
            Console.WriteLine("Add Member.\nPlease enter full name of new member: ");
            string fullname = Console.ReadLine();

            // Establish the id of the member at the end of the list for adding a new member after that.
            int lastId;
            try
            {
                lastId = membersList[membersList.Count-1].Id;
            }
            catch (Exception ex)
            {
                lastId = 0;
            }

            Console.WriteLine("Single Club or Multi-Club? s or m");
            
            if (Console.ReadLine().ToLower() == "s")
            {
                ClubList.DisplayClubList(ClubList.clubList);
                Console.Write($"\nWhich club does the new Single Club member choose?\n(Press Enter for current club #{thisClubId}, or choose club id): ");
                int chosenClubId = ClubList.WhichClub(thisClubId, ClubList.clubList);
            membersList.Add(new SingleClubMember(lastId + 1, fullname, chosenClubId));  
            }
            else
            {
                MultiClubMember member2 = new MultiClubMember(lastId + 1, fullname);
                membersList.Add(member2);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nNew member {membersList.Last().Name} was added.\n");
            Console.ForegroundColor = ConsoleColor.White;

            break;
        case 2:
            // Remove Member
            
            Console.WriteLine($"\nRemove Member from Member List.");
            int memberIdToRemove = AccessMemberList.ChooseMember(membersList);
            if (!(memberIdToRemove == 0)) // if 0 returned from ChooseMember, user wants to exit to main menu.
            { 
                Member memberToRemove = membersList.Where(x => x.Id == memberIdToRemove).First();
                membersList.Remove(memberToRemove);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{memberToRemove.Name} has been removed.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            break;
        case 3:
            // Display Member Information
            Console.WriteLine($"\nDisplay Member Information.");
            int memberIdToDisplay = AccessMemberList.ChooseMember(membersList);
            if (!(memberIdToDisplay == 0)) // if 0 returned from ChooseMember, user wants to exit to main menu.
            {
                Member member = membersList.Where(x => x.Id == memberIdToDisplay).First();
                if (member.GetType() == typeof(SingleClubMember))
                {
                    SingleClubMember member2 = member as SingleClubMember;
                    Console.ForegroundColor = ConsoleColor.Blue; 
                    Console.WriteLine($"\nId:{member.Id}  Name:{member.Name}  Club#:{member2.GetAssignedClubId()}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    MultiClubMember member3 = member as MultiClubMember;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\nId:{member.Id}  Name:{member.Name}  Points:{member3.GetPoints()}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            break;

        case 4:
            // CheckIn Member
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nCheck in. What member would you like to check in? ");
            Console.ForegroundColor = ConsoleColor.White;
            int checkInMemberId = AccessMemberList.ChooseMember(membersList);
            if (!(checkInMemberId == 0)) // if 0 returned from ChooseMember, user wants to exit to main menu.
            {
                Member member = membersList.Where(x => x.Id == checkInMemberId).First();
                member.CheckIn(thisClub);
            }
            break;

        case 5:
            // Generate member Bill/Points
            Console.WriteLine($"\nGenerate Bill includings Points.");
            int memberId = AccessMemberList.ChooseMember(membersList);
            if (!(memberId == 0)) // if 0 returned from ChooseMember, user wants to exit to main menu.
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Member member = membersList.Where(x => x.Id == memberId).First();
                if (member.GetType() == typeof(SingleClubMember))
                {
                    SingleClubMember member2 = member as SingleClubMember;
                    Console.WriteLine($"{member.Id} {member.Name}\nMember of Club #{member2.GetAssignedClubId()}\nMonthly Single Club Bill: $20.00");
                }
                else
                {
                    MultiClubMember member3 = member as MultiClubMember;
                    Console.WriteLine($"{member.Id} {member.Name}\nMulti-Club Member Points Accumulated: {member3.GetPoints()}\nMonthly Multi-Club Bill: $30.00");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            break;
        case 6:
            yn = "n";
            Console.WriteLine("\nThank you for using Fitness Center App. Now Exiting...\n\n");
            break;
        default:
            break;
    }
    
}
Repository.WriteMemberListToFile(membersList);





