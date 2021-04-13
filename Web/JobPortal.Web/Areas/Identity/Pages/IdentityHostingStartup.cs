using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(JobPortal.Web.Areas.Identity.IdentityHostingStartup))]

namespace JobPortal.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
