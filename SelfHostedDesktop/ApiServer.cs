using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SelfHostedDesktop
{


    public static class ApiServer
    {
        private static IHost? _host;

        public static void Start()
        {
            if (_host != null) return;

            _host = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                              .UseUrls("http://localhost:5000")
                              .Configure(app =>
                              {
                                  app.UseRouting();
                                  app.UseEndpoints(endpoints =>
                                  {
                                      endpoints.MapGet("/hello", () => "Hello from WPF API!");
                                  });
                              });
                })
                .Build();

            _host.Start();
        }

        public static async Task Stop()
        {
            if (_host != null)
            {
                await _host.StopAsync();
                _host = null;
            }
        }
    }

}
