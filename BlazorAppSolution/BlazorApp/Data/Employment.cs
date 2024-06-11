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

   
    }
}
