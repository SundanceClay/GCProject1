using FitnessApp;
using Xunit;

namespace FitnessAppTests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckinMultiMemberIncreasePoints()
        {
            //Arrange
            Club club = new Club(4, "Rochester Club", "23 Mile Road", "Rochester Hills", "Michigan", "48307");
            MultiClubMember newMember = new MultiClubMember(1, "TestName");
            //Act
            newMember.CheckIn(club);
            newMember.CheckIn(club);
            //Assert
            Assert.Equal(newMember.GetPoints(),2);
        }
    }
}