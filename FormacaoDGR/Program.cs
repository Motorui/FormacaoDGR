using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace FormacaoDGR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (CultureInfo.CurrentCulture.Name != "pt-PT")
            {
                CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-PT");
                CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("pt-PT");
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
