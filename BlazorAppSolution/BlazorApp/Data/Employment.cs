using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
               private string _Title;
        private SupervisoryLevel _Level;
        private double _Years;


        public string Title
        {
            get { return _Title; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                  
                    throw new ArgumentNullException("Title is required");
                }
              
                _Title = value;
              

            }
        }

       
        public SupervisoryLevel Level
        {
            get { return _Level; }
            private set 
            { 
                if(!Enum.IsDefined(typeof(SupervisoryLevel), value))
                {
                    throw new ArgumentException($"Supervisory level is invalid: {value}");
                }
                _Level = value;
            }
        }
       
        public double Years
        {
            get { return _Years; }
          
            private set
            {
                 _Years = value;
            }
        }
   
        
        public DateTime StartDate { get; set; }

        public Employment()
        {
            
            Title ="unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;

            Years = 0.0;
        }
     
  
        public Employment(string title, SupervisoryLevel level,
                            DateTime startdate, double years = 0.0)
        {
     
            Title = title;
            Level = level;
          
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future.");
            }
            StartDate = startdate;

     
            if (years < 0)
          
            {
                throw new ArgumentOutOfRangeException($"Year value of {years} is invalid. Cannot be negative");
            }
            else
            {
                if (years == 0)
                {
                    TimeSpan days = DateTime.Today - startdate;
                    Years = Math.Round((days.Days / 365.2), 1);
                }
                else
                {
                    Years = years;
                }
            }
        }

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            Level = level;
        }

         public override string ToString()
        {
             return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years}";
        }

 
        public void CorrectStartDate(DateTime startdate)
        {
 
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future.");
            }
            StartDate = startdate;

            TimeSpan days = DateTime.Today - startdate;
            Years = Math.Round((days.Days / 365.2), 1);

        }

        //Parsing(string)

        //attempts to change the contents of a string to another datatype

        //parsing for this class assumes the passed string will resemble the
        //  greedy constructor: having sufficient values to pass to the greedy
        //  constructor
        //this method contains basic validation on the number of fields
        //  if there are insufficient values then expected an error can be thrown
        //example
        //    string 55 --> int x = int.Parse(string); <-- success
        //           bob --> int x = int.Parse(string); <-- abort with a message

        //if this can be done on an int class why not on our Employment class?
        //we will need to add a method (Parse) that receives a string
        //  the string will need to have sufficient values to create a proper Employment

        //this method needs to be able to be called without an instance of Employment
        //  in existence
        //therefore the method will be a static method

        public static Employment Parse(string item)
        {
            //split the incoming string into individual field values
            //this splitting is done using the string.Split(delimiter) method
            //the Split method returns an array of string values
            //the delimiter is the character that is used on your string to
            //      separate the individual values
            //The delimiter can be any character
            //Our is a csv string therefore the character should be a comma (,)

            string[] pieces = item.Split(',');

            //verify that sufficient and correct number of values exist to
            //      create the Employment instance
            //if not, throw an exception (FormatException)
            if (pieces.Length != 4)
            {
                throw new FormatException($"String not in expected format. Missing/excessive" +
                    $" value(s): {item}");
            }

            //create an instance of Employment with the supplied values
            //as the instance is created using the constructor, the validation
            //  of the values automatically happens in the properties
            //therefore individual validation does NOT need to be done here
            //as the individaul values are passed to the constructor as arguments
            //  any data conversion will be done in the "new" statement
            return new Employment(pieces[0],
                                  (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), pieces[1]),
                                  DateTime.Parse(pieces[2]),
                                  double.Parse(pieces[3]));

        }
    }
}
