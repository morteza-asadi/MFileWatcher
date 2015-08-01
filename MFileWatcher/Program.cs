using LogServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatcherServices;

//Morteza Asadi 1 Agust 2015
//Version 1.0.1

namespace MFileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Drive Name (sample : D:\\) : ");

            string drive = Console.ReadLine().ToUpper();

            if (isDriveExists(drive))
            {
                Console.WriteLine("Watcher Start At " + DateTime.Now);

                Console.WriteLine("Press Any Key To Exit");

                LogService LS = new LogService(AppDomain.CurrentDomain.BaseDirectory, LogStrategy.File, LogStrategy.Console);

                WatcherService ws = new WatcherService(drive, LS);

                ws.Start();

                Console.ReadKey();

                ws.Stop();

            }
            else
            {
                Console.WriteLine("Drive Not Found");
            }


        }

        /// <summary>
        /// Check Drive Name Exist or Not
        /// </summary>
        /// <param name="driveName">Drive Name</param>
        /// <returns>True/False</returns>
        static bool isDriveExists(string driveName)
        {
            return DriveInfo.GetDrives().Any(x => x.Name == driveName);
        }
    }
}


