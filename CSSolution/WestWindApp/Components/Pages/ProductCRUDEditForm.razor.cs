using WestWindSystem.Entities;
using WestWindSystem.BLL;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WestWindApp.Components.Pages
{

    public partial class ProductCRUDEditForm
    {
        [Inject]
        public IJSRuntime JSRunTime { get; set; }

        [Parameter]
        public int? productId { get; set; }

        private string? feedbackMessage = "";
        private List<string> errors = new List<string>();


        [Inject]
        private ProductServices _productServices { get; set; }
        private Product CurrentProduct = new();
        //attempt to get  validationMessageStore.Add to work in try/catch
        //static private Product CurrentProduct = new();  //


        [Inject]
        private CategoryServices _categoryServices { get; set; }
        private List<Category> categories = new();

        // private int selectedCategoryId;
        [Inject]
        private SupplierServices _supplierServices { get; set; }
        private List<Supplier> suppliers = new();

        [Inject]
        protected NavigationManager CurrentNavigationManager { get; set; }

        //for EditForm
        private EditContext editContext;
        private ValidationMessageStore validationMessageStore;
       

        protected override void OnInitialized()
        {
            //Allows us to programmatically validate the form and manage validation state.
            editContext = new EditContext(CurrentProduct);
            //Used for adding custom validation errors
            validationMessageStore = new ValidationMessageStore(editContext);

            categories = _categoryServices.Categories_Get();
            suppliers = _supplierServices.Suppliers_Get();

            //when the page is first render, we need to determind if the page was called with
            //   a pkey parameter value
            // No value: assumption is a NEW (create) product will be done, nothing to lookup
            // Yes value: assumption an existing product record will be altered or deleted
            //            the current record on the database should be displayed to the use
            //            within this method, lookup the record to display

            if (productId.HasValue)
            {
                //retreive the current record from the database that matches the parameter pkey value
                //the .Value is needed because productId is a nullable int
                CurrentProduct = _productServices.Products_GetByProductID(productId.Value);
            }
            base.OnInitialized();
        }
        private Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
        private void OnClickReturnQuery()
        {
            CurrentNavigationManager.NavigateTo("./categoryproducts");
        }
        private async Task OnClickDiscontinue()
        {
            //consider giving the user a second chance to avoid a "bad" mistake
            //  in deleting a record
            //you can prompt the user to confirm that this action needs to be done
            //if you are using the confirmation then the method should be an async Task method

            //clear old messages
            feedbackMessage = "";
            errors.Clear();

            //issue a prompt dialogue to the user to obtain confirmation of the action
            object[] messageline = new object[] { $"Are you sure you want to discountinue {CurrentProduct.ProductName}?" };
            if (await JSRunTime.InvokeAsync<bool>("confirm", messageline))
            {
                try
                {
                    //you could set the logical field here in your event
                    // OR
                    //it could be set in the service method
                    //it does not hurt to do it in both places
                    //in our example we handle the setting of this field in the service method

                    CurrentProduct.Discontinued = true; //this is optional

                    int rowsaffected = _productServices.Products_LogicalDelete(CurrentProduct);

                    //if an exception happened in the class library or database, execution
                    //  will continue in the catch

                    //successful Update
                    //communicate the results to the user
                    if (rowsaffected == 0)
                    {
                        feedbackMessage = $"Product {CurrentProduct.ProductName} is no long on file. " +
                        $" Check to see if product is still on file.";
                    }
                    else
                    {

                        feedbackMessage = $"Product (ID:{CurrentProduct.ProductID}) has been discontinued.";
                        //update  the discontinue attribute on our local copy of the instance
                        CurrentProduct.Discontinued = true;
                    }

                }
                catch (ArgumentNullException ex)
                {
                    //an error occured outside of the web page; possibly in the service method or 
                    //  while storing to the database.
                    errors.Add($"Save Error: {GetInnerException(ex).Message}");
                    // Adding a non-property-specific error message to the ValidationMessageStore
                    //var fieldIdentifier = new FieldIdentifier(CurrentProduct, fieldName: null);
                    //validationMessageStore.Add(null, $"Save Error: {GetInnerException(ex).Message}");
                }
                catch (ArgumentException ex)
                {
                    //an error occured outside of the web page; possibly in the service method or 
                    //  while storing to the database.
                    errors.Add($"Save Error: {GetInnerException(ex).Message}");
                    // Adding a non-property-specific error message to the ValidationMessageStore
                    //var fieldIdentifier = new FieldIdentifier(CurrentProduct, fieldName: null);
                    //validationMessageStore.Add(null, $"Save Error: {GetInnerException(ex).Message}");
                }
                catch (Exception ex)
                {
                    //an error occured outside of the web page; possibly in the service method or 
                    //  while storing to the database.
                    errors.Add($"Save Error: {GetInnerException(ex).Message}");
                    // Adding a non-property-specific error message to the ValidationMessageStore
                    //var fieldIdentifier = new FieldIdentifier(CurrentProduct, fieldName: null);
                    //validationMessageStore.Add(null, $"Save Error: {GetInnerException(ex).Message}");
                }
            }
        }

        private void OnClickSave()
        {
            //clean out any old messages
            feedbackMessage = "";
            errors.Clear(); //messages for try/catch
            validationMessageStore.Clear(); //messages for validation summary of EditForm

            try
            {
                //all local validation is done as per EditForm

                if(editContext.Validate())
                {
                    //any validation of form data to be done on the web page
                    //sample validation
                    //check that the category has been picked
                    if (CurrentProduct.CategoryID == 0)
                    {
                        //add a message to be displayed under the CategoryID field
                        validationMessageStore.Add(editContext.Field(nameof(CurrentProduct.CategoryID)), "You must select a category");
                    }
                    //was any web page processing errors discovered
                    if (editContext.GetValidationMessages().Any())
                    {
                        //notify editContext a state change has been made
                        editContext.NotifyValidationStateChanged();
                    }
                    else
                    {
                        //all front end validation is complete
                        //assume all data should be good to store to the data base
                        //decide if this is an Add or Update
                        if (CurrentProduct.ProductID == 0)
                        {
                            //assume the data is correct

                            //Create (ADD) in Crud
                            //this is a new product
                            //Discontinued will be set to false (datatype default)

                            //remember we have setup the form to fill an instance ov Product
                            //the data on the form has ALREADY been placed into the instance
                            //the ADD service will return the new ProductID
                            //pass the data from the form into the class library BLL Method
                            int newProductID = _productServices.Products_AddProduct(CurrentProduct);

                            //if an exception happened in the class library or database, execution
                            //  will continue in the catch

                            //successful Add
                            //communicate the results to the user
                            feedbackMessage = $"Product (ID:{newProductID}) has been added.";
                            //update the form: change the readonly field ProductID to show the new ProductID
                            CurrentProduct.ProductID = newProductID;
                        }
                        else
                        {
                            //Update (Update) in crUd
                            //this is an existing product


                            int rowsaffected = _productServices.Products_UpdateProduct(CurrentProduct);

                            //if an exception happened in the class library or database, execution
                            //  will continue in the catch

                            //successful Update
                            //communicate the results to the user
                            if (rowsaffected == 0)
                            {
                                feedbackMessage = $"Product {CurrentProduct.ProductName} has not been updated. " +
                                $" Check to see if product is still on file.";
                            }
                            else
                            {
                                feedbackMessage = $"Product (ID:{CurrentProduct.ProductID}) has been updated.";
                            }
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                //an error occured outside of the web page; possibly in the service method or 
                //  while storing to the database.
                errors.Add($"Save Error: {GetInnerException(ex).Message}");
                // Adding a non-property-specific error message to the ValidationMessageStore
                //var fieldIdentifier = new FieldIdentifier(CurrentProduct, fieldName: null);
                //validationMessageStore.Add(null, $"Save Error: {GetInnerException(ex).Message}");
            }
            catch (ArgumentException ex)
            {
                //an error occured outside of the web page; possibly in the service method or
                //  while storing to the database.
                errors.Add($"Save Error: {GetInnerException(ex).Message}");
                // Adding a non-property-specific error message to the ValidationMessageStore
                //var fieldIdentifier = new FieldIdentifier(CurrentProduct, fieldName: null);
                //validationMessageStore.Add(null, $"Save Error: {GetInnerException(ex).Message}");
            }
            catch (Exception ex)
            {
                //an error occured outside of the web page; possibly in the service method or
                //  while storing to the database.
                errors.Add($"Save Error: {GetInnerException(ex).Message}");
                // Adding a non-property-specific error message to the ValidationMessageStore
                //var fieldIdentifier = new FieldIdentifier(CurrentProduct, fieldName: null);
                //validationMessageStore.Add(null, $"Save Error: {GetInnerException(ex).Message}");
            }
        }
    }
}
