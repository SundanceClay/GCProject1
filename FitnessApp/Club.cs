using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class Club
    {
        public int id { get; set; }
        public string clubName { get; set; }
        public string street { get; set; }
        public string city { get; set; }

        public string state { get; set; }

        public string postalCode { get; set; }
        

        


        public Club(int id, string clubName, string street, string city, string state, string postalCode)
        {
            this.id = id;
            this.clubName = clubName;
            this.street = street;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
        }
    }




}
