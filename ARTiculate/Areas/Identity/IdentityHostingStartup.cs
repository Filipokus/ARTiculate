using System;
using ARTiculate.Areas.Identity.Data;
using ARTiculate.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ARTiculate.Areas.Identity.IdentityHostingStartup))]
namespace ARTiculate.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ARTiculateAuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ARTiculateAuthDbContextConnection")));

                services.AddDefaultIdentity<ARTiculateUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredUniqueChars = 0;
                    


                    
                    })
                    .AddEntityFrameworkStores<ARTiculateAuthDbContext>();
            });
        }
    }
}