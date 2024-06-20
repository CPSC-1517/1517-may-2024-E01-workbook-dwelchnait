using OOPsReview;

namespace BlazorApp.Components.Pages
{
    public partial class EmploymentReport
    {
        private string feedback = "";
        //in this example we will use a List<string> instead of a dictionary
        private List<string> errormsgs = new List<string>();

        private Employment employment = new();
        private List<Employment> employments = new List<Employment>();

        protected override void OnInitialized()
        {
            Reading();
            base.OnInitialized();
        }

        private void Reading()
        {
            feedback = ""; //clear out any old message
            errormsgs.Clear(); //clear out all existing keys and their values

            //there are a couple of ways to refer to your file and its path
            //  i) obtain the root path of your application using an injection
            //      service called IWebHostEnvironment via property injection (see variables)
            //  ii) use relative addressing starting a the top of your application

            //on this page we will use relative addressing
            //This addressing of the required file will start at the top of your web application
            //syntax:   string filename = @"./foldername/.../filename.csv"
            string filename = @"./Data/Employments.csv";

            // The System.IO.File method ReadAllLines(...) will return an array
            //      of lines as strings where each array element represents a
            //      line in my file
            Array userdata = null;
            try
            {
                //read the file
                userdata = System.IO.File.ReadAllLines(filename);

                //the records at this point are just strings
                //the records need to be turned into instances of Employment
                //then each instance will be added to the collection for the report
                foreach (string line in userdata)
                {
                    employment = Employment.Parse(line);
                    employments.Add(employment);
                }
            }
            catch (ArgumentNullException ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
            }
            catch (ArgumentException ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).Message);
            }
        }

        private Exception GetInnerException(Exception ex)
        {
            //drill down into your Exception until there are no more inner exceptions
            //at this point you have the "real" error
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }

    }
}
