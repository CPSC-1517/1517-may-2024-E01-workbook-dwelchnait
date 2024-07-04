using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.DAL;
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
            //add my contexgt class to the services (IServiceCollection)
            services.AddDbContext<WestWindContext>(options);
        }
    }
}
