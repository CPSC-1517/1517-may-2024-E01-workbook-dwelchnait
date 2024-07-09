using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class BuildVersionServices
    {

        #region setup of the context connection variable and class constructor
        //any method(service) will probably need to access the database
        //this will be done via the context class (WestWindContext)
        //when this class is instantiated there will be a reference call by
        //  the extension class registration method which will supply
        //  the registered content connection
        private readonly WestWindContext _context;

        //class constructor
        internal  BuildVersionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        /*********************** Services *********************************/
        //a service is a method

        //create a service that will read the single record on the entity BuildVersion
        
        public BuildVersion BuildVersion_Get()
        {
            //call the context property: BuildVersions
            //the call will return the dataset (aka records) from the sql table BuildVersions
            //  via the DbSet property
            //data returned in this fashion is return as a set with a datatype of IEnumerable<T>
            //it does not matter if there is 0, 1 or more records
            //using methods with Linq you can limit the data to extract from the returned dataset

            //go get my data (a collection) off the sql table BuildVersions
            IEnumerable<BuildVersion> info = _context.BuildVersions;

            //return one row form the data within info
            //Linq has a method that limits the number of rows from the dataset collection
            //.FirstOrDefault()
            //this method will return the first record in the dataset collection
            //if the collection is empty, it will return the default of the datatype
            // (in this case, it is a class therefore the default of a datatype class is null
            return info.FirstOrDefault();
        }
    }
}
