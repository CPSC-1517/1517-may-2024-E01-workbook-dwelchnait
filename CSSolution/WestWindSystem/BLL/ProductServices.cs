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
    public class ProductServices
    {
        #region setup the context connection variable and class constructor
        private readonly WestWindContext _context;

        //constructor to be used in the creation of the instance of this class
        //the registered reference for the context connection (database connection)
        //  will be passed from the IServiceCollection registered services
        internal ProductServices(WestWindContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion

        //Queries

        public List<Product> Products_GetByCategoryID(int categoryid)
        {
            return _context.Products
                    .Where(p => p.CategoryID == categoryid)
                    .OrderBy(p => p.ProductName).ToList();
        }

        public Product Products_GetByProductID(int productid)
        {
            //primary key lookup
            //only 1 record should be found (if it exists)
            //the return datatype should be a single Product
            //BECAUSE queries expect 0,1 or more records, the query
            //  needs to indicated that only first record found should be returned.
            //use the .FirstOrDefault() method on your query
            //if the record was found, it will be returned
            //if the record was not found, the default for an object is return: null
            return _context.Products
                    .Where(p => p.ProductID == productid)
                    .FirstOrDefault();
                    
        }
    }
}
