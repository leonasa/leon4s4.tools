using System;
using leonasa.Tools.SelfHostWebApi;
using Microsoft.Owin.Hosting;

namespace leon4s4.tools.SelfHostWebApi
{
    public class WebApiInitializer
    {
        public void Start(string port)
        {
            var options = new StartOptions();
            options.Urls.Add($"http://localhost:{port}");
            options.Urls.Add($"http://127.0.0.1:{port}");
            options.Urls.Add($"http://{Environment.MachineName}:{port}");

            using (WebApp.Start<Startup>(options))
            {
                Console.WriteLine($"Web Server is running. at port {port}");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}