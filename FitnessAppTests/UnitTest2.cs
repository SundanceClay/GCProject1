using FitnessApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FitnessAppTests
{
    public class UnitTest2
    {
        [Fact]

        public void SingleClubMember()
        {
            //Arrange 
            Club club = new Club(4, "Rochester Club", "23 Mile Road", "Rochester Hills", "Michigan", "48307");
            SingleClubMember single = new SingleClubMember(1, "TestingName", 0);
            //Act
            single.CheckIn(club);
            //Assert
            Assert.True(single.Id == 1);
        }

    }
}
