// Main execution for Fitness Center Midterm Project with Team: Jake Jones, Lonnie Johnson, and Shawn Penning.
// This is primarily bullet 4 from Fitness Center Requirements assigned to Shawn but also bullet 5 assigned to Lonnie
//Create a list of 4 fitness center loacations 

//Enter information about the clubs (Street, city, state, postalcode, clubname, id)
using FitnessApp;
using Newtonsoft.Json;
using System.Text.Json;

List<Club> clubList = new()
{
    new Club(1, "Detroit Club","1122 Gratiot Ave", "Detroit", "Michigan", "48224"),
    new Club(2, "Lansing Club","45 Lansing Rd", "Lansing", "Michigan", "48864"),
    new Club(3, "Ann Arbor Club","333 Airport Blvd", "Ann Arbor", "Michigan", "48103"),
    new Club(4, "Rochester Club", "23 Mile Road", "Rochester Hills", "Michigan", "48307"),
};

DisplayClubList(clubList);


int thisClubId = 2; // Future enhancement. Read and store club Id to file.

// Ask user to enter this club's ID
Console.Write($"\nWelcome Fitness Center App user. We have this club as Club Id {thisClubId}." +
    $"\nTo change clubs, enter the new club Id here, or return to continue: ");

thisClubId = WhichClub(thisClubId, clubList);

// initialize default club, then set chosen club based on Club Id.
Club thisClub = new Club(0, "Club Not Assigned", "Street", "City", "State", "11111");

// Now that club id is verified as valid, parse the club list and assign current club.
foreach (var club in clubList)
{
    if (club.id == thisClubId)
    {
        Console.WriteLine($"\n This club: {club.id} {club.clubName}, {club.street}, {club.city}, {club.state} {club.postalCode}\n");
        thisClub = club;
    }

}

List<Member> membersList = new();


Console.WriteLine($"Welcome to {thisClub.clubName}.");
string yn = "y";
while (yn == "y")
{
    bool isNew;
    Console.WriteLine("What would you like to do?\n1. Add Members\n2. Remove Members\n" +
    "3. Display Member Information\n4. CheckIn Member\n5. Generate Member Bill/Points\n6. Exit the program.");
    int userToDo = userChoice(6);

    membersList = ReadMemberListFromFile();
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
                    DisplayClubList(clubList);
                    Console.WriteLine($"\nWhich club does the new Single Club member choose? (Press Enter for current club #{thisClubId}, or choose club id: ");
                    int chosenClubId = WhichClub(thisClubId, clubList);
                membersList.Add(new SingleClubMember(lastId + 1, fullname, chosenClubId));  
                }
            else
            {
                MultiClubMember member2 = new MultiClubMember(lastId + 1, fullname);
                membersList.Add(member2);
            }
            WriteMemberListToFile(membersList);
            Console.WriteLine($"\nNew member {membersList.Last().Name} was added.\n");
          /*  carList.Add(CarLotApp.AddCar(isNew)); */
            break;
        case 2:
            // Remove Member
            
            Console.WriteLine($"\nRemove Member from Member List.");
            int memberIdToRemove = ChooseMember(membersList);
            if (!(memberIdToRemove == 0)) // if 0 returned from ChooseMember, user wants to exit to main menu.
            { 
                Member memberToRemove = membersList.Where(x => x.Id == memberIdToRemove).First();
                membersList.Remove(memberToRemove);
                Console.WriteLine($"{memberToRemove.Name} has been removed.\n");
                WriteMemberListToFile(membersList);
            }
            break;
        case 3:
            // Display Member Information
            Console.WriteLine($"\nDisplay Member Information.");
            int memberIdToDisplay = ChooseMember(membersList);
            if (!(memberIdToDisplay == 0)) // if 0 returned from ChooseMember, user wants to exit to main menu.
            {
                Member member = membersList.Where(x => x.Id == memberIdToDisplay).First();
                if (member.GetType() == typeof(SingleClubMember))
                {
                    SingleClubMember member2 = member as SingleClubMember;
                    Console.WriteLine($"{member.Id} {member.Name} {member2.GetAssignedClubId()}");
                }
                else
                {
                    MultiClubMember member3 = member as MultiClubMember;
                    Console.WriteLine($"{member.Id} {member.Name} {member3.GetPoints()}");
                }
                    
                   
                
            }

            /*  CarLotApp.ListCars(carList);
              int buyCar;
              bool intYes = int.TryParse(Console.ReadLine(), out buyCar);
              if (intYes && buyCar <= carList.Count)
                  carList = CarLotApp.BuyCar(buyCar, carList);*/
            break;

        case 4:
            // CheckIn Member
            break;
        case 5:
            // Generate member Bill/Points
            break;
        case 6:
            yn = "n";
            break;
        default:

            break;
    }
}

static int ChooseMember(List<Member> membersList)
{
    int memberId = 0;
    bool notValid = true;
    do
    {
        Console.WriteLine($"\nEnter member id, or 0 to see the complete list of members, or q to return to main menu: ");
        string idOrList = Console.ReadLine();

        if (int.TryParse(idOrList, out memberId)) // if valid member id entered (i.e. its an integer and not 0, use it else ask for another.
        {
            if (memberId == 0)
            {
                DisplayMembers(membersList);
                notValid = true;
            }
            else if (membersList.Contains(membersList.Where(x => x.Id == memberId).FirstOrDefault()))
            {
                notValid = false;
            }
            else
            {
                Console.WriteLine($"The member Id entered, {memberId}, does not match any members on the list. Please try again. ");
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

    static void DisplayMembers(List<Member> membersList)
{
    Console.WriteLine();
    foreach (Member member in membersList)
    {
        Console.WriteLine($"{member.Id} {member.Name}");
    }
    Console.WriteLine();
}

static void DisplayClubList(List<Club> clubList) 
{ 
    foreach (Club club in clubList)
        Console.WriteLine($"{club.id} {club.clubName}, {club.street}, {club.city}, {club.state} {club.postalCode}");
}

static int WhichClub(int thisClubId, List<Club> clubList)
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
                Console.WriteLine($"The club Id entered, {newClubId}, does not match any known clubs. Please try again: ");
                notValid = true;
            }
        }
        else
            notValid = false; // Enter or some non-integer was entered so no need to continue.
    }
    while (notValid == true);
    return thisClubId;
}

static List<Member> WriteMemberListToFile(List<Member> membersList)
{
    Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
    serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
    serializer.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
    serializer.Formatting = Newtonsoft.Json.Formatting.Indented;

    string membersFile = @"C:\repos\memberlist.json";
    using (StreamWriter writer = new StreamWriter(membersFile))
    using (Newtonsoft.Json.JsonWriter jWriter = new Newtonsoft.Json.JsonTextWriter(writer)) 
    {
        serializer.Serialize(jWriter, membersList);
        writer.Close();
    } 

    return membersList;
}

static List<Member> ReadMemberListFromFile()
{
    string jsonString;
    string membersFile = @"C:\repos\memberlist.json";
    if (!File.Exists(membersFile)) // Check if the membersFile exists or create it if it doesn't.
    {
        File.Create(membersFile).Close();
        Console.WriteLine("Member file did not exist, but was created. You can now add members.\n");
        return new List<Member>();
    }
    else // No need to read if the file is brand new and empty.
    {
        List<Member> myMemberList = JsonConvert.DeserializeObject<List<Member>>(File.ReadAllText(membersFile), new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore,
        });
        return myMemberList;
    }
}


static int userChoice(int numChoices)
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
