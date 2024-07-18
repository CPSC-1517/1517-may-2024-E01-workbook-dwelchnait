using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
using WestWindSystem.BLL;
#endregion

namespace WestWindSystem
{
    public static class WestWindExtensions
    {
        //this is a method of the extension class which will be call from the
        //   Program.cs file of the Web Application
        //this method will do 2 things
        //  register the context connection string
        //  register ALL services that I create within the BLL layer classes
        public static void WestWindExtensionServices(this IServiceCollection services,
            Action<DbContextOptionsBuilder>options)
        {
            //handle the connection string
            //add my context class to the services (IServiceCollection)
            services.AddDbContext<WestWindContext>(options);

            //YOU MUST REGISTER EACH AND EVERY BLL SERVICE CLASS YOU WISH YOUR WEB APP TO USE

            //to register a service class you willuse the IServiceCollection method .AddTransient<T>
            //for any outside coding that requires access to one of my coded services
            //  you MUST register the service
            services.AddTransient<BuildVersionServices>((serviceProvider) =>
                {
                    //this statement obtains the context information registered above in the
                    //  AddBdContext
                    var context = serviceProvider.GetService<WestWindContext>();

                    //create an instance of the service class and register said class in
                    //  IServiceCollection 
                    //once the class has been registered, it can be used by ANY outside source
                    //  within an application that has call the WestWindExtensionServices method
                    //  while building the web application
                    return new BuildVersionServices(context);
                }
                );
            services.AddTransient<RegionServices>((serviceProvider) =>
                {

                    var context = serviceProvider.GetService<WestWindContext>();

                    return new RegionServices(context);
                }
                );
            services.AddTransient<CategoryServices>((serviceProvider) =>
                {

                    var context = serviceProvider.GetService<WestWindContext>();

                    return new CategoryServices(context);
                }
                );
            services.AddTransient<ShipmentServices>((serviceProvider) =>
                {

                    var context = serviceProvider.GetService<WestWindContext>();

                    return new ShipmentServices(context);
                }
                );
            services.AddTransient<ShipperServices>((serviceProvider) =>
                {

                    var context = serviceProvider.GetService<WestWindContext>();

                    return new ShipperServices(context);
                }
              );
        }
    }
}
