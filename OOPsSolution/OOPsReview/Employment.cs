using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {
        //a class is a programmer defined data-type

        //data member
        //standards:
        //  will be private
        //  names will begin with an underscore (_)
        //  Pascal-case
        //required: optional
        //when used: 
        //  for storing instance data
        //  for internal coding as temporary variables
        //  include constants (all constants names are upper case)
        private string _Title;
        private SupervisoryLevel _Level;
        private double _Years;


        //properties
        //Title
        //since there is validation, the property will be fully-implemented
        //since fully-implemented, one requires a data member
        public string Title
        {
            //referred to as the accessor
            //get is a required item in a property
            get { return _Title; }

            //referred to as the mutator
            //incoming data is accessed using the keyword value
            //the set is an optional item in a property
            //open to the public by default
            //can be restricted to use ONLY with the constuctor/method
            //  by setting the access to the set to: private
            //IF the set is private the only way to access a value
            //  to the property is via: a constructor OR a behaviour(method)

            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    //absolutely NO console commands
                    throw new ArgumentNullException("Title is required");
                }
                //else
                //{
                _Title = value;
                //}

            }
        }

        //enum SupervisoryLevel will have additional logic to test if the value
        //      supplied to the field is actually defined in the enum
        //therefore this property will be fully-implemented
        //the private set will NOT allow a piece of code outside of this class
        //  to change the value of the property
        //this will force any code using this class to set the Level either by
        //  the a constructor OR a behaviour (method)
        //it basically makes the Level a read only field when accessed directly
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
        //Years will need to be a positive zero or greater value
        //double
        //therefore this property needs to be fully-implemented IF
        //  the validation is within the property
        //NOTE: validations CAN be code elsewhere within your class
        //      if so, you need to restrict the set access to the
        //      property so that any data will be forced through the
        //      validation logic located elsewhere
        public double Years
        {
            get { return _Years; }
            //set 
            //{

            //    if (value < 0)
            //    {
            //        throw new ArgumentOutOfRangeException($"Year value {value} is invalid. Must be 0 or greater.");
            //    }
            //    _Years = value;
            //}
            private set
            {
                //if the set was private validation could be elsewhere
              
                _Years = value;
            }
        }
        //this property is an example of an auto-implemented property
        //there is no validation in the property
        //therefore no private data member is required
        //the system will generate an internal storage area for the data
        //      and handle the setting and retreiving from that storage area
        
        public DateTime StartDate { get; set; }

        //constructors
        //your class does not technically need a constructor
        //if you code a constructor for your class you are responsible for coding ALL constructors
        //if you do not code a constructor then the system will assign the software datatype defaults
        //  to your variables (data members)

        //syntax: accesslevel constructorname([list of parameters]) { .... }
        //NOTE: NO return datatype
        //      the constructorname MUST be the class name

        //Default
        //simulates the "sysem defaults"
        public Employment()
        {
            //if there is no code within this constructor, the actions for setting
            //  your internal fields will be using the system defaults for the datatype

            //optionally
            // you could assign values to your intal fields within this constructor typically
            // using literal values
            //Why?
            // your internal fields may have validation attached to the data for the field
            // this validation is usually within the property
            // you would wish to have valid data values for your internal fields
            Title ="unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;

            //Years?
            //the defualt is fine (0)
            //however if you wish you could actually assign the value 0
            Years = 0.0;
        }
     
        //Greedy
        //this is the constructor typically used to assign values to a instance at the time of
        //    creation
        //the list of parameters may or maynot contain default parameter values
        //if you have assigned default parameter values then those parameters MUST be at the end of
        //  the parameter list
        public Employment(string title, SupervisoryLevel level,
                            DateTime startdate, double years = 0.0)
        {
            //here, year is a parameter with a defualt value
            Title = title;
            Level = level;
            //Years = years; incorrect due to unit testing

            //one could add valiation, especially if the property has a private set  OR the property
            //  is an auto-implemented property that has restrictions
            //example
            //validation, start date must not exist in the future
            //validation can be done anywhere in your class
            //since the property is auto-implemented AND/OR has a private set,
            //      validation can be done  in the constructor OR a behaviour 
            //      that alters the property
            //IF the validation is done in the property, IT WOULD NOT be an
            //      auto-implemented property BUT a fully-implemented property
            // .Today has a time of 00:00:00 AM
            // .Now has a specific time of day 13:05:45 PM
            //by using the .Today.AddDays(1) you cover all times on a specific date

            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future.");
            }
            StartDate = startdate;

            //Wait to add this until doing unit tests demonstration
            //this will demonstrate a missed requirement caught by a unit test
            //add the generation of the years when the default values exists
            //this was discovered by the failure of the unit test for the constructor
           // if (years < 0)
            if (!Utilities.IsPositive(years))
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



        //methods

        //syntax: access returndatatype methodname ([list of parameters]) { ..... }

        //REMEMBER: YOU HAVE ACCESS TO ALL VALUES WITHIN THE INSTANCE SO YOU DO NOT
        //          HAVE TO PASS IN VALUES THAT ARE ALREADY CONTAINED IN THE INSTANCE.

        public void SetEmploymentResponsibilityLevel(SupervisoryLevel level)
        {
            //the property has a private set
            //the property has validation, therefore, if I assign the parameter via the property
            //  the validation in the property will check the value
            Level = level;
        }

        //override the default class method called ToString()
        public override string ToString()
        {
            //this string is known as a "comma separate value" string (csv)
            return $"{Title},{Level},{StartDate.ToString("MMM dd yyyy")},{Years}";
        }

        //even though you could possible change a property directly
        //there is nothing to say, can I also do it in a method?
        public void CorrectStartDate(DateTime startdate)
        {
            //if the property does NOT have validation in it AND you need to apply validation
            //  then you would have to include the validation within this method.
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future.");
            }
            StartDate = startdate;

            //add the generation of the years when the date is updated
            //this assumes that this is the most current employment

            TimeSpan days = DateTime.Today - startdate;
            Years = Math.Round((days.Days / 365.2), 1);

        }

        //this is a discussion method and NOT part of the Employment class
        //topic: Does one have to pass in data to a method if the data is part of the instance
        //       The answer is NO.
        //Logic: the instance needs to exist to call the method
        //       the data needs to exist to create the instance
        //       therefore the data is already in the instance
        //       thus the data does NOT need to be passed into the method, simply accessed
        //          from within the instance.
        //public double TerminationPay(double salary)
        //{

        //    double pay = 0.0;
        //    double weeks = 0.0;
        //    weeks = Years * 52; //using the value already in the instance
        //    pay = weeks > 260 ? salary : weeks / 260 * salary;

        //    //rewrite of statement as if statement
        //    //if (weeks > 260)
        //    //{
        //    //    pay = salary;
        //    //}
        //    //else
        //    //{
        //    //    pay =  weeks / 260 * salary;

        //    //}
        //    return pay;
        //}
    }
}
