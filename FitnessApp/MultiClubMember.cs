using Newtonsoft.Json;
using System;
namespace FitnessApp
{
    public class MultiClubMember : Member
    {
        [JsonProperty("_points")]
        private int _points { get; set; }
        public MultiClubMember(int id, string name) : base(id, name)
        {
            Id = id;
            Name = name;
           // _points = points; removed this and no longer passing it in.
        }


        public override void CheckIn(Club club)
        {
            _points++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nMultiClub Member {Name} is Checked In.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public int GetPoints()
        {
            return _points;
        }
    }

}
