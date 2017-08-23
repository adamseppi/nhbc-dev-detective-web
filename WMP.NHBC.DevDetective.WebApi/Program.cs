

using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WMP.NHBC.DevDetective.WebApi
{
    public class Program
    {



        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
            var hostUrl = configuration["hosturl"];

#if DEBUG

            hostUrl = "http://0.0.0.0:5000";
#endif

            if (string.IsNullOrEmpty(hostUrl))
            {
                hostUrl = "http://0.0.0.0:6000";
            }
 
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(hostUrl)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
