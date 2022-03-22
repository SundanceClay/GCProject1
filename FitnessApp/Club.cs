using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public class Club
    {
        public string street { get; set; }
        public string city { get; set; }

        public string state { get; set; }

        public string postalCode { get; set; }
        public string clubName { get; set; }

        public string id { get; set; }


        public Club(string street, string city, string state, string postalCode, string clubName, string id)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            this.clubName = clubName;
            this.id = id; 
        }
    }

  

 
}
