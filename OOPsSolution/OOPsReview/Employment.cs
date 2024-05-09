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
        //  the a constructor OR a behaviour
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
            set 
            {

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Year value {value} is invalid. Must be 0 or greater.");
                }
                _Years = value;
            }
        }
        //this property is an example of an auto-implemented property
        //there is no validation in the property
        //therefore no private data member is required
        //the system will generate an internal storage area for the data
        //      and handle the setting and retreiving from that storage area
        //the private set means that the property will only be able to be
        //      set via a constructor or behaviour
        public DateTime StartDate { get; set; }

        //constructors

        //methods

    }
}
