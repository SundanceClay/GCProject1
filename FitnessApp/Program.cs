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
// Display list of clubs
foreach (Club club in clubList)
    Console.WriteLine($"{club.id} {club.clubName}, {club.street}, {club.city}, {club.state} {club.postalCode}"); 

int thisClubId = 2; // Future enhancement. Read and store club Id to file.
int newClubId;
// Ask user to enter this club's ID
Console.Write($"\nWelcome Fitness Center App user. We have this club as Club Id {thisClubId}." +
    $"\nTo change clubs, enter the new club Id here, or return to continue: ");
// initialize current club, then set based on Club Id.
Club thisClub = new Club(0, "Club Not Assigned", "Street", "City", "State", "11111");
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
            int lastId;
            try
            {
                lastId = membersList[membersList.Count-1].Id;
            }
            catch (Exception ex)
            {
                lastId = 1;
            }
            Console.WriteLine("Single Club or Multi-Club? s or m");
            
                if (Console.ReadLine().ToLower() == "s")
                membersList.Add(new SingleClubMember(lastId +1, fullname, thisClub.id));
            else
                membersList.Add(new MultiClubMember(lastId + 1, fullname));
            WriteMemberListToFile(membersList);
          /*  carList.Add(CarLotApp.AddCar(isNew)); */
            break;
        case 2:
            // Remove Member
          /*  removeMember(memberList, member);
            Console.WriteLine($"{member} has been removed.");*/

            break;
        case 3:
            // Display Member Information
            Console.WriteLine();
            foreach (Member member in membersList)
            {
                Console.WriteLine($"{member.Id} {member.Name}");
            }
            Console.WriteLine();
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
