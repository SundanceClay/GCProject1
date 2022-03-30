using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    internal class SingleClubMember : Member
    {
        [JsonProperty("_assignedClubId")]
        private int _assignedClubId;
        public SingleClubMember(int id, string name, int assignedClubId) : base(id, name)
        {
            Id = id;
            Name = name;
            _assignedClubId = assignedClubId;
        }

        public override void CheckIn(Club club)
        {
            if (_assignedClubId == 0)
            {
                _assignedClubId = club.id;

            }
            else
            {
                if (_assignedClubId != club.id) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're in the wrong club.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nSingleClub Member {Name} is now Checked In.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public int GetAssignedClubId()
        {
            return _assignedClubId;
        }

    }
}
