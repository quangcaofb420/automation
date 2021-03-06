using ManagerAppNC.Components;
using ManagerAppNC.Core.Infrastructures;
using ManagerAppNC.Core.Infrastructures.Services;
using ManagerAppNC.Core.Repositories;
using ManagerAppNC.Core.Services;
using ManagerAppNC.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerAppNC
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DIServiceProvider.init((services)=> {
                services.AddSingleton<Main>();
                services.AddSingleton<FBAccListComponent>();

                services.AddSingleton<IFBAdsService, FBAdsService>();
                services.AddSingleton<IFBAdsRepository, FBAdsRepository>();
            });

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = DIServiceProvider.Register<Main>();
            Application.Run(mainForm);

        }
    }
}
