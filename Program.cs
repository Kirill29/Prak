using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace Geoportal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host=CreateWebHostBuilder(args).Build();

          

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
               WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                   .UseHttpSys(options =>
                   {

                      
                    
                       options.MaxConnections = null;
                       options.MaxRequestBodySize = 30000000;
                       options.UrlPrefixes.Add("http://localhost:80/");
                   });




    }
}
