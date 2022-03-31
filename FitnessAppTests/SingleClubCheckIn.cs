using FitnessApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FitnessAppTests
{
    public class SingleClubCheckIn
    {
        [Fact]

        public void SingleClubMember()
        {
            //Arrange 
            Club club = new Club(4, "Rochester Club", "23 Mile Road", "Rochester Hills", "Michigan", "48307");
            SingleClubMember single = new SingleClubMember(1, "TestingName", 1);
            SingleClubMember single2 = new SingleClubMember(2, "TestingName", 2);
            //Act
            single.CheckIn(club);
            //Assert
            Assert.True(single.Id == 1); //Confirm that id and club id match. If the club id is 
            Assert.True(single2.Id == 2);
            Assert.True(single2.Id != 3);


            
        }

    }
}
