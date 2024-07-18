
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
using Microsoft.EntityFrameworkCore; //needed for the .Include method
#endregion

namespace WestWindSystem.BLL
{
    public class ShipmentServices
    {
        #region setup of the context connection variable and class constructor
        //any method(service) will probably need to access the database
        //this will be done via the context class (WestWindContext)
        //when this class is instantiated there will be a reference call by
        //  the extension class registration method which will supply
        //  the registered content connection
        private readonly WestWindContext _context;

        //class constructor
        internal ShipmentServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        /************************ Services *************************************/
        //public List<Shipment> Shipments_GetByYearAndMonth(int year, int month)
        //{
        //    IEnumerable<Shipment> info = _context.Shipments
        //                                        .Where(s => s.ShippedDate.Year == year 
        //                                                && s.ShippedDate.Month == month)
        //                                        .OrderBy(s => s.ShippedDate);
        //    return info.ToList();
        //}

        //This uses the technique (b) discussed on the ShipmentTable page
        //note there is a required using class, see Additional namespaces above.
        //uses the .Include method to add navigational instances to the return record
        //note the predicate uses the virtual navigational property of the Shipment entity
        //This will include the associated record from the Shippers table (parent) for the shipment record (child)
        public List<Shipment> Shipments_GetByYearAndMonth(int year, int month)
        {
            IEnumerable<Shipment> info = _context.Shipments
                                                .Include(s => s.ShipViaNavigation)
                                                .Where(s => s.ShippedDate.Year == year
                                                        && s.ShippedDate.Month == month)
                                                .OrderBy(s => s.ShippedDate);
            return info.ToList();
        }
    }
}
