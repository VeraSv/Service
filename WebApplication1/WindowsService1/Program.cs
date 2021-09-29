using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main(string[]args)
        {

            if(Environment.UserInteractive)
            {
                if(args!=null && args.Length>0)
                {
                    switch (args[0]) {
                        case "--install":
                            try
                            {
                              var appParth = System.Reflection.Assembly.GetExecutingAssembly().Location;
                                System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { appParth });
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); };
                            break;
                        case "--uninstall":
                            try
                            {
                                var appParth = System.Reflection.Assembly.GetExecutingAssembly().Location;
                                System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] {"/u", appParth });
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); };
                            break;


                    }

                }
            }
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
