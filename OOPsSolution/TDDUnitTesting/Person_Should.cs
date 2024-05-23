using OOPsReview;
using FluentAssertions;

namespace TDDUnitTesting
{
    public class Person_Should
    {
        #region Constructors
        [Fact]
        public void Create_Instance_Using_Default_Constructor()
        {
            //Arrange (setup)
            string expectedFirstName = "Unknown";
            string expectedLastName = "Unknown";

            //Act (the test action)
            //sut subject under test
            Person sut = new Person();

            //Assert (checking)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }
        [Fact]
        public void Create_Instance_Using_Greedy_Constructor_Without_Address_And_Employments()
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";

            //Act (the test action)
            //sut subject under test
            Person sut = new Person(expectedFirstName, expectedLastName, null, null);

            //Assert (checking)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }
        [Fact]
        public void Create_Instance_Using_Greedy_Constructor_With_Address_Without_Employments()
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");

            //Act (the test action)
            //sut subject under test
            Person sut = new Person(expectedFirstName, expectedLastName, expectedAdress, null);

            //Assert (checking)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAdress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }
        [Fact]
        public void Create_Instance_Using_Greedy_Constructor_With_Address_And_Employments()
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");
            Employment one = new Employment("Team Member", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2013/10/23"), 6.5);
            Employment two = new Employment("Team Lead", SupervisoryLevel.TeamLeader,
                                DateTime.Parse("2020/04/13"), 6.5);
            List<Employment> expectedEmployments = new List<Employment>();
            expectedEmployments.Add(one);
            expectedEmployments.Add(two);

            //Act (the test action)
            //sut subject under test
            Person sut = new Person(expectedFirstName, expectedLastName, 
                        expectedAdress, expectedEmployments);

            //Assert (checking)
            sut.FirstName.Should().Be(expectedFirstName);
            sut.LastName.Should().Be(expectedLastName);
            sut.Address.Should().Be(expectedAdress);
            sut.EmploymentPositions.Count().Should().Be(2);
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedEmployments);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Using_Greedy_Constructor_Missing_FirstName(string firstname)
        {
            //Arrange (setup)
           // string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");
            Employment one = new Employment("Team Member", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2013/10/23"), 6.5);
            Employment two = new Employment("Team Lead", SupervisoryLevel.TeamLeader,
                                DateTime.Parse("2020/04/13"), 6.5);
            List<Employment> expectedEmployments = new List<Employment>();
            expectedEmployments.Add(one);
            expectedEmployments.Add(two);

            //Act (the test action)
            //capture the result of the action call
            Action action = () => new Person(firstname, expectedLastName,
                        expectedAdress, expectedEmployments);

            //Assert (checking)
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Using_Greedy_Constructor_Missing_LastName(string lastname)
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            //string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");
            Employment one = new Employment("Team Member", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2013/10/23"), 6.5);
            Employment two = new Employment("Team Lead", SupervisoryLevel.TeamLeader,
                                DateTime.Parse("2020/04/13"), 6.5);
            List<Employment> expectedEmployments = new List<Employment>();
            expectedEmployments.Add(one);
            expectedEmployments.Add(two);

            //Act (the test action)
            //capture the result of the action call
            Action action = () => new Person(expectedFirstName, lastname,
                        expectedAdress, expectedEmployments);

            //Assert (checking)
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion

        #region Properties
        [Fact]
        public void Change_FirstName_Directly()
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");
            Person sut = new Person(expectedFirstName, expectedLastName,
                        expectedAdress, null);

            //Act (the test action)
            //sut subject under test
            sut.FirstName = "Bob";

            //Assert (checking)
            sut.FirstName.Should().Be("Bob");
           
            
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Changing_FirstName_Missing_FirstName(string firstname)
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");
            Person sut = new Person(expectedFirstName, expectedLastName,
                       expectedAdress, null);

            //Act (the test action)
            //capture the result of the action call
            Action action = () => sut.FirstName = firstname;

            //Assert (checking)
            action.Should().Throw<ArgumentNullException>();
        }

        #endregion
    }
}