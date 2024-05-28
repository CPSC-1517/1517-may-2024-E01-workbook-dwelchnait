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

        [Fact]
        public void Change_LastName_Directly()
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
            sut.LastName = "Bob";

            //Assert (checking)
            sut.LastName.Should().Be("Bob");


        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Exception_Changing_LastName_Missing_LastName(string lastname)
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
            Action action = () => sut.LastName = lastname;

            //Assert (checking)
            action.Should().Throw<ArgumentNullException>();
        }

        #endregion

        #region Methods
        [Fact]
        public void Change_Full_Name()
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
            sut.ChangeFullName("Shirley","Ujest");

            //Assert (checking)
            sut.FullName.Should().Be("Ujest, Shirley");
        }
        [Theory]
        [InlineData(null,"Ujest")]
        [InlineData("", "Ujest")]
        [InlineData("    ", "Ujest")]
        [InlineData("Shirley",null)]
        [InlineData("Shirley", "")]
        [InlineData("Shirley", "    ")]
        public void Throw_Exception_Changing_Full_Name_Missing_A_Name_Value(string firstname, string lastname)
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
            Action action = () => sut.ChangeFullName(firstname, lastname); 

            //Assert (checking)
            action.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void Add_First_New_Employment_Instance_To_Person()
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");
            Person sut = new Person(expectedFirstName, expectedLastName,
                        expectedAdress, null);

            //need an instance of Employment
            Employment newEmployment = new Employment("Boss", SupervisoryLevel.DepartmentHead,
                                            DateTime.Parse("2020/03/15"));

            //Act (the test action)
            //sut subject under test
            sut.AddEmployment(newEmployment);

            //Assert (checking)
            sut.EmploymentPositions.Should().NotBeEmpty();
            sut.EmploymentPositions.Count().Should().Be(1);
            sut.EmploymentPositions[0].Should().BeSameAs(newEmployment);
        }

        [Fact]
        public void Throw_ArgumentNullException_On_Add_Employment_With_No_Argument_Value()
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
            Action action = () => sut.AddEmployment(null);

            //Assert (checking)
            action.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void Add_Another_Employment_To_History_Of_Positions()
        {
            //Arrange (setup)
            string expectedFirstName = "Lowand";
            string expectedLastName = "Behold";
            ResidentAddress expectedAdress = new ResidentAddress(12, "Maple St.",
                                    "Edmonton", "AB", "T6Y7U8");

            //create a collection to have on our person employment history
            //we will add another employment to this history
            //build individual instances and save to separate variables
            //NOTE: each instance not only has it data, it also has a GUID value
            //When we do checks we need to maintain this GUID value
            Employment emp1 = new Employment("PC II", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2013/03/16"), 3.5);
            Employment emp2 = new Employment("PC III", SupervisoryLevel.TeamMember,
                                DateTime.Parse("2016/09/16"), 1.5);
            Employment emp3 = new Employment("TL I", SupervisoryLevel.TeamLeader,
                                DateTime.Parse("2018/03/16"), 4.2);
            List<Employment> startingPositions = new List<Employment>()
            {
                emp1, emp2, emp3
            };
            Person sut = new Person(expectedFirstName, expectedLastName,
                        expectedAdress, startingPositions);

            //need an instance of Employment
            Employment newEmployment = new Employment("Boss", SupervisoryLevel.DepartmentHead,
                                            DateTime.Parse("2022/05/15"));

            //if one needs to compare list A to list B, you need to create list B
            //using the initial instances of your collection
            List<Employment> expectedEmploymentPositions = new List<Employment>()
            {
                emp1, emp2, emp3, newEmployment
            };

            //Act (the test action)
            //sut subject under test
            sut.AddEmployment(newEmployment);

            //Assert (checking)
            sut.EmploymentPositions.Should().NotBeEmpty();
            sut.EmploymentPositions.Count().Should().Be(4);
            sut.EmploymentPositions[3].Should().BeSameAs(newEmployment);

            //check the contents of a collection to be IDENTICAL to another collection
            //compare two separate phyiscal copies of the data together
            sut.EmploymentPositions.Should().ContainInConsecutiveOrder(expectedEmploymentPositions);
        }
        #endregion
    }
}