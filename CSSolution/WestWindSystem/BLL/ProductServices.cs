using Microsoft.EntityFrameworkCore.ChangeTracking;
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

    # region Queries

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

        #endregion

        #region Maintenance Commands: Add, Update, and Delete
        //Adding a record to your database MAY require you to
        //  verify that the data does not already exists on the database
        //  verify that the incoming data is valid (do not trust the front end to do this work)

        //these actions are referred to as Business Logic (Business Rules)

        //you should ensure that any parameters have argument values passed into your code

        //Items you need to consider
        //The primary key
        //  is it an identity, then the incoming data does not need a primary key value
        //  is it a non-identity, then your must insure a value exists
        //                        consider checking if the key is already in use
        //                        if there is a problem then issue an exception

        //Have you been given a Busines Rule
        //Example: Assume that the product cannot be from the same supplier
        //          with the same product name for the same unit size

        //if all validation is passed then you can actually add the data to the database

        public int Products_AddProduct(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("You must supply the product information");

            //example of our "made-up" Business Rule for this example
            bool exists = false;
            //.Any(predicate)
            //  returns a true or false (not the data) depending success of the predicate
            //       on the collection existing
            //this is different then the .Where(predicate) which returns data
            exists = _context.Products
                        .Any(p => p.SupplierID == item.SupplierID
                               && p.ProductName.Equals(item.ProductName)
                               && p.QuantityPerUnit == item.QuantityPerUnit);

            if (exists)
                throw new ArgumentException("Product already on file");

            // you would code any additional validation for your data

            //once you have determind that the data can go to the database, it is time
            //  to stage and commit the data

            //Staging (EniityFramework for our database processing)
            // staging is the act of placing your data into local memory
            //      sfor the eventual processing on the database
            // a) DbSet: Products
            // b) know the action: Add
            // c) indicate the data involved: item

            //IMPORTANT: the data is in LOCAL MEMORY
            //           the data is NOT!!!! yet been sent to the database
            //THERFORE: at this time, there is NO!!! IDENTITY primary key value
            //              on this instance (except for the default of the datatype)
            //UNLESS: you have placed a value in the NON_IDENTITY key field

            _context.Products.Add(item);

            //COMMIT
            //  this sends the local Staged data to the database for processing

            //ANY validation in the entity model definition will be applied at this point
            //      prior to the data being sent to the database
            //the validation annotation that exists in your entity model definitions
            //  were placed there during your reverse engineering
            //IF any of that validation does not pass, your data does not go to the database
            //   and an exception is thrown

            _context.SaveChanges();

            //AFTER the successful commit to the database, your new product id
            //      will be inserted into your local instance of the data
            //NOW you have access to your NEW primary key value

            return item.ProductID;
        }

        public int Products_UpdateProduct(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("You must supply the product information");

            //it is suggested that you check to see if the record is still on the database
            bool isthere = _context.Products
                                .Any(p => p.ProductID == item.ProductID);
            if (!isthere)
                throw new ArgumentException($"Product {item.ProductName} (id: {item.ProductID}) is no longer on file.");
            
            //example of a "made-up" business rule
            //in the update, we still do not want duplicate products under different ids
            //we will need to alter the Add version so that the current product is NOT
            //  include in the check
            bool exists =  _context.Products
                        .Any(p => p.SupplierID == item.SupplierID
                               && p.ProductName.Equals(item.ProductName)
                               && p.QuantityPerUnit == item.QuantityPerUnit
                               && p.ProductID != item.ProductID);
            if (exists)
                throw new ArgumentException($"Product {item.ProductName} with a QPU of" +
                    $" {item.QuantityPerUnit} for indicated supplier is already on file.");

            //assuming all validation checks are done with no errors found

            //Staging
            EntityEntry<Product> updating = _context.Entry(item);
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //Commit
            //the return value from the database for an update is the number of rows affected

            return _context.SaveChanges();
        }
            
        //Delete: cruD
        //there are two types of deletes: physical and logical
        //Whether you have a physical or logical delete is determind WHEN
        //  the system is designed (database, data requirements)

        //Logical delete
        //this happens when the recorde is deemed "unwanted" BUT CANNOT be 
        //  physically removed from the database because the records has
        //  a relationship to another records (parent/child) and the associated record
        //  CANNOT be removed

        //Example: The product record is a parent to ManitfestItems records
        //         The the manitest record is need for tracking, it does to the receiver of the product
        //so, because the other record(s) are required for the busines
        //      one CANNOT physically remove the ("parent") product record.

        //usually in this situation, the parent record (product) will have some type of field
        //  that will indicate "deleted"
        //on the product record such a field is the Discontinued field

        //Qustion: If the record will not be deleted, what happens?
        //Answer: here, you will actually do an update
        //Within the method, it is a good practice NOT to rely on the user to set
        //  the "logical delete" field to the delete status
        //Your method should set the value

        public int Products_LogicalDelete(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("You must supply the product information");

            //does the product exist on the database
            //since the user could possible change data on the form, it is best
            //  to obtain the current data from the database
            //the only value to change on the current record is the field to indicate removal
            Product exists = _context.Products
                       .FirstOrDefault(p =>  p.ProductID != item.ProductID);
            if (exists == null)
                throw new ArgumentException($"Product {item.ProductName} " +
                    $" (id:{item.ProductID}) is no longer on file.");

            //have the method actually set the removal field to the appropriate value
            exists.Discontinued = true;

            //Staging
            EntityEntry<Product> updating = _context.Entry(exists);
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //Commit
            //the return value from the database for an update is the number of rows affected

            return _context.SaveChanges();
        }

        //Physical Delete
        //you physically remove the record from the database
        //IF there are no "child" records to prevent the record removal, you can remove the record
        //IF there are "children" AND the "children" are not required, you can remove the record
        //      HOWEVER, you will need to first remove any "children" before removing the parent record
        //      assuming there is no cascade delete setup on the database

        public int Products_PhysicalDelete(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("You must supply the product information");

            //does the product exist on the database
           
            Product exists = _context.Products
                       .FirstOrDefault(p => p.ProductID != item.ProductID);
            if (exists == null)
                throw new ArgumentException($"Product {item.ProductName} " +
                    $" (id:{item.ProductID}) is no longer on file.");

            //optional check, but good practice
            int existingChildren = exists.ManifestItems.Count();
            existingChildren += exists.OrderDetails.Count();

            if (existingChildren > 0)
                throw new ArgumentException($"Product {item.ProductName} " +
                    $" (id:{item.ProductID}) has related information on file. Unable to delete.");

            //Staging
            EntityEntry<Product> deleting = _context.Entry(exists);
            deleting.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            //Commit
            //the return value from the database for an update is the number of rows affected

            return _context.SaveChanges();
        }
        #endregion

    }//eoc
}//eon
