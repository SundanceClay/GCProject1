// Main execution for Fitness Center Midterm Project with Team: Jake Jones, Lonnie Johnson, and Shawn Penning.
// This is primarily bullet 4 from Fitness Center Requirements assigned to Shawn but also bullet 5 assigned to Lonnie
//Create a list of 4 fitness center loacations 

//Enter information about the clubs (Street, city, state, postalcode, clubname, id)
using FitnessApp;

List<Club> clubList = new()
{
    new Club("Gratiot", "Detroit", "Michigan", "48224", "Detroit Club", "55555"),
    new Club("Lansing", "Lansing", "Michigan", "48864", "Lansing Club", "66666"),
    new Club("Airport Blvd", "Ann Arbor", "Michigan", "48103", "Ann Arbor Club", "77777"),
    new Club("23 Mile Road", "Rochester Hills", "Michigan", "48307", "Rochester Club", "88888"),
};

// which club are we? We need to set a Club for the user of this program.
string thisClubId = "55555";
Club thisClub = new Club("Street", "City", "State", "11111", "Default Club", "0"); 

foreach (var club in clubList)
{
    if (club.id == thisClubId)
    {
        Console.WriteLine($" {club.clubName} {club.id} - {club.street} {club.city}, {club.state} {club.postalCode}");
        thisClub = club;
    }
    else thisClub = club;
}

Console.WriteLine($"Welcome to {thisClub.clubName}.");
string yn = "y";
while (yn == "y")
{
    bool isNew;
    Console.WriteLine("What would you like to do?\n1. Add Members\n2. Remove Members\n" +
    "3. Display Member Information\n4. CheckIn Member\n5. Generate Member Bill/Points\n6. Exit the program.");
    int userToDo = userChoice(4);

    bool isSingleClub = true;
    switch (userToDo)
    {
        case 1:
            // Add Member
            Console.WriteLine("Add Member. Single Club or Multi-Club? s or m");
            if (Console.ReadLine().ToLower() == "s")
                isSingleClub = true; // Is Single Club membership vs multi-club membership.
            else
                isSingleClub = false;

            if (isSingleClub)
                FitnessApp.Member.SingleClubMember().AddMember();
            carList.Add(CarLotApp.AddCar(isNew));
            break;
        case 2:
            // Remove Member
            removeMember(memberList, member);
            Console.WriteLine($"{member} has been removed.");

            break;
        case 3:
            // Display Member Information
            CarLotApp.ListCars(carList);
            int buyCar;
            bool intYes = int.TryParse(Console.ReadLine(), out buyCar);
            if (intYes && buyCar <= carList.Count)
                carList = CarLotApp.BuyCar(buyCar, carList);
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
