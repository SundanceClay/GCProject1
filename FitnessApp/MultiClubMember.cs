using System;
namespace FitnessApp
{
    public class MultiClubMember : Member
    {
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
        }

        public int GetPoints()
        {
            return _points;
        }
    }

}
