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
    public class RegionServices
    {
        #region setup of the context connection variable and class constructor
        //any method(service) will probably need to access the database
        //this will be done via the context class (WestWindContext)
        //when this class is instantiated there will be a reference call by
        //  the extension class registration method which will supply
        //  the registered content connection
        private readonly WestWindContext _context;

        //class constructor
        internal RegionServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        /*********************** Services *********************************/
        public List<Region> Regions_Get()
        {
            //get the data from the Regions sql table
            IEnumerable<Region> info = _context.Regions;

            //order the records by the field RegionDescription (aplhabetically)
            //convert from an IEnumerable<T> collection to a List<T> collection
            return info.OrderBy(r => r.RegionDescription).ToList();
        }
    }
}
