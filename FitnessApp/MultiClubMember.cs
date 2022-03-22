using System;
namespace FitnessApp
{
    public class MultiClubMember : Member
    {
        private int _points { get; set; }


        public override void CheckIn(Club club)
        {
            _points++;
        }
    }

}
