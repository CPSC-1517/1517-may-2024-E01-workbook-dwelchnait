using FluentAssertions;
using OOPsReview;
using System.Reflection;

namespace UnitTestingForSystem
{
    public class Employment_Should
    {
        
        //#region Valid Data
        //[Fact]
        //public void Create_New_Default_Instance()
        //{
        //    //Where - Arrangement setup
        //    string expectedTitle = "Unknown";
        //    SupervisoryLevel expectedLevel = SupervisoryLevel.TeamMember;
        //    DateTime expectedStartDate = DateTime.Today;
        //    double expectedYears = 0;

        //    //When - Act execution
        //    Employment actual = new Employment();

        //    //Then - Assert check
        //    actual.Title.Should().Be(expectedTitle);
        //    actual.Level.Should().Be(expectedLevel);
        //    actual.StartDate.Should().Be(expectedStartDate);
        //    actual.Years.Should().Be(expectedYears);
        //}

        //[Fact]
        //public void Create_New_Greedy_Instance()
        //{
        //    //Where - Arrangement setup
        //    string expectedTitle = "SAS Lead";
        //    SupervisoryLevel expectedLevel = SupervisoryLevel.TeamLeader;
        //    DateTime expectedStartDate = new DateTime(2020, 10, 24);
        //    double expectedYears = 2.6;

        //    //When - Act execution
        //    Employment actual = new Employment(expectedTitle, expectedLevel, expectedStartDate, expectedYears);

        //    //Then - Assert check
        //    actual.Title.Should().Be(expectedTitle);
        //    actual.Level.Should().Be(expectedLevel);
        //    actual.StartDate.Should().Be(expectedStartDate);
        //    actual.Years.Should().Be(expectedYears);
        //}

        //[Fact]
        //public void Create_New_Greedy_Instance_With_Years_Default()
        //{
        //    //Where - Arrangement setup
        //    string expectedTitle = "SAS Lead";
        //    SupervisoryLevel expectedLevel = SupervisoryLevel.TeamLeader;
        //    DateTime expectedStartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - expectedStartDate;
        //    double expectedYears = Math.Round((days.Days / 365.2), 1);

        //    //When - Act execution
        //    Employment actual = new Employment(expectedTitle, expectedLevel, expectedStartDate);

        //    //Then - Assert check
        //    actual.Title.Should().Be(expectedTitle);
        //    actual.Level.Should().Be(expectedLevel);
        //    actual.StartDate.Should().Be(expectedStartDate);
        //    actual.Years.Should().Be(expectedYears);
        //}

        //[Fact]
        //public void Change_the_Title()
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);
        //    string expectedTitle = "Development Head";
        //    //When - Act execution
        //    sut.Title ="Development Head";

        //    //Then - Assert check
        //    sut.Title.Should().Be(expectedTitle);

        //}

