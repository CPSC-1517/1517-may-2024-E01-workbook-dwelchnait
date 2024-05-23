using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        public string FirstName 
        { 
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name is required");
                }
                _FirstName = value.Trim();
            }
        }
        public string LastName { get; set; }
        public ResidentAddress Address { get; set; }

        public List<Employment> EmploymentPositions { get; set; }

        public string FullName { get; }

        public Person()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            EmploymentPositions = new List<Employment>();
        }

        public Person(string firstname, string lastname,
                        ResidentAddress address, List<Employment> employmentpositions)
        {
            //refactor this code once further class development has been done
            //if (string.IsNullOrWhiteSpace(firstname))
            //{
            //    throw new ArgumentNullException("First name is required");
            //}
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException("Last name is required");
            }
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employmentpositions == null)
            {
                EmploymentPositions = new List<Employment>();
            }
            else
            {
                EmploymentPositions = employmentpositions;
            }
        }
    }
}
