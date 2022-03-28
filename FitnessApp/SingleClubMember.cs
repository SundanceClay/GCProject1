using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class SingleClubMember : Member
    {
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
                    Console.WriteLine("You're in the wrong club.");
            }
        }

    }
}
