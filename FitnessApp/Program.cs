// See https://aka.ms/new-console-template for more information





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



foreach(var club in clubList)
{
    if(club.id == "55555")
    {
        Console.WriteLine($" {club.clubName} {club.id} - {club.street} {club.city}, {club.state} {club.postalCode}");

    }

}