        //[Fact]
        //public void Change_the_Years()
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);
        //    double expectedYears = 5.5;
        //    //When - Act execution
        //    sut.Years = 5.5;

        //    //Then - Assert check
        //    sut.Years.Should().Be(expectedYears);

        //}

        //[Fact]
        //public void Set_The_SupervisoryLevel()
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);
        //    SupervisoryLevel expectedLevel = SupervisoryLevel.Supervisor;
        //    //When - Act execution
        //    sut.SetEmploymentResponsiblityLevel(SupervisoryLevel.Supervisor);

        //    //Then - Assert check
        //    sut.Level.Should().Be(expectedLevel);

        //}

        //[Fact]
        //public void Set_The_Correct_StartDate()
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);
        //    DateTime expectedDate = new DateTime(2019, 10, 24);
        //    //When - Act execution
        //    sut.CorrectStartDate(new DateTime(2019, 10, 24));

        //    //Then - Assert check
        //    sut.StartDate.Should().Be(expectedDate);

        //}

        //[Fact]
        //public void Correct_The_Years_of_Experience()
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);

        //    sut.CorrectStartDate(new DateTime(2019, 10, 24));

        //    days = DateTime.Today - sut.StartDate;
        //    double expectedYears = Math.Round((days.Days / 365.2), 1);


        //    //When - Act execution
        //    double actual = sut.UpdateCurrentEmploymentYearsExperince();

        //    //Then - Assert check
        //    actual.Should().Be(expectedYears);

        //}

        //[Fact]
        //public void Create_CSV_String()
        //{
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);
        //    //string expectedCSV = $"SAS Lead,TeamLeader,Oct 24, 2020,{Years}"; //Nait
        //    string expectedCSV = $"SAS Lead,TeamLeader,Oct. 24 2020,{Years}"; //home

        //    //When - Act execution
        //    string actual = sut.ToString();

        //    //Then - Assert check
        //    actual.Should().Be(expectedCSV);

        //}

        //[Fact]
        //public void Parse_A_String_Into_An_Employment_Instance()
        //{
        //    //Where - Arrangement setup
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    string CSVDataRecord = $"SAS Lead,TeamLeader,Oct. 24 2020,{Years}\n"; //home

        //    string expectedCSV = $"SAS Lead,TeamLeader,Oct. 24 2020,{Years}";
        //    //When - Act execution
        //    Employment actual = Employment.Parse(CSVDataRecord);

        //    //Then - Assert check
        //    actual.ToString().Should().Be(expectedCSV);
        //}
        
        //[Fact]
        //public void TryParse_A_String_Into_An_Employment_Instance()
        //{
        //    //Where - Arrangement setup
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    string CSVDataRecord = $"SAS Lead,TeamLeader,Oct. 24 2020,{Years}\n"; //home

        //    string expectedCSV = $"SAS Lead,TeamLeader,Oct. 24 2020,{Years}";
        //    Employment actual = null;
        //   //When - Act execution
        //   bool pass = Employment.TryParse(CSVDataRecord, out actual);

        //    //Then - Assert check
        //    actual.ToString().Should().Be(expectedCSV);
        //    pass.Should().BeTrue();
        //}
        //#endregion

        //#region Invalid Data
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("     ")]
        //public void Create_New_Greedy_Instance_Throws_Title_Exception(string title)
        //{
        //    //Where - Arrangement setup
        //    //string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamMember;
        //    DateTime StartDate = DateTime.Today;
        //    double Years = 0;

        //    //When - Act execution
        //    Action action = () => new Employment(title, Level, StartDate, Years);

        //    //Then - Assert check
        //    action.Should().Throw<ArgumentNullException>();
        //}

        //[Theory]
        //[InlineData((SupervisoryLevel)15)]
        //public void Create_New_Greedy_Instance_Throws_SupervisorLevel_Exception(SupervisoryLevel level)
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    //SupervisoryLevel Level = SupervisoryLevel.TeamMember;
        //    DateTime StartDate = DateTime.Today;
        //    double Years = 0;

        //    //When - Act execution
        //    Action action = () => new Employment(Title, level, StartDate, Years);

        //    //Then - Assert check
        //    action.Should().Throw<ArgumentException>().WithMessage("*15*");
        //}

        //[Theory]
        //[InlineData("2902/10/24")]
        //public void Create_New_Greedy_Instance_Throws_StartDate_Future_Exception(string startdate)
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamMember;
        //    DateTime StartDate = DateTime.Parse(startdate);
        //    double Years = 0;

        //    //When - Act execution
        //    Action action = () => new Employment(Title, Level, StartDate, Years);

        //    //Then - Assert check
        //    action.Should().Throw<ArgumentException>().WithMessage("*future");
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData("      ")]
        //public void Directly_Change_Title_Throws__Exception(string title)
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamMember;
        //    DateTime StartDate = DateTime.Today;
        //    double Years = 0;
        //    Employment sut = new Employment(Title, Level, StartDate, Years);

        //    //When - Act execution
        //    Action action = () => sut.Title = title;

        //    //Then - Assert check
        //    action.Should().Throw<ArgumentNullException>();
        //}

        //[Theory]

        //[InlineData(-5.5)]
        //public void Directly_Change_Years_Throws_Exception(double years)
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamMember;
        //    DateTime StartDate = DateTime.Today;
        //    double Years = 0;
        //    Employment sut = new Employment(Title, Level, StartDate, Years);

        //    //When - Act execution
        //    Action action = () => sut.Years = years;

        //    //Then - Assert check
        //    action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*-5.5*");
        //}

        //[Fact]
        //public void Set_The_SupervisoryLevel_Throws_Exception()
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);
        //    SupervisoryLevel badLevel = (SupervisoryLevel)15;
        //    //When - Act execution
        //    Action action = () => sut.SetEmploymentResponsiblityLevel(badLevel);

        //    //Then - Assert check
        //    action.Should().Throw<ArgumentException>().WithMessage("*15*");

        //}

        //[Fact]
        //public void Set_The_Correct_StartDate_Throws_Exception()
        //{
        //    //Where - Arrangement setup
        //    string Title = "SAS Lead";
        //    SupervisoryLevel Level = SupervisoryLevel.TeamLeader;
        //    DateTime StartDate = new DateTime(2020, 10, 24);
        //    TimeSpan days = DateTime.Today - StartDate;
        //    double Years = Math.Round((days.Days / 365.2), 1);
        //    Employment sut = new Employment(Title, Level, StartDate, Years);

        //    //When - Act execution
        //    Action action = () => sut.CorrectStartDate(new DateTime(2919, 10, 24));

        //    //Then - Assert check
        //    action.Should().Throw<ArgumentException>().WithMessage("*future*");

        //}

        //[Theory]
        //[InlineData(@"SAS LeadTeamLeader,Oct. 24 2020,2.8\n")] //not enough parts
        //[InlineData(@"SAS Lead,TeamLeader,Oct. 24 2020,2.8,extra field\n")] //too many parts
        //public void Throw_Exception_When_Invalid_Parsing_A_String_Into_An_Employment_Instance(string csvdatarecord)
        //{
        //    //Where - Arrangement setup
        //    Employment actual = null;

        //    //When - Act execution
        //    Action action = () =>  actual = Employment.Parse(csvdatarecord);

        //    //Then - Assert check
        //    action.Should().Throw<FormatException>().WithMessage("*expected format*");
        //}
        
        //[Theory]
        //[InlineData(@"SAS LeadTeamLeader,Oct. 24 2020,2.8\n")] //not enough parts
        //[InlineData(@"SAS Lead,TeamLeader,Oct. 24 2020,2.8,extra field\n")] //too many parts
        //public void Return_A_False_When_Invalid_TryParsing_A_String_Into_An_Employment_Instance(string csvdatarecord)
        //{
        //    //Where - Arrangement setup
        //    Employment actual = null;
        //    bool pass = false;
            

        //    //When - Act execution
        //    pass = Employment.TryParse(csvdatarecord, out actual);

        //    //Then - Assert check
        //    pass.Should().BeFalse();
        //    actual.Should().BeNull();
        //}
        //#endregion
    }
}