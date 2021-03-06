using ManagerAppNC.Components;
using ManagerAppNC.Core.Infrastructures.Services;
using ManagerAppNC.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ManagerAppNC.DI
{
    public class DIServiceProvider
    {
        private static IServiceProvider service;
        public static void init(Action<IServiceCollection> configure)
        {
            var builder = new HostBuilder()
                         .ConfigureServices((hostContext, services) =>
                         {
                             configure(services);
                         });
            var host = builder.Build();

            var serviceScope = host.Services.CreateScope();
            service = serviceScope.ServiceProvider;
        }

        public static T Register<T>()
        {
            var obj = service.GetRequiredService<T>();
            return obj;
        }
    }
}
