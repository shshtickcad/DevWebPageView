using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DevExtremeAspNetCoreApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Config.ConfigClient.InitializeClient();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